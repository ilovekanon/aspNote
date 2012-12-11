using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MemoBoardDAL.Entities;

namespace MemoBoardDAL.Concrete
{
    public class NoteContext : DbContext
    {
        public DbSet<Note> Notes { get; set; }
        public DbSet<AttachedFile> AttachedFiles { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
