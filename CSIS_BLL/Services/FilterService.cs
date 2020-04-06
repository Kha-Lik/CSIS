using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CSIS_BLL.Interfaces;
using CSIS_DataAccess;

namespace CSIS_BLL
{
    public class FilterService : IFilterService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private int _minLeftAmount = 3; //amount of cosmetics at storage when need to order

        public FilterService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<CosmeticModel> GetFiltered()
        {
            var cosmetics = _unitOfWork.CosmeticRepository.GetAll();
            var cosmeticModels = _mapper.Map<IEnumerable<CosmeticModel>>(cosmetics).ToList();
            
            var filtered = cosmeticModels.Where((x => x.IsEnding)).ToList();
            filtered.AddRange(cosmeticModels.Where(x => x.Units <= _minLeftAmount));
            filtered.AddRange(cosmeticModels.Where(x => x.DeliveryTime >= (x.ShelfLife - x.UsingTime)));
            
            return filtered.Distinct();
        }

        public void SetMinLeftAmount(int amount)
        {
            _minLeftAmount = amount;
        }
    }
}