using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using MemoBoardDAL.Abstract;
using MemoBoardDAL.Entities;


namespace MemoBoardDAL.Concrete
{
    public class NoteRepository : INoteRepository, IDisposable
    {
        private NoteContext context;

        public NoteRepository(NoteContext context){
            this.context = context;
        }

        public IEnumerable<Note> GetNotes(){
            return context.Notes.ToList();
        }

        public Note GetNoteByID(int id){
            return context.Notes.Find(id);
        }

        public void InsertNote(Note note){
            context.Notes.Add(note);
        }

        public void DeleteNote(int id){
            Note note = context.Notes.Find(id);
            context.Notes.Remove(note);
        }

        public void UpdateNote(Note note){
            context.Entry(note).State = EntityState.Modified;
        }

        public void Save() {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose (bool disposing){
            if(!this.disposed){
                if(disposing){
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose(){
            Dispose(true);
            GC.SuppressFinalize(this);
        }


    }
}
