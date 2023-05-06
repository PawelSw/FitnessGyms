using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessGyms.Application.FitnessGym.Querries.GetFitnessGymByEncodedName
{
    public class GetFitnessGymByEncodedNameQuerry : IRequest<FitnessGymDto>
    {
        public string EncodedName { get; set; }

        public GetFitnessGymByEncodedNameQuerry(string encodedName)
        {
            EncodedName = encodedName;
        }
    }
}
