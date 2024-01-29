using Microsoft.AspNetCore.Mvc;
using Stripe;
using WhiteLagoon.Application.Common.Interface;
using WhiteLagoon.Application.Common.Utility;
using WhiteLagoon.Application.Services.Interface;
using WhiteLagoon.Web.ViewModels;

namespace WhiteLagoon.Web.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IDashboradService _dashboradService;

        public DashboardController(IDashboradService dashboradService)
        {
            _dashboradService = dashboradService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetTotalBookingRadialChartData()
        {
            return Json(await _dashboradService.GetTotalBookingRadialChartData());
        }



        public async Task<IActionResult> GetRegisteredUserChartData()
        {
            return Json(await _dashboradService.GetRegisteredUserChartData());
        }

        public async Task<IActionResult> GetBookingPieChartData()
        {
            return Json(await _dashboradService.GetBookingPieChartData());
        }


        public async Task<IActionResult> GetMemberAndBookingLineChartData()
        {
            return Json(await _dashboradService.GetMemberAndBookingLineChartData());
        }


        public async Task<IActionResult> GetRevenueChartData()
        {
            return Json(await _dashboradService.GetRevenueChartData());
        }




    }
}
