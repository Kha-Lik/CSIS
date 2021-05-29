using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Abstract;
using DAL.Abstract;
using Entities;
using Models;

namespace BLL.Services
{
    public class PurchaseService : ICrudService<PurchaseGetModel, PurchaseCreateUpdateModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PurchaseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PurchaseGetModel>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<PurchaseGetModel>>(await _unitOfWork.PurchaseRepository.GetAllAsync());
        }

        public async Task<PurchaseGetModel> GetByIdAsync(int id)
        {
            return _mapper.Map<PurchaseGetModel>(await _unitOfWork.PurchaseRepository.GetByIdAsync(id));
        }

        public async Task CreateAsync(PurchaseCreateUpdateModel model)
        {
            await _unitOfWork.PurchaseRepository.CreateAsync(_mapper.Map<Purchase>(model));
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(PurchaseCreateUpdateModel model, int id)
        {
            var entity = await _unitOfWork.PurchaseRepository.GetByIdAsync(id);
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