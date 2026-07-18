using Gym.BusinessLogic.Services;
using Gym.BusinessLogic.ViewModel.Members;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace Gym.Presentation.Controllers
{
    public class MembersController(IMemberService members) : Controller
    {
        public async Task<IActionResult> Index(CancellationToken ct)
        {
            var items = await members.GetAllAsync(ct);
            return View(items); // Views/Members/Index.cshtml
        }

        [HttpGet]
        public async Task <IActionResult> Create()
        {


            return View(members);
        }



        [HttpPost]
        public async Task<IActionResult> Create(CreateMemberViewModel model , CancellationToken cancellationToken )
        {
            return View ();
        }
        // problems

        // 1 - test business logic without http request ?
        // 2 - same logic needed in API and MVC ?

        // to solve problem we need use services

        // services => business logic


        // Vaildation  And AntiForegery

        // 1- jquery.Validate.min.js => Clinet side Validation (unobtrusive vaildation )

        // 2- Vaildate.Unbrostive.min.js => Clinet side vaildation 
    }
}