using Lotto.Models.Dtos.Skips;

namespace Lotto.Services.Interfaces
{
    /// <summary>
    /// Service for returning Skip data
    /// </summary>
    public interface ISkipService
    {
        public Task<SkipDto> GetSkipCountForNumber(int number);
        public Task<List<SkipDto>> GetSkipCountForAllNumbers();
    }
}
