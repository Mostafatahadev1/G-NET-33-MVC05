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

            if (await memberRepo.ExistAsync(m => m.Email == email, cancellationToken))
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
    }
}