using System;
using System.ComponentModel.DataAnnotations;

namespace Keepnote_Step1.Models
{
    public class Note
    {
        /*
        This class should have five properties (noteId, noteTitle, noteContent,
        noteStatus and createdAt).The value of createdAt should not be accepted from
        the user but should be always initialized with the system date.

        NoteId - int
        NoteTitle - string
        NoteContent - string
        NoteStatus - string
        CreatedAt - DateTime

       */
        public int NoteId { get; set; }
        public string NoteTitle { get; set; }
        public string NoteContent { get; set; }
        public string NoteStatus { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }
}
