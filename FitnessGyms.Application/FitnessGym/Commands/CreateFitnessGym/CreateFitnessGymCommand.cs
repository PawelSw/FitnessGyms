using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessGyms.Application.FitnessGym.Commands.CreateFitnessGym
{
    public class CreateFitnessGymCommand : FitnessGymDto, IRequest
    {
    }
}
