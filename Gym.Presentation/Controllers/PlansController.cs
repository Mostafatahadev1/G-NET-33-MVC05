using Gym.DataAccess.Entities;
using Gym.DataAccess.Repositries;
using Microsoft.AspNetCore.Mvc;

namespace Gym.Presentation.Controllers
{
    public class PlansController(IRepository<Plan> Plans) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var items = await Plans.GetAllAsync();
            return View(items);
        }

        public async Task<IActionResult> Details(int id)
        {
            if (id <= 0)
            {
                return RedirectToAction(nameof(Index));
            }

            var plan = await    Plans.GetByIdAsync(id);

            if (plan == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(plan);
        }


    }
}