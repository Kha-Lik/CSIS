using Microsoft.AspNetCore.Identity;

namespace Entities
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public string SecondName { get; set; }
    }
}