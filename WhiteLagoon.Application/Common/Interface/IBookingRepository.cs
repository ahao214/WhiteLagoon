using System.Linq.Expressions;
using WhiteLagoon.Domain.Entities;

namespace WhiteLagoon.Application.Common.Interface
{
    public interface IBookingRepository : IBaseRepository<Booking>
    {
        void Update(Booking entity);
        void UpdateStatus(int bookingId, string bookingStatus, int villaNumber);
        void UpdateStripePaymentID(int bookingId, string sessionId, string paymentIntentId);
    }
}
