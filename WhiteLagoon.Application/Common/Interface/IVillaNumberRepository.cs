using WhiteLagoon.Domain.Entities;

namespace WhiteLagoon.Application.Common.Interface
{
    public interface IVillaNumberRepository : IBaseRepository<VillaNumber>
    {
        void Update(VillaNumber entity);
    }
}
