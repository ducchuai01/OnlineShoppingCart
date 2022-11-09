using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShoppingCart.Models
{
    [Table("Wards")]
    public class Wards
    {
        [Key]
        [Required]
        [StringLength(20)]
        [Column(TypeName = "nvarchar(20)")]
        public string code { get; set; }
        [Required]
        [StringLength(255)]
        [Column(TypeName = "nvarchar(255)")]
        public string name { get; set; }
        [StringLength(255)]
        [Column(TypeName = "nvarchar(255)")]
        public string name_en { get; set; }
        [StringLength(255)]
        [Column(TypeName = "nvarchar(255)")]
        public string full_name { get; set; }
        [StringLength(255)]
        [Column(TypeName = "nvarchar(255)")]
        public string full_name_en { get; set; }
        [StringLength(255)]
        [Column(TypeName = "nvarchar(255)")]
        public string code_name { get; set; }
        [StringLength(255)]
        [Column(TypeName = "nvarchar(255)")]
        public string district_code { get; set; }
        [StringLength(255)]
        [Column(TypeName = "nvarchar(255)")]
        public string administrative_unit_id { get; set; }

        public Administrative_units Administrative_Units { get; set; }
        public Districts Districts { get; set; }
    }
}
