using System.ComponentModel.DataAnnotations;
using System.Reflection.PortableExecutable;

namespace WebAppSano.Models
{
    public class UsersModel
    {
        [Key]
        public int ID { get; set; }  // pk and auto incr
        public string Name { get; set; }
        public string EMail { get; set; }
        public string Password { get; set; }
        public DateTime DoB { get; set; }
   
    }
}
