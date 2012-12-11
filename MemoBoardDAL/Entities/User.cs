using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoBoardDAL.Entities
{
    [Table("user")]
    public class User
    {
        [Key]
        public int id { get; set; }
        public string userId { get; set; }
        public string passwd { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
    }
}
