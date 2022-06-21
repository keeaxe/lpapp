using Lotto.Models.Dtos.LottoDrawings;

namespace Lotto.Services.Interfaces
{
    /// <summary>
    /// Service for returning Lotto Drawings
    /// </summary>
    public interface ILottoDrawingsService
    {
        public Task<List<LottoDrawingsDto>> GetAllDrawings();
        public Task<List<LottoDrawingsDto>> GetDrawingsContainingNumber(int number, bool includeMegaInSearch);
    }
}
