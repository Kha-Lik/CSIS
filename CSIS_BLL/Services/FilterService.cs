using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CSIS_BLL.Interfaces;
using CSIS_BusinessLogic;
using CSIS_DataAccess;

namespace CSIS_BLL
{
    public class FilterService : IFilterService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private int _minLeftAmount = 3; //amount of cosmetics at storage when need to order
        
        public IEnumerable<CosmeticModel> GetFiltered()
        {
            var filtered = new List<CosmeticModel>();
            filtered.AddRange(GetFilteredCosmetics());
            filtered.AddRange(GetFilteredUsedSlowly());
            return filtered;
        }

        private IEnumerable<CosmeticModel> GetFilteredCosmetics()
        {
            var cosmetics = _mapper.Map<IEnumerable<CosmeticModel>>(_unitOfWork.CosmeticRepository.GetAll());

            return cosmetics.Where(c => c.Units <= _minLeftAmount).ToList();
        }

        private IEnumerable<CosmeticUsedSlowlyModel> GetFilteredUsedSlowly()
        {
            var cosmetics = _mapper.Map<IEnumerable<CosmeticUsedSlowlyModel>>(
                _unitOfWork.CosmeticUsedSlowlyRepository.GetAll());
            
            List<CosmeticUsedSlowlyModel> filteredCosmetics;
            filteredCosmetics = cosmetics.Where(c => c.IsEnding).ToList();
            filteredCosmetics.AddRange(cosmetics.Where(c => c.ShelfLife <= c.DeliveryTime - c.UsingTime).ToList());
            filteredCosmetics.AddRange(cosmetics.Where(c => c.Units <= _minLeftAmount));
            
            return filteredCosmetics.Distinct();
        }

        public void SetMinLeftAmount(int amount) => _minLeftAmount = amount;
    }
}