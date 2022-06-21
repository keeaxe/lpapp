using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotto.Services.Interfaces
{
    public interface IRelationshipService
    {
        public Task<int> MostPairedWith(int number);
    }
}
