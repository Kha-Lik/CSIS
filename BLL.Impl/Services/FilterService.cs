using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Abstract;
using DAL.Abstract;
using Models;

namespace BLL.Services
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

        public async Task<IEnumerable<CosmeticModel>> GetFiltered()
        {
            var consignments = await _unitOfWork.ConsignmentRepository.GetAllAsync();
            var consignmentModels = _mapper.Map<IEnumerable<ConsignmentModel>>(consignments).ToList();
            var cosmetics = consignmentModels.Select(c => c.Cosmetic).Distinct().ToList();

            var filtered = consignmentModels.Where(x => x.IsEnding).Select(c => c.Cosmetic).Distinct().ToList();
            filtered.AddRange(
                from cosmeticModel 
                in cosmetics 
                let available = consignments
                    .Where(c => c.CosmeticId == cosmeticModel.Id)
                    .Sum(c => c.Units) 
                where available <= _minLeftAmount 
                select cosmeticModel
                );
            filtered.AddRange(consignmentModels.Where(x => 
                x.Cosmetic.DeliveryTime >= (x.ProductionDate.AddDays(x.Cosmetic.ShelfLife) - DateTime.Today).Days).Select(c => c.Cosmetic));

            return filtered.Distinct();
        }

        public void SetMinLeftAmount(int amount)
        {
            _minLeftAmount = amount;
        }
    }
}