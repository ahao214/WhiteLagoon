using Microsoft.AspNetCore.Mvc;
using WhiteLagoon.Application.Common.Interface;
using WhiteLagoon.Domain.Entities;

namespace WhiteLagoon.Web.Controllers
{
    public class BookingController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookingController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult FinalizeBooking(int villaId, DateOnly checkInDate, int nights)
        {
            Booking booking = new Booking()
            {
                VillaId = villaId,
                Villa = _unitOfWork.Villa.Get(u => u.Id == villaId, includeProperties: "VillaAmenity"),
                CheckInDate = checkInDate,
                Nights = nights,
                CheckOutDate = checkInDate.AddDays(nights),
            };
            booking.TotalCost = booking.Villa.Price * nights;
            return View(booking);
        }
    }
}
