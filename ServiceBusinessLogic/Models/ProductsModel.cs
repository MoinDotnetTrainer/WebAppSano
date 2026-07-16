using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBusinessLogic.Models
{
    public class ProductsModel
    {
        [Key]
        public int ID { get; set; }
        public string ProductName { get; set; }
        public int Qty { get; set; }
        public int Price { get; set; }
    }
}
