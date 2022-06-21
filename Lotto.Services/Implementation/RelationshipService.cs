using Lotto.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotto.Services.Implementation
{
    public class RelationshipService : IRelationshipService
    {
        private readonly ILottoDrawingsService _drawingService;

        public RelationshipService(ILottoDrawingsService drawingsService) 
        {
            _drawingService = drawingsService;
        }

        public async Task<int> MostPairedWith(int number) 
        {
            List<int> counter = new List<int>();
            for (int i = 1; i <= 76; i++) 
            {
                counter.Add(0);
            }
            var data = await _drawingService.GetAllDrawings();

            for (int i = 0; i < data.Count; i++) 
            {
                if (data[i].WinningNumbers.Contains(number))
                {
                    for (int j = 0; j < data[i].WinningNumbers.Count; j++)
                    {
                        if (data[i].WinningNumbers[j] != number)
                        {
                            counter[data[i].WinningNumbers[j]]++;
                        }
                    }
                }
            }

            return counter.IndexOf(counter.Max());
        }
    }
}
