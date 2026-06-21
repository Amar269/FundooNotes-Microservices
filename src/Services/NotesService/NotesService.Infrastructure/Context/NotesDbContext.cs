using Microsoft.EntityFrameworkCore;
using NotesService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotesService.Infrastructure.Context
{
    public class NotesDbContext : DbContext
    {
        public NotesDbContext(DbContextOptions<NotesDbContext> options) : base(options)
        {

        }

        public DbSet<Note> Notes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Note>()
               .HasKey(x => x.NoteId);

            modelBuilder.Entity<Note>()
                .Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(200);

            modelBuilder.Entity<Note>()
                .Property(x => x.Description)
                .HasMaxLength(2000);

            modelBuilder.Entity<Note>()
                .Property(x => x.IsPin)
                .HasDefaultValue(false);

            modelBuilder.Entity<Note>()
                .Property(x => x.IsArchive)
                .HasDefaultValue(false);

            modelBuilder.Entity<Note>()
                .Property(x => x.IsTrash)
                .HasDefaultValue(false);

            base.OnModelCreating(modelBuilder);
            
        }

    }
}
