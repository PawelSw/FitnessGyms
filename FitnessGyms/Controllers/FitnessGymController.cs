using FitnessGyms.Application.FitnessGym;
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
        public async Task<IActionResult> Index()
        {
            var fitnessGyms = await _fitnessGymService.GetAll();
            return View(fitnessGyms);
        }
        public IActionResult Create() 
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(FitnessGymDto fitnessGym)
        {
            if (!ModelState.IsValid)
            {
                return View(fitnessGym);

            }
            await _fitnessGymService.Create(fitnessGym); 
           return RedirectToAction(nameof(Index)); 
        }
    }
}
