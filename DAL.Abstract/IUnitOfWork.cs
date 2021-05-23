using System.Threading.Tasks;
using Entities;

namespace DAL.Abstract
{
    public interface IUnitOfWork
    {
        public IRepository<Cosmetic> CosmeticRepository { get; }
        public IRepository<Client> ClientRepository { get; set; }
        public IRepository<Purchase> PurchaseRepository { get; set; }
        public IRepository<Consignment> ConsignmentRepository { get; set; }
        Task SaveChangesAsync();
    }
}