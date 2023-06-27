using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static Formula1Store.Domain.Common.DataConstants.User;

namespace Formula1Store.Domain.Models
{
    public class User : IdentityUser
    {
        public User()
        {
            //this.UserOrders = new List<UserOrder>();
        }

        [Required]
        [StringLength(FirstNameMaxLength, MinimumLength = FirstNameMinLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(LastNameMaxLength, MinimumLength = LastNameMinLength)]
        public string LastName { get; set; } = null!;

        //public ICollection<UserOrder> UserOrders { get; set; }
    }
}