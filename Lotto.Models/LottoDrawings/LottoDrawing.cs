using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotto.Models.LottoDrawings
{
    /// <summary>
    /// Database object for Lotto Drawings
    /// </summary>
    public class LottoDrawing
    {
        public string LottoName { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public int Year { get; set; }
        public int Number1 { get; set; }
        public int Number2 { get; set; }
        public int Number3 { get; set; }
        public int Number4 { get; set; }
        public int Number5 { get; set; }
        public int Mega { get; set; }
        public int Megaplier { get; set; }
        public List<int> WinningNumbers { get; set; }

        public LottoDrawing(
            string lottoName,
            int month,
            int day,
            int year,
            int number1,
            int number2,
            int number3,
            int number4,
            int number5,
            int mega,
            int megaplier)
        { 
            LottoName = lottoName;
            Month = month;
            Day = day;
            Year = year;
            Number1 = number1;
            Number2 = number2;
            Number3 = number3;
            Number4 = number4;
            Number5 = number5;
            Mega = mega;
            Megaplier = megaplier;

            WinningNumbers = new List<int>() 
            {
                Number1, 
                Number2, 
                Number3, 
                Number4, 
                Number5
            };
        }
    }
}
