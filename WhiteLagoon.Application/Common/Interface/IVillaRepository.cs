using System.Linq.Expressions;
using WhiteLagoon.Domain.Entities;

namespace WhiteLagoon.Application.Common.Interface
{
    public interface IVillaRepository : IBaseRepository<Villa>
    {
        void Update(Villa entity);        
    }
}
