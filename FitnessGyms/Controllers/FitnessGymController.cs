using AutoMapper;
using FitnessGyms.Application.FitnessGym;
using FitnessGyms.Application.FitnessGym.Commands.CreateFitnessGym;
using FitnessGyms.Application.FitnessGym.Commands.EditFitnessGym;
using FitnessGyms.Application.FitnessGym.Querries.GetAllFitnessGyms;
using FitnessGyms.Application.FitnessGym.Querries.GetFitnessGymByEncodedName;
using FitnessGyms.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitnessGyms.Controllers
{
    public class FitnessGymController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public FitnessGymController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var fitnessGyms = await _mediator.Send(new GetAllFitnessGymsQuerry());
            return View(fitnessGyms);
        }


        [Route("FitnessGym/{encodedName}/Details")]
        public async Task<IActionResult> Details(string encodedName)
        {
            var dto = await _mediator.Send(new GetFitnessGymByEncodedNameQuerry(encodedName));
            return View(dto);
        }

        [Route("FitnessGym/{encodedName}/Edit")]
        public async Task<IActionResult> Edit(string encodedName)
        {
            var dto = await _mediator.Send(new GetFitnessGymByEncodedNameQuerry(encodedName));
            EditFitnessGymCommand model = _mapper.Map<EditFitnessGymCommand>(dto);
            return View(model);
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize]
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


        [HttpPost]
        [Route("FitnessGym/{encodedName}/Edit")]
        public async Task<IActionResult> Edit(string encodedName, EditFitnessGymCommand command)
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
