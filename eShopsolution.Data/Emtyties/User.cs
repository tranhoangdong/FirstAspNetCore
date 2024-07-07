using Microsoft.AspNetCore.Identity;

using System.ComponentModel.DataAnnotations;

namespace eShopSolution.Data.Entities
{
    public class User : IdentityUser<int>
    {
        [Key]
        public int ID { get; set; }
        public string FirstName { get; set; }
        public bool Rememberme { get; set; }
        public string LastName { get; set; }
    }
}