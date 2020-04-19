using System.Collections.Generic;
using AutoMapper;
using CSIS_BLL.Interfaces;
using CSIS_BusinessLogic;
using CSIS_DataAccess;

namespace CSIS_BLL
{
    public class CosmeticUsedSlowlyService : ICosmeticUsedSlowlyService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CosmeticUsedSlowlyService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<CosmeticUsedSlowlyModel> GetAll()
        {
            var cosmetics = _unitOfWork.CosmeticUsedSlowlyRepository.GetAll();
            return _mapper.Map<IEnumerable<CosmeticUsedSlowlyModel>>(cosmetics);
        }

        public void Create(CosmeticUsedSlowlyModel cosmetic)
        {
            var entity = _mapper.Map<CosmeticUsedSlowlyEnity>(cosmetic);
            _unitOfWork.CosmeticUsedSlowlyRepository.Create(entity);
        }
    }
}