using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime;

namespace WebAppSano.Models
{

    [Table("Productstable")]
    public class ProductsModel
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Qty { get; set; }

        [Required]
        public int EpiryDate { get; set; }
    }
}
