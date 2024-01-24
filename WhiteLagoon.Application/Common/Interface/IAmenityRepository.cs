using System.Linq.Expressions;
using WhiteLagoon.Domain.Entities;

namespace WhiteLagoon.Application.Common.Interface
{
    public interface IAmenityRepository : IBaseRepository<Amenity>
    {
        void Update(Amenity entity);        
    }
}
