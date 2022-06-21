namespace Lotto.Models.Dtos.Skips
{
    /// <summary>
    /// Usable object for Skip Data of API's, other services, and UI's
    /// </summary>
    public class SkipDto
    {
        public int Number { get; set; }

        public int TotalDraws { get; set; }
        public int TotalMisses { get; set; }

        public double AverageSkips { get; set; }
        public int MaxSkips { get; set; }
        public int MinSkips { get; set; }
        public int CurrentSkip { get; set; }
        public DateTime LastDrawing { get; set; }

        public string Notes { get; set; }
    }
}
