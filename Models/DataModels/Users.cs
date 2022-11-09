using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShoppingCart.Models
{
    [Table("Users")]

    public class Users
    {
    
        [Key]
        [Required]
        [StringLength(36)]
        [DisplayName("User ID")]
        public Guid UserID { get; set; }
        [Required]
        [StringLength(100)]
        [DisplayName("Full Name")]
        [Column(TypeName = ("nvarchar(100)"))]
        public string FullName { get; set; }
        [StringLength(50)]
        [DisplayName("User Name")]
        [Column(TypeName = ("nvarchar(50)"))]
        public string UserName { get; set; }
        [MaxLength]
        [DisplayName("Password")]
        [Column(TypeName = ("nvarchar(max)"))]
        public string Password { get; set; }
        [DisplayName("Birthday")]
        public DateTime Birthday { get; set; }
        [DisplayName("Gender")]
        public bool Gender { get; set; }
        [MaxLength]
        [EmailAddress(ErrorMessage = "The email format is not valid")]
        [DisplayName("Email")]
        public string Email { get; set; }
        [Required]
        [StringLength(15)]
        [Phone(ErrorMessage = "The phone format is not valid")]
        [DisplayName("Telephone")]
        public string Phone { get; set; }
        [DisplayName("Address")]
        public string provinces_code { get; set; }
        [DisplayName("Role")]
        public int Role { get; set; }
        [DisplayName("Created At")]
        [Required]
        public DateTime Created_at { get; set; }
        [DisplayName("Updated At")]
        [Required]
        public DateTime Updated_at { get; set; }
        public Provinces Provinces { get; set; }
        public ICollection<FeedBacks> FeedBack { get; set; }
    }
}
