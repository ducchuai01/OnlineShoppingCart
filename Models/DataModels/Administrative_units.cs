using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShoppingCart.Models
{
    [Table("Administrative_units")]
    public class Administrative_units
    {
        [Key]
        [Required]
        public int id { get; set; }
        [StringLength(255)]
        [Column(TypeName = "nvarchar(255)")]
        public string full_name { get; set; }
        [StringLength(255)]
        [Column(TypeName = "nvarchar(255)")]
        public string full_name_en { get; set; }
        [StringLength(255)]
        [Column(TypeName = "nvarchar(255)")]
        public string short_name { get; set; }
        [StringLength(255)]
        [Column(TypeName = "nvarchar(255)")]
        public string short_name_en { get; set; }
        [StringLength(255)]
        [Column(TypeName = "nvarchar(255)")]
        public string code_name { get; set; }
        [StringLength(255)]
        [Column(TypeName = "nvarchar(255)")]
        public string code_name_en { get; set; }
        public ICollection<Provinces> Provinces { get; set; }
        public ICollection<Districts> Districts { get; set; }
        public ICollection<Wards> Wards { get; set; }
    }
}
