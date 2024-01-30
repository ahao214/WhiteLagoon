using WhiteLagoon.Application.Common.Interface;
using WhiteLagoon.Application.Services.Interface;
using WhiteLagoon.Domain.Entities;

namespace WhiteLagoon.Application.Services.Implementation
{
    public class VillaNumberService : IVillaNumberService
    {

        private readonly IUnitOfWork _unitOfWork;

        public VillaNumberService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CreateVillaNumber(VillaNumber villaNumber)
        {
            throw new NotImplementedException();
        }

        public bool DeleteVillaNumber(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VillaNumber> GetAllVilla()
        {
            return _unitOfWork.VillaNumber.GetAll();
        }

        public VillaNumber GetVillaNumberById(int id)
        {
            return _unitOfWork.VillaNumber.Get(u => u.VillaNo == id);
        }

        public void UpdateVillaNumber(VillaNumber villaNumber)
        {
            throw new NotImplementedException();
        }
    }
}
