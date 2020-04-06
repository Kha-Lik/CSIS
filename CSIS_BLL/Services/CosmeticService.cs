using System.Collections.Generic;
using AutoMapper;
using CSIS_BLL.Interfaces;
using CSIS_DataAccess;

namespace CSIS_BLL
{
    public class CosmeticService : ICosmeticService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CosmeticService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<CosmeticModel> GetAll()
        {
            var cosmetics = _unitOfWork.CosmeticRepository.GetAll();

            return _mapper.Map<IEnumerable<CosmeticModel>>(cosmetics);
        }

        public void Create(CosmeticModel cosmetic)
        {
            var entity = _mapper.Map<CosmeticEntity>(cosmetic);
            _unitOfWork.CosmeticRepository.Create(entity);
            _unitOfWork.SaveChanges();
            _unitOfWork.CosmeticRepository.Detach();
        }

        public void Update(CosmeticModel cosmeticModel)
        {
            var entity = _mapper.Map<CosmeticEntity>(cosmeticModel);
            _unitOfWork.CosmeticRepository.Edit(entity);
            _unitOfWork.SaveChanges();
            _unitOfWork.CosmeticRepository.Detach();
        }
    }
}