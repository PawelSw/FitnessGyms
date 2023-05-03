using FitnessGyms.Application.FitnessGym;
using FitnessGyms.Application.FitnessGym.Commands.CreateFitnessGym;
using FitnessGyms.Application.FitnessGym.Querries.GetAllFitnessGyms;
using FitnessGyms.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FitnessGyms.Controllers
{
    public class FitnessGymController : Controller
    {
        private readonly IMediator _mediator;

        public FitnessGymController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var fitnessGyms = await _mediator.Send(new GetAllFitnessGymsQuerry());
            return View(fitnessGyms);
        }
        public IActionResult Create() 
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateFitnessGymCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);

            }
            await _mediator.Send(command);
           return RedirectToAction(nameof(Index)); 
        }
    }
}
