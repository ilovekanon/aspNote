using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoBoardDAL.Entities
{
    [Table("attachedfile")]
    public class AttachedFile
    {
        [Key]
        public int id { get; set; }
        public int noteNo { get; set; }
        public int noteId { get; set; }
        public string fileName { get; set; }
    }
}
