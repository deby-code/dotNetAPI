using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using API_REST.Models;

namespace API_REST.Models
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; } = null!;

        public DbSet<API_REST.Models.Client> Client { get; set; }

        public DbSet<API_REST.Models.Worker> Worker { get; set; }

        public DbSet<API_REST.Models.Department> Department { get; set; }
    }
}