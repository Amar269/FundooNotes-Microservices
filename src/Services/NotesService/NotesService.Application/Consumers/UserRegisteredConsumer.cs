using System;
using System.Collections.Generic;
using System.Text;
using SharedLibrary.Contracts.Events;
using NotesService.Application.Interfaces;
using NotesService.Domain.Entities;

namespace NotesService.Application.Consumers;

public class UserRegisteredConsumer
{
    private readonly INoteRepository _noteRepository;

    public UserRegisteredConsumer(INoteRepository noteRepository)
    {
        _noteRepository = noteRepository;
    }

    public async Task Consume(UserRegisteredEvent message)
    {
        var welcomeNote = new Note
        {
            UserId = message.UserId,

            Title = "Welcome to Fundoo Notes",

            Description = "Welcome aboard! This note was created automatically for you. Start organizing your ideas, reminders and important tasks here. Happy Note Taking!",

            Color = "Yellow",

            Reminder = DateTime.UtcNow.AddDays(7),

            IsPin = true,

            IsArchive = false,

            IsTrash = false
        };

        await _noteRepository.CreateNoteAsync(welcomeNote);
    }
}