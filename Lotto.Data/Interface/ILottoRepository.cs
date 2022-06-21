using Lotto.Models.LottoDrawings;

namespace Lotto.Data.Interface
{
    /// <summary>
    /// Local JSON Data Repository for raw lotto data
    /// </summary>
    public interface ILottoRepository
    {
        public Task<List<LottoDrawing>> GetAllDrawings();
        public Task<List<LottoDrawing>> GetDrawingsWithNumber(int number, bool includeMegaInSearch);
        public Task<List<LottoDrawing>> GetDrawingsByYear(int year);
        public Task<List<LottoDrawing>> GetDrawingsByYearAndMonth(int year, int month);
    }
}
