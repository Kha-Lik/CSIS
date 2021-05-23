using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Abstract;
using DAL.Abstract;
using Entities;
using Models;

namespace BLL.Services
{
    public class CosmeticService : ICrudService<CosmeticModel>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CosmeticService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CosmeticModel>> GetAllAsync()
        {
            var cosmetics = await _unitOfWork.CosmeticRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<CosmeticModel>>(cosmetics);
        }

        public async Task<CosmeticModel> GetByIdAsync(int id)
        {
            return _mapper.Map<CosmeticModel>(await _unitOfWork.CosmeticRepository.GetByIdAsync(id));
        }

        public async Task CreateAsync(CosmeticModel model)
        {
            var entity = _mapper.Map<Cosmetic>(model);
            await _unitOfWork.CosmeticRepository.CreateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(CosmeticModel model)
        {
            var entity = await _unitOfWork.CosmeticRepository.GetByIdAsync(model.Id);
            _mapper.Map(model, entity);
            _unitOfWork.CosmeticRepository.Edit(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var entity = await _unitOfWork.CosmeticRepository.GetByIdAsync(id);
            _unitOfWork.CosmeticRepository.Delete(entity);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}