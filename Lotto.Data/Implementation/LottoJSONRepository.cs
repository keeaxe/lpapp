using Lotto.Data.Interface;
using Lotto.Models.LottoDrawings;

namespace Lotto.Data.Implementation
{
    /// <summary>
    /// Local JSON Data Repository for raw lotto data
    /// </summary>
    public class LottoJSONRepository : ILottoRepository
    {
        private List<LottoDrawing> _drawings = new List<LottoDrawing>();

        public async Task<List<LottoDrawing>> GetAllDrawings() 
        {
            return await getAllLottoDrawings();
        }

        public async Task<List<LottoDrawing>> GetDrawingsWithNumber(int number, bool includeMegaInSearch) 
        {
            var drawings = await getAllLottoDrawings();

            if (includeMegaInSearch)
            {
                return drawings
                    .Where(d => d.WinningNumbers.Contains(number) || d.Mega == number)
                    .ToList();
            }
            return drawings
                .Where(d => d.WinningNumbers.Contains(number))
                .ToList();
        }

        public async Task<List<LottoDrawing>> GetDrawingsByYear(int year) 
        {
            var drawings = await getAllLottoDrawings();

            return drawings.Where(d => d.Year == year).ToList();
        }

        public async Task<List<LottoDrawing>> GetDrawingsByYearAndMonth(int year, int month) 
        {
            var drawings = await getAllLottoDrawings();

            return drawings
                .Where(d => d.Year == year)
                .Where(d => d.Month == month)
                .ToList();
        }

        // TODO: Need more functions with common queries

        private async Task<List<LottoDrawing>> getAllLottoDrawings() 
        {
            if (_drawings.Count >= 1) 
            {
                return _drawings;
            }

            List<LottoDrawing> data = new List<LottoDrawing>();

            var lottoDrawings = File.ReadAllLines("data.csv");

            foreach (var lottoDrawing in lottoDrawings) 
            {
                string[] numbers = lottoDrawing.Split(',');
                data.Add(new LottoDrawing(
                    numbers[0], 
                    Int32.Parse(numbers[1]),
                    Int32.Parse(numbers[2]),
                    Int32.Parse(numbers[3]),
                    Int32.Parse(numbers[4]),
                    Int32.Parse(numbers[5]),
                    Int32.Parse(numbers[6]),
                    Int32.Parse(numbers[7]),
                    Int32.Parse(numbers[8]),
                    Int32.Parse(numbers[9]),
                    Int32.Parse(numbers[10])));
            }

            _drawings = data;

            return _drawings;
        }
    }
}
