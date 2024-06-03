using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Customer
    {
        public Guid Id { get; set; }
        [Required, MinLength(3)]
        public string Name { get; set; }
        [Required,EmailAddress]
        public string Email { get; set; }
        [Required,Phone]
        public string PhoneNumber { get; set; }


    }
}
