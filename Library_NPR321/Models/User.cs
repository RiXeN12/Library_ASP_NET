using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Library_NPR321.Models
{
    public class User : IdentityUser
    {
        [MaxLength(100)]
        public string? FirstName { get; set; }
        [MaxLength(100)]
        public string? LastName { get; set; }
        [MaxLength]
        public string? Image { get; set; } = "~/uploads/default-avatar.png";


        public void SetDefaultImage()
        {
            Image = "~/uploads/default-avatar.png";
        }

        public void RemoveImage()
        {
            Image = null;
        }
    }
}
