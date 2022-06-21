using Lotto.Data.Interface;
using Lotto.Models.Dtos.LottoDrawings;
using Lotto.Services.Interfaces;
using Lotto.Services.Mappers;

namespace Lotto.Services.Implementation
{
    /// <summary>
    /// Service for returning Lotto Drawings
    /// </summary>
    public class LottoDrawingsService : ILottoDrawingsService
    {
        private readonly ILottoRepository _lottoRepository;

        public LottoDrawingsService(ILottoRepository lottoRepository) 
        {
            _lottoRepository = lottoRepository;
        }

        public async Task<List<LottoDrawingsDto>> GetAllDrawings() 
        {
            var drawings = await _lottoRepository.GetAllDrawings();

            return drawings.Map();
        }

        public async Task<List<LottoDrawingsDto>> GetDrawingsContainingNumber(int number, bool includeMegaInSearch) 
        {
            var drawings = await _lottoRepository.GetDrawingsWithNumber(number, includeMegaInSearch);

            return drawings.Map();
        }
    }
}
