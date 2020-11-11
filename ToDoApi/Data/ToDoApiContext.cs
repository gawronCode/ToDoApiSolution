using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDoApi.Models;


namespace ToDoApi.Data
{
    public class ToDoApiContext : DbContext
    {

        public ToDoApiContext(DbContextOptions<ToDoApiContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<Person>().HasIndex(p => new {p.Name}).IsUnique(true);
        }

        public DbSet<Person> Person { get; set; }
        public DbSet<PlannedTask> PlannedTask { get; set; }
        public DbSet<State> State { get; set; }

    }
}
