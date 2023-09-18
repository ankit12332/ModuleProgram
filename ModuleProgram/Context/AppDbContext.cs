using Microsoft.EntityFrameworkCore;
using ModuleProgram.Models;
using System;

namespace ModuleProgram.Context

{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
