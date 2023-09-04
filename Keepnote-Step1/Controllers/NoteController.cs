using Keepnote_Step1.Models;
using Keepnote_Step1.Repository;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Keepnote_Step1.Controllers
{
    public class NoteController : Controller
    {

        private readonly INoteRepository _noteRepository;

        public NoteController(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        // Display the list of existing notes
        public IActionResult Index()
        {
            var notes = _noteRepository.GetNotes();
            return View(notes);
        }
        // Add a new note (GET action)
        
        public IActionResult Create()
        {
            return View();
        }

        // Add a new note
        [HttpPost]
        public IActionResult Create(Note note)
        {
            if (note == null)
            {
                throw new ArgumentNullException(nameof(note));
            }

            // Populate CreatedAt with system time
            note.CreatedAt = DateTime.Now;

            _noteRepository.AddNote(note);

            // Redirect to the list of notes
             return RedirectToAction("Index");
            //return View(note);
        }
        

        // Delete an existing note
        public IActionResult Delete(int noteId)
        {
            if (_noteRepository.DeletNote(noteId))
            {
                return RedirectToAction("Index");
            }
            return NotFound();
        }


        /*
          * From the problem statement, we can understand that the application
          * requires us to implement the following functionalities.
          * 
          * 1. display the list of existing notes from the collection. Each note 
          *    should contain Note Id, title, content, status and created date.
          * 2. Add a new note which should contain the note id, title, content and status.
          * 3. Delete an existing note.
      */

        /* 
         * Retrieve the NoteRepository object from the dependency Container through constructor Injection.
         */


        /*Define a handler method to read the existing notes by calling the GetNotes() method 
         * of the NoteRepository class and pass to view. it should map to the default URL i.e. "/" */


        /*Define a handler method which will read the Note data from request parameters and
         * save the note by calling the AddNote() method of NoteRepository class. Please note 
         * that the createdAt field should always be auto populated with system time and should not be accepted 
         * from the user. Also, after saving the note, it should show the same along with existing 
         * notes.  
        */


        /* Define a handler method to delete an existing note by calling the DeleteNote() method 
         * of the NoteRepository class
        */

    }
}