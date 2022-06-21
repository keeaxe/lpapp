using Lotto.Models.Dtos.LottoDrawings;
using Lotto.Models.LottoDrawings;

namespace Lotto.Services.Mappers
{
    /// <summary>
    /// Database object to DTO mapper extensions functions
    /// </summary>
    public static class ModelToDtoMappers
    {
        /// <summary>
        /// MAp LottoDrawing to LottoDrawingsDto
        /// </summary>
        /// <param name="drawings"></param>
        /// <returns></returns>
        public static List<LottoDrawingsDto> Map(this List<LottoDrawing> drawings)
        {
            return drawings.Select(drawing => { 
                return new LottoDrawingsDto() 
                { 
                    Day = drawing.Day,
                    LottoName = drawing.LottoName,
                    Mega = drawing.Mega,
                    Megaplier = drawing.Megaplier,
                    Month = drawing.Month,
                    Number1 = drawing.Number1,
                    Number2 = drawing.Number2,
                    Number3 = drawing.Number3,
                    Number4 = drawing.Number4,
                    Number5 = drawing.Number5,
                    WinningNumbers = drawing.WinningNumbers,
                    Year = drawing.Year, 
                    Date = new DateTime(drawing.Year, drawing.Month, drawing.Day)
                }; 
            }).ToList();
        }
    }
}
