using System;
using System.Collections.Generic;
using System.Text;
using UserService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace UserService.Infrastructure.Context
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options): base(options)
        {

        }

        public DbSet<User> Users { get; set; }
    }

}
