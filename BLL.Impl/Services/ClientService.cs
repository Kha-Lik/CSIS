using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Abstract;
using DAL.Abstract;
using Entities;
using Models;

namespace BLL.Services
{
    public class ClientService : ICrudService<ClientModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ClientService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ClientModel>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<ClientModel>>(await _unitOfWork.ClientRepository.GetAllAsync());
        }

        public async Task<ClientModel> GetByIdAsync(int id)
        {
            return _mapper.Map<ClientModel>(await _unitOfWork.ClientRepository.GetByIdAsync(id));
        }

        public async Task CreateAsync(ClientModel model)
        {
            await _unitOfWork.ClientRepository.CreateAsync(_mapper.Map<Client>(model));
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(ClientModel model)
        {
            var entity = await _unitOfWork.ClientRepository.GetByIdAsync(model.Id);
            _mapper.Map(model, entity);
            _unitOfWork.ClientRepository.Edit(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var entity = await _unitOfWork.ClientRepository.GetByIdAsync(id);
            _unitOfWork.ClientRepository.Delete(entity);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}