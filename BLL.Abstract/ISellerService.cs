using System.Threading.Tasks;
using Models;

namespace BLL.Abstract
{
    public interface ISellerService
    {
        Task SellCosmeticsToClient(int clientId, int cosmeticId, int units);
    }
}