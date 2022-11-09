using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShoppingCart.Models
{
    [Table("FeedBacks")]
    public class FeedBacks
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("FeedBack ID")]
        public int FeedBackID { get; set; }
        [Required]
        public string UserID { get; set; }
        public Users Users { get; set; }

        [DisplayName("Datetime Send")]
        public DateTime DateSend { get; set; }
        [DisplayName("Title")]
        [Column(TypeName = "ntext")]
        public string Title { get; set; }
        [DisplayName("Created At")]
        public DateTime Created_at { get; set; }
    }
}
