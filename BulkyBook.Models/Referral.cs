using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyBook.Models
{
    public class Referral
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [DisplayName("First Name")]
        public string FName { get; set; }
        [Required]
        [DisplayName("Last Name")]
        public string LName { get; set; }
        [DisplayName("Email")]
        public string? EmailAddress { get; set; }
        [DisplayName("Phone Number")]
        public string? PhoneNumber { get; set; }
        [DisplayName("Street Address")]
        public string? StreetAddress { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        [DisplayName("Postal Code")]
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
    }
}
