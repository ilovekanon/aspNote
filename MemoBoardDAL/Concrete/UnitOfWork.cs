using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MemoBoardDAL.Entities;

namespace MemoBoardDAL.Concrete
{
    public class UnitOfWork : IDisposable
    {
        private NoteContext context = new NoteContext();
        private NoteRepository noteRepository;
        private GenericRepository<AttachedFile> attachedFileRepository;
        public NoteRepository NoteRepository
        {
            get
            {
                if(this.noteRepository == null){
                    this.noteRepository = new NoteRepository(context);
                }
                return noteRepository;
            }
        }

        public GenericRepository<AttachedFile> AttachedFileRepository
        {
            get
            {
                if (this.attachedFileRepository == null)
                {
                    this.attachedFileRepository = new GenericRepository<AttachedFile>(context);
                }
                return attachedFileRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
