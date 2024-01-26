using System.Linq.Expressions;
using WhiteLagoon.Domain.Entities;

namespace WhiteLagoon.Application.Common.Interface
{
    public interface IBookingRepository : IBaseRepository<Booking>
    {
        void Update(Booking entity);        
    }
}
