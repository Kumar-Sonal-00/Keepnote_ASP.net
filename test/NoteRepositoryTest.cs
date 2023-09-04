using Keepnote_Step1.Models;
using Keepnote_Step1.Repository;
using Xunit;

namespace Test
{
    public class NoteRepositoryTest
    {
        private readonly NoteRepository noteRepository;

        public NoteRepositoryTest()
        {
            noteRepository = new NoteRepository();
        }

        [Fact]
        public void AddNoteShouldSuccess()
        {
            Note note = new Note {NoteId=1, NoteTitle= "Technology", NoteContent="ASP.NET Core", NoteStatus= "Completed" };
            noteRepository.AddNote(note);
            Assert.True(noteRepository.Exists(note.NoteId));
        }

        [Fact]
        public void DeleteNoteShouldSuccess()
        {
            Note note = new Note { NoteId = 2, NoteTitle = "Stack", NoteContent = "DOTNET", NoteStatus = "Started" };
            noteRepository.AddNote(note);
            Assert.True(noteRepository.Exists(note.NoteId));

            noteRepository.DeletNote(note.NoteId);
            Assert.False(noteRepository.Exists(note.NoteId));
        }

        [Fact]
        public void GetNotesShouldReturnList()
        {
            Note note1 = new Note { NoteId = 1, NoteTitle = "Technology", NoteContent = "ASP.NET Core", NoteStatus = "Completed" };
            noteRepository.AddNote(note1);

            Note note2 = new Note { NoteId = 2, NoteTitle = "Stack", NoteContent = "DOTNET", NoteStatus = "Started" };
            noteRepository.AddNote(note2);

            var notes = noteRepository.GetNotes();
            Assert.Equal(2, notes.Count);
        }
    }
}
