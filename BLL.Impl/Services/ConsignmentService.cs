using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Abstract;
using DAL.Abstract;
using Entities;
using Models;

namespace BLL.Services
{
    public class ConsignmentService : ICrudService<ConsignmentGetModel, ConsignmentCreateUpdateModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ConsignmentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ConsignmentGetModel>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<ConsignmentGetModel>>(await _unitOfWork.ConsignmentRepository.GetAllAsync());
        }

        public async Task<ConsignmentGetModel> GetByIdAsync(int id)
        {
            return _mapper.Map<ConsignmentGetModel>(await _unitOfWork.ConsignmentRepository.GetByIdAsync(id));
        }

        public async Task CreateAsync(ConsignmentCreateUpdateModel model)
        {
            await _unitOfWork.ConsignmentRepository.CreateAsync(_mapper.Map<Consignment>(model));
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(ConsignmentCreateUpdateModel model, int id)
        {
            var entity = await _unitOfWork.ConsignmentRepository.GetByIdAsync(id);
            _mapper.Map(model, entity);
            if (entity.Units == 0) await DeleteByIdAsync(entity.Id);
            else
            {
                _unitOfWork.ConsignmentRepository.Edit(entity);
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public async Task DeleteByIdAsync(int id)
        {
            var entity = await _unitOfWork.ConsignmentRepository.GetByIdAsync(id);
            _unitOfWork.ConsignmentRepository.Delete(entity);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}