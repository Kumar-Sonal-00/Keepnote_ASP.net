﻿using System.Collections.Generic;
using Keepnote_Step1.Controllers;
using Keepnote_Step1.Models;
using Keepnote_Step1.Repository;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Test
{
    public class NoteControllerTest
    {
        [Fact]
        public void GetShouldReturnListOfNotes()
        {
            var mockRepo = new Mock<INoteRepository>();
            mockRepo.Setup(repo => repo.GetNotes()).Returns(this.notes);
            var noteController = new NoteController(mockRepo.Object);

            var actual = noteController.Index();

            var actionResult = Assert.IsType<ViewResult>(actual);
            Assert.IsAssignableFrom<IEnumerable<Note>>(actionResult.ViewData.Model);
        }

        [Fact]
        public void CreateShouldReturnListOfNotes_ModelIsValid()
        {
            var note = new Note { NoteId = 1, NoteTitle = "Technology", NoteContent = "ASP.NET Core", NoteStatus = "Completed" };
            var mockRepo = new Mock<INoteRepository>();
            mockRepo.Setup(repo => repo.AddNote(note));
            var noteController = new NoteController(mockRepo.Object);

            var actual = noteController.Create(note);

            var actionResult = Assert.IsType<RedirectToActionResult>(actual);
            Assert.Null(actionResult.ControllerName);
            Assert.Equal("Index", actionResult.ActionName);
        }

        [Fact]
        public void CreateShouldReturn_ModelIsInValid()
        {
            var note = new Note { NoteId = 1, NoteContent = "ASP.NET Core", NoteStatus = "Completed" };
            var mockRepo = new Mock<INoteRepository>();
            mockRepo.Setup(repo => repo.AddNote(note));
            var noteController = new NoteController(mockRepo.Object);
            noteController.ModelState.AddModelError("NoteTitle", "Required");

            var actual = noteController.Create(note);

            var actionResult = Assert.IsType<ViewResult>(actual);
            Assert.IsAssignableFrom<Note>(actionResult.ViewData.Model);
            Assert.Same(actionResult.ViewData.Model, note);
        }

        [Fact]
        public void DeleteShouldReturnToIndex()
        {
            int noteId = 1;
            var mockRepo = new Mock<INoteRepository>();
            mockRepo.Setup(repo => repo.DeletNote(noteId)).Returns(true);
            var noteController = new NoteController(mockRepo.Object);

            var actual = noteController.Delete(noteId);

            var actionResult = Assert.IsType<RedirectToActionResult>(actual);
            Assert.Null(actionResult.ControllerName);
            Assert.Equal("Index", actionResult.ActionName);
        }

        private readonly List<Note> notes = new List<Note> {
            new Note {NoteId=1, NoteTitle= "Technology", NoteContent="ASP.NET Core", NoteStatus= "Completed" },
            new Note { NoteId = 2, NoteTitle = "Stack", NoteContent = "DOTNET", NoteStatus = "Started" }
    };
    }
}
