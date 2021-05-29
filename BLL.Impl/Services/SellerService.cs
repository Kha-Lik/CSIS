using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Abstract;
using DAL.Abstract;
using Entities;
using Models;

namespace BLL.Services
{
    public class SellerService : ISellerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SellerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task SellCosmeticsToClient(int clientId, int cosmeticId, int units)
        {
            var clientModel = _mapper.Map<ClientGetModel>(await _unitOfWork.ClientRepository.GetByIdAsync(clientId));
            var cosmeticModel = _mapper.Map<CosmeticGetModel>(await _unitOfWork.CosmeticRepository.GetByIdAsync(cosmeticId));
            
            var consignments = (await _unitOfWork.ConsignmentRepository.GetAllAsync())
                                                    .Where(c => c.CosmeticId == cosmeticModel.Id).ToList();
            
            var available = consignments.Sum(consignment => consignment.Units);
            if (units > available)
                throw new InvalidOperationException($"There are only {available} units of {cosmeticModel.Name} at storage");
            
            var purchase = new PurchaseGetModel
            {
                ClientGet = clientModel,
                ClientId = clientModel.Id,
                CosmeticGetGet = cosmeticModel,
                CosmeticId = cosmeticModel.Id,
                PurchaseDate = DateTime.Today,
                Units = units
            };
            
            foreach (var consignment in consignments)
            {
                if (consignment.Units < units)
                {
                    units = units - consignment.Units;
                    consignment.Units = 0;
                }
                else
                {
                    consignment.Units -= units;
                }
            }

            await _unitOfWork.PurchaseRepository.CreateAsync(_mapper.Map<Purchase>(purchase));

            foreach (var consignment in consignments)
            {
                _unitOfWork.ConsignmentRepository.Edit(_mapper.Map<Consignment>(consignment));
            }

            await _unitOfWork.SaveChangesAsync();
        }
    }
}