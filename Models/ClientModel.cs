using System.Collections.Generic;

namespace Models
{
    public class ClientModel : BaseModel
    {
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public IEnumerable<PurchaseModel> Purchases { get; set; }
    }
}