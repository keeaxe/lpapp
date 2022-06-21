using Lotto.Services.Interfaces;
using Lotto.Models.Dtos.Skips;

namespace Lotto.Services.Implementation
{
    /// <summary>
    /// Service for returning Skip data
    /// </summary>
    public class SkipService : ISkipService
    {
        // TODO: move to static constant file (should be own project?)
        private static readonly int LOTTO_MAX_NUMBER = 70, 
                                    LOTTO_MIN_NUMBER = 1;

        private readonly ILottoDrawingsService _lottoDrawingsService;

        public SkipService(ILottoDrawingsService lottoDrawingSerivce) 
        {
            _lottoDrawingsService = lottoDrawingSerivce;
        }

        public async Task<SkipDto> GetSkipCountForNumber(int number) 
        {
            var skipData = await GetAverageSkipCountForNumber(number);

            return skipData;
        }

        public async Task<List<SkipDto>> GetSkipCountForAllNumbers() 
        {
            List<SkipDto> skipData = new List<SkipDto>();

            for (int i = LOTTO_MIN_NUMBER; i <= LOTTO_MAX_NUMBER; i++) 
            {
                skipData.Add(await GetAverageSkipCountForNumber(i));
            }

            return skipData;
        }

        private async Task<SkipDto> GetAverageSkipCountForNumber(int number) 
        {
            var drawings = await _lottoDrawingsService.GetAllDrawings();
            var draws = await _lottoDrawingsService.GetDrawingsContainingNumber(number, false);
            int skip = 0, minSkip = Int32.MaxValue, maxSkip = 0;
            List<int> skipHistory = new List<int>();

            // Get skip history for number and max/min skip
            drawings = drawings.OrderByDescending(d => d.Date).ToList();

            foreach (var draw in drawings) 
            {
                if (!draw.WinningNumbers.Contains(number))
                {
                    skip += 1;                    
                }
                else 
                {
                    skipHistory.Add(skip);

                    if (skip > maxSkip)
                    {
                        maxSkip = skip;
                    }
                    if (skip < minSkip)
                    {
                        minSkip = skip;
                    }

                    skip = 0;
                }
            }

            var average = skipHistory.Average();

            // Get Current Skip Count as of today
            int currentYear = DateTime.Now.Year, 
                currentMonth = DateTime.Now.Month, 
                currentDay = DateTime.Now.Day;
            int currentSkip = 0;
            DateTime lastDrawing = DateTime.Now;

            foreach (var drawing in drawings) 
            {
                if (drawing.WinningNumbers.Contains(number))
                {
                    break;
                }
                else 
                {
                    currentSkip++;
                    lastDrawing = drawing.Date;
                }
            }

            SkipDto skipDto = new SkipDto()
            {
                Number = number,
                TotalDraws = draws.Count,
                TotalMisses = drawings.Count - draws.Count,
                MaxSkips = maxSkip,
                MinSkips = minSkip,
                AverageSkips = average, 
                CurrentSkip = currentSkip,
                LastDrawing = lastDrawing
            };

            return skipDto;
        }
    }
}
