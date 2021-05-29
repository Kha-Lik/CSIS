using System.Collections.Generic;

namespace Models
{
    public class ClientCreateUpdateModel
    {
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public IEnumerable<PurchaseCreateUpdateModel> Purchases { get; set; }
    }
}