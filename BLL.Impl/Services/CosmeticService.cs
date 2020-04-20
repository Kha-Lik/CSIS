using System.Collections.Generic;
using AutoMapper;
using BLL.Abstract;
using DAL.Abstract;
using Entities;
using Models;

namespace BLL.Services
{
    public class CosmeticService : ICosmeticService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISerializer _serializer;

        public CosmeticService(IUnitOfWork unitOfWork, IMapper mapper, ISerializer serializer)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _serializer = serializer;
        }

        public IEnumerable<CosmeticModel> GetAll()
        {
            var cosmetics = _unitOfWork.CosmeticRepository.GetAll();

            return _mapper.Map<IEnumerable<CosmeticModel>>(cosmetics);
        }

        public void Create(CosmeticModel cosmetic)
        {
            var entity = _mapper.Map<CosmeticEntity>(cosmetic);
            _unitOfWork.CosmeticRepository.Create(entity);
            _unitOfWork.SaveChanges();
            _unitOfWork.CosmeticRepository.Detach();
        }

        public void Update(CosmeticModel cosmeticModel)
        {
            var entity = _mapper.Map<CosmeticEntity>(cosmeticModel);
            _unitOfWork.CosmeticRepository.Edit(entity);
            _unitOfWork.SaveChanges();
            _unitOfWork.CosmeticRepository.Detach();
        }

        public void Serialize(ICollection<CosmeticModel> cosmeticModels, string path)
        {
            _serializer.Serialize(path, cosmeticModels);
        }

        public ICollection<CosmeticModel> Deserialize(string path)
        {
            var cosmetics = _serializer.Deserialize(path) as ICollection<CosmeticModel>;
            return cosmetics;
        }
    }
}