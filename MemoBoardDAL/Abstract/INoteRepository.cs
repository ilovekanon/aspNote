using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MemoBoardDAL.Entities;

namespace MemoBoardDAL.Abstract
{
    public interface INoteRepository : IDisposable
    {
        IEnumerable<Note> GetNotes();
        Note GetNoteByID(int noteId);
        void InsertNote(Note note);
        void DeleteNote(int noteId);
        void UpdateNote(Note note);
        void Save();
    }
}
