using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Abstract;
using DAL.Abstract;
using Entities;
using Models;

namespace BLL.Services
{
    public class ConsignmentService : ICrudService<ConsignmentModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ConsignmentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ConsignmentModel>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<ConsignmentModel>>(await _unitOfWork.ConsignmentRepository.GetAllAsync());
        }

        public async Task<ConsignmentModel> GetByIdAsync(int id)
        {
            return _mapper.Map<ConsignmentModel>(await _unitOfWork.ConsignmentRepository.GetByIdAsync(id));
        }

        public async Task CreateAsync(ConsignmentModel model)
        {
            await _unitOfWork.ConsignmentRepository.CreateAsync(_mapper.Map<Consignment>(model));
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(ConsignmentModel model)
        {
            var entity = await _unitOfWork.ConsignmentRepository.GetByIdAsync(model.Id);
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