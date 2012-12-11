using MemoBoardDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MemoBoard.Models
{
    public class NoteViewModel
    {
        public IEnumerable<Note> noteList { get; set; }
        public Note note { get; set; }
    }
}