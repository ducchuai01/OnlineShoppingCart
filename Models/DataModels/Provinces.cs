using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShoppingCart.Models
{
    [Table("Provinces")]
    public class Provinces
    {
        [Key]
        [Required]
        [Column(TypeName = "nvarchar(20)")]
        [StringLength(20)]
        public string code { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(255)")]
        [StringLength(255)]
        public string name { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        [StringLength(255)]
        public string name_en { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(255)")]
        [StringLength(255)]
        public string full_name { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        [StringLength(255)]
        public string full_name_en { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        [StringLength(255)]
        public string code_name { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        [StringLength(255)]
        public string administrative_unit_id { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        [StringLength(255)]
        public string administrative_region_id { get; set; }
        public Administrative_units Administrative_Units { get; set; }
        public Administrative_regions Administrative_Regions { get; set; }

        public ICollection<Districts> Districts { get; set; }

        public ICollection<Users> Users { get; set; }
    }
}
