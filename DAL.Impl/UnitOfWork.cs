using System.Threading.Tasks;
using DAL.Abstract;
using Entities;

namespace DAL.Impl
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CsisDbContext _dbContext;

        public UnitOfWork(
            CsisDbContext dbContext, 
            IRepository<Cosmetic> cosmeticRepository, 
            IRepository<Client> clientRepository, 
            IRepository<Purchase> purchaseRepository, 
            IRepository<Consignment> consignmentRepository
            )
        {
            _dbContext = dbContext;
            CosmeticRepository = cosmeticRepository;
            ClientRepository = clientRepository;
            PurchaseRepository = purchaseRepository;
            ConsignmentRepository = consignmentRepository;
        }

        public IRepository<Cosmetic> CosmeticRepository { get; set; }
        public IRepository<Client> ClientRepository { get; set; }
        public IRepository<Purchase> PurchaseRepository { get; set; }
        public IRepository<Consignment> ConsignmentRepository { get; set; }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}