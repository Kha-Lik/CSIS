using System.Collections.Generic;

namespace Models
{
    public class ClientGetModel : BaseGetModel
    {
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public IEnumerable<PurchaseGetModel> Purchases { get; set; }
    }
}