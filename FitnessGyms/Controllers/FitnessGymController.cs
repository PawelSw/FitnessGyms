using FitnessGyms.Application.Services;
using FitnessGyms.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FitnessGyms.Controllers
{
    public class FitnessGymController : Controller
    {
        private readonly IFitnessGymService _fitnessGymService;
        public FitnessGymController(IFitnessGymService fitnessGymService) 
        {
            _fitnessGymService = fitnessGymService;
        }

        public IActionResult Create() 
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(FitnessGym fitnessGym)
        {
            await _fitnessGymService.Create(fitnessGym); 
           return RedirectToAction(nameof(Create)); // TODO Refactor
        }
    }
}
