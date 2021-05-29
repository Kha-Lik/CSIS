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

        public async Task<IEnumerable<CosmeticGetModel>> GetFiltered()
        {
            var consignments = await _unitOfWork.ConsignmentRepository.GetAllAsync();
            var consignmentModels = _mapper.Map<IEnumerable<ConsignmentGetModel>>(consignments).ToList();
            var cosmetics = consignmentModels.Select(c => c.CosmeticGetGet).Distinct().ToList();

            var filtered = consignmentModels.Where(x => x.IsEnding).Select(c => c.CosmeticGetGet).Distinct().ToList();
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
                x.CosmeticGetGet.DeliveryTime >= (x.ProductionDate.AddDays(x.CosmeticGetGet.ShelfLife) - DateTime.Today).Days).Select(c => c.CosmeticGetGet));

            return filtered.Distinct();
        }

        public void SetMinLeftAmount(int amount)
        {
            _minLeftAmount = amount;
        }
    }
}