using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoBoardDAL.Entities
{
    [Table("note")]
    public class Note
    {
        [Key]
        public int id { get; set; }
        
        [Required(ErrorMessage="Content is required")]
        [DisplayName("Note")]
        public string content { get; set; }
        public DateTime date { get; set; }

        [Required(ErrorMessage = "User ID is required")]
        [DisplayName("User ID")]
        public string userId {get; set;}
        public Boolean isPrivate { get; set; }
        
        [DisplayName("Attach File")]
        public virtual ICollection<AttachedFile> AttachedFiles { get; set; }

    }
}
