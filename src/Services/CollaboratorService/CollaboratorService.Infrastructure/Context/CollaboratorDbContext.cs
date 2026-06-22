using System;
using System.Collections.Generic;
using System.Text;

using CollaboratorService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CollaboratorService.Infrastructure.Context
{
    public class CollaboratorDbContext : DbContext
    {
        public CollaboratorDbContext(DbContextOptions<CollaboratorDbContext> options): base(options)
        {

        }

        public DbSet<Collaborator> Collaborators { get; set; }
    }
}
