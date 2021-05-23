using System.Collections.Generic;

namespace Entities
{
    public class Client : BaseEntity
    {
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public IEnumerable<Purchase> Purchases { get; set; }
    }
}