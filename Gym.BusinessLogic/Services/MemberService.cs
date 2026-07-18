using Gym.BusinessLogic.ViewModel.Members;
using Gym.DataAccess.Entities;
using Gym.DataAccess.Enums;
using Gym.DataAccess.Repositries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Gym.BusinessLogic.Services
{
    public class MemberService(IMemberRepository memberRepo) : IMemberService
    {
        public async Task<IEnumerable<MemberIndexViewModel>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var members = await memberRepo.GetAllAsync(cancellationToken);

            return members.Select(m => new MemberIndexViewModel
            {
                Id = m.Id,
                Name = m.Name,
                Email = m.Email,
                Phone = m.Phone,
                PhotoUrl = m.Photo,
                JoinDate = DateOnly.FromDateTime(m.JoinDate),
                Gender = m.Gender.ToString(),
            });
        }

        public async Task<bool> CreateAsync(CreateMemberViewModel model, CancellationToken cancellationToken = default)
        {
            var email = model.Email.Trim().ToLower();
            var phone = model.Phone.Trim().ToLower();
            var name = model.Name.Trim().ToLower();

            if (await memberRepo.ExistsAsync(m => m.Email == email, cancellationToken))
            {
                return false;
            }

            if (!Enum.TryParse(model.Gender, true, out Gender gender))
            {
                return false;
            }

            if (!Enum.TryParse(model.HealthRecord.BloodType, true, out BloodType bloodType))
            {
                return false;
            }

            var member = new Member
            {
                Name = name,
                Email = email,
                Phone = phone,
                DateOfBirth = model.DateOfBirth,
                Gender = gender,
                JoinDate = DateTime.UtcNow,

                Address = new DataAccess.Entities.ValueObject.Address
                {
                    BuildingNumber = model.BuildingNumber,
                    City = model.City,
                    Street = model.Street,
                },

                HealthRecord = new HealthRecord
                {
                    BloodType = bloodType,
                    Height = model.HealthRecord.Height,
                    Weight = model.HealthRecord.Weight,
                    Notes = model.HealthRecord.Note
                }
            };

            await memberRepo.AddAsync(member, cancellationToken);
            await memberRepo.SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task<MemberDetailsViewModel?> GetDetailsAsync(int id, CancellationToken cancellationToken = default)
        {
            // Get member with their memberships included
            var member = await memberRepo.GetByIdAsync(
                id: id,
                cancellationToken: cancellationToken,
                m => m.MemberShips
            );

            if (member == null)
            {
                return null;
            }

            // Get the latest membership if available
            var latestMembership = member.MemberShips?
                .OrderByDescending(ms => ms.EndDate)
                .FirstOrDefault();

            return new MemberDetailsViewModel
            {
                Id = member.Id,
                Name = member.Name,
                PhotoUrl = member.Photo,
                Email = member.Email,
                PhoneNumber = member.Phone,
                Gender = member.Gender.ToString(),
                DateOfBirth = member.DateOfBirth.ToString("yyyy-MM-dd"),
                Address = member.Address != null
                    ? $"{member.Address.BuildingNumber}, {member.Address.Street}, {member.Address.City}"
                    : string.Empty,
                PlanName = latestMembership?.Plan?.Name ?? string.Empty,
                MembershipStartDate = latestMembership?.StartDate.ToString("yyyy-MM-dd") ?? string.Empty,
                MembershipEndDate = latestMembership?.EndDate.ToString("yyyy-MM-dd") ?? string.Empty
            };
        }

        public Task<string?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}