using System.Collections.Generic;
using Keepnote_Step1.Models;

namespace Keepnote_Step1.Repository
{
    public interface INoteRepository
    {
        void AddNote(Note note);
        bool DeletNote(int noteId);
        bool Exists(int noteId);
        List<Note> GetNotes();
    }
}