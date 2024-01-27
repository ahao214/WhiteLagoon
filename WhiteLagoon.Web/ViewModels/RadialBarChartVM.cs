namespace WhiteLagoon.Web.ViewModels
{
    public class RadialBarChartVM
    {
        public decimal TotalCount { get; set; }
        public decimal IncreasdDecreaseAmount { get; set; }
        public bool HasRatioIncreased { get; set; }
        public decimal[] Series { get; set; }

    }
}
