using AutoMapper;
using FitnessGyms.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessGyms.Application.FitnessGym.Querries.GetFitnessGymByEncodedName
{
    public class GetFitnessGymByEncodedNameHandler : IRequestHandler<GetFitnessGymByEncodedNameQuerry, FitnessGymDto>
    {
        private readonly IFitnessGymRepository _fitnessGymRepository;
        private readonly IMapper _mapper;

        public GetFitnessGymByEncodedNameHandler(IFitnessGymRepository fitnessGymRepository, IMapper mapper)
        {
            _fitnessGymRepository = fitnessGymRepository;
            _mapper = mapper;
            
        }
        public async Task<FitnessGymDto> Handle(GetFitnessGymByEncodedNameQuerry request, CancellationToken cancellationToken)
        {
            var fitnessGym= await _fitnessGymRepository.GetByEncodedName(request.EncodedName);
            var dto = _mapper.Map<FitnessGymDto>(fitnessGym);
            return dto;
            
        }
    }
}
