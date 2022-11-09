using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShoppingCart.Models
{
    [Table("Districts")]
    public class Districts
    {
        [Key]
        [Column(TypeName = "nvarchar(20)")]
        [Required]
        [StringLength(20)]
        public string code { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        [Required]
        [StringLength(255)]
        public string name { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        [StringLength(255)]
        public string name_en { get; set; }
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
        [StringLength(20)]
        public string province_code { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public int administrative_unit_id { get; set; }
        public Administrative_units Administrative_Units { get; set; }
        public Provinces Provinces { get; set; }
        public ICollection<Wards> Wards { get; set; }
    }
}
