using System.Collections.Generic;
using Keepnote_Step1.Models;
using System.Linq;
using System;

namespace Keepnote_Step1.Repository
{
    /*
      This class contains the code for data storage interactions and methods 
      of this class will be used by other parts of the applications such
      as Controllers and Test Cases
      */
    public class NoteRepository : INoteRepository
    {
        /* Declare a variable of List type to store all the notes. */
        private readonly List<Note> _notes = new List<Note>();

        public NoteRepository()
        {
            /* Initialize the variable using proper data type */
        }

        /* This method should return all the notes in the list */
        public List<Note> GetNotes()
        {
            return _notes.OrderByDescending(note => note.CreatedAt).ToList();
        }

        /*
	        This method should accept Note object as argument and add the new note object into  list
	    */
        public void AddNote(Note note)
        {
            if (note == null)
            {
                throw new ArgumentNullException(nameof(note));
            }

            // Generate a unique NoteId (you may use a more robust method)
            note.NoteId = _notes.Count + 1;
            _notes.Add(note);
        }

        /* This method should deleted a specified note from the list */
        public bool DeletNote(int noteId)
        {
            var noteToRemove = _notes.FirstOrDefault(note => note.NoteId == noteId);
            if (noteToRemove != null)
            {
                _notes.Remove(noteToRemove);
                return true;
            }
            return false;
        }

        /*
	      This method should check if the matching note id present in the list or not.
	      Return true if note id exists in the list or return false if note id does not
	      exists in the list
	  */
        public bool Exists(int noteId)
        {
            return _notes.Any(note => note.NoteId == noteId);
        }
    }

}
