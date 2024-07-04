using Microsoft.AspNetCore.Identity;

using System.ComponentModel.DataAnnotations;

namespace eShopSolution.Data.Entities
{
    public class User : IdentityUser
    {
        [Key]
        public int ID { get; set; }
        public override string UserName
        {
            get => base.UserName; 
            set => base.UserName = value;
        }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}