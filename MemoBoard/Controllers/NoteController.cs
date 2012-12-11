using MemoBoard.Models;
using MemoBoardDAL.Concrete;
using MemoBoardDAL.Entities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace MemoBoard.Controllers
{
    public class NoteController : Controller
    {

        private UnitOfWork unitOfWork = new UnitOfWork();

        //
        // GET: /Note/

        public ActionResult Index()
        {
            //var notes = unitOfWork.NoteRepository.Get(includeProperties: "AttachedFiles");
            var notes = unitOfWork.NoteRepository.GetNotes();
            return View(new NoteViewModel(){noteList=notes.ToList(), note = new Note()});
        }

        [HttpPost]
        public ActionResult Index(Note note, HttpPostedFileBase attFile)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (note.id > 0)
                    {
                        unitOfWork.NoteRepository.UpdateNote(note);
                    }
                    else
                    {
                        unitOfWork.NoteRepository.InsertNote(note);
                    }
                    updateAttachFile(note, attFile);
                    unitOfWork.Save();
                    return RedirectToAction("Index");
                }
            }catch(DataException){
                ModelState.AddModelError("", "Unable to save changes. Try again please");
            }

            var notes = unitOfWork.NoteRepository.GetNotes();
            return View(new NoteViewModel() { noteList = notes.ToList(), note = new Note() });
        }

        private void updateAttachFile(Note note,HttpPostedFileBase attFile)
        {
            if (attFile == null) return;

            List<AttachedFile> list = new List<AttachedFile>();

            var fileName = Path.GetFileName(attFile.FileName);
            fileName = fileName.Replace(" ", "");
            fileName = Regex.Replace(fileName, @"\s|\$|\#\%", "");
            var path = Path.Combine(Server.MapPath("~/App_data/uploads"), fileName);
            attFile.SaveAs(path);

            list.Add(new AttachedFile
            {
                fileName = fileName
            });

            note.AttachedFiles = list;
        }

        [HttpPost]
        public ActionResult DeleteNote(int noteId)
        {
            unitOfWork.NoteRepository.DeleteNote(noteId);
            var attFileList = unitOfWork.AttachedFileRepository.Get(filter: q => q.noteId.Equals(noteId)).ToList();

            foreach (AttachedFile files in attFileList)
            {
                unitOfWork.AttachedFileRepository.Delete(files);
            }

            unitOfWork.Save();
            return RedirectToAction("Index");
        }
    }
}
