namespace Lotto.Models.Dtos.LottoDrawings
{
    /// <summary>
    /// Usable object for Lotto Drawings of API's, other services, and UI's
    /// </summary>
    public class LottoDrawingsDto
    {
        public string LottoName { get; set; } = String.Empty;
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
        public List<int> WinningNumbers { get; set; } = new List<int>();
        public DateTime Date { get; set; }
    }
}
