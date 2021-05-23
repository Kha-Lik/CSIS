using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Abstract;
using DAL.Abstract;
using Entities;
using Models;

namespace BLL.Services
{
    public class PurchaseService : ICrudService<PurchaseModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PurchaseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PurchaseModel>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<PurchaseModel>>(await _unitOfWork.PurchaseRepository.GetAllAsync());
        }

        public async Task<PurchaseModel> GetByIdAsync(int id)
        {
            return _mapper.Map<PurchaseModel>(await _unitOfWork.PurchaseRepository.GetByIdAsync(id));
        }

        public async Task CreateAsync(PurchaseModel model)
        {
            await _unitOfWork.PurchaseRepository.CreateAsync(_mapper.Map<Purchase>(model));
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(PurchaseModel model)
        {
            var entity = await _unitOfWork.PurchaseRepository.GetByIdAsync(model.Id);
            _mapper.Map(model, entity);
            _unitOfWork.PurchaseRepository.Edit(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var entity = await _unitOfWork.PurchaseRepository.GetByIdAsync(id);
            _unitOfWork.PurchaseRepository.Delete(entity);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}