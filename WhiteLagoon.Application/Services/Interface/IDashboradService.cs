using WhiteLagoon.Application.Common.DTO;

namespace WhiteLagoon.Application.Services.Interface
{
    public interface IDashboradService
    {
        Task<RadialBarChartDTO> GetTotalBookingRadialChartData();
        Task<RadialBarChartDTO> GetRegisteredUserChartData();
        Task<RadialBarChartDTO> GetRevenueChartData();
        Task<PieChartDTO> GetBookingPieChartData();
        Task<LineChartDTO> GetMemberAndBookingLineChartData();
    }
}
