using EfCoreLike.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;

namespace EfCoreLike
{
    public class AppDbContext : DbContext
    {
        public static ILoggerFactory DebugLoggerFactory =
            LoggerFactory.Create(builder => builder.AddDebug());

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseLoggerFactory(DebugLoggerFactory)
                    .UseSqlServer(
                        @"Server=(localdb)\mssqllocaldb;Database=EfCoreLike;" +
                        "Trusted_Connection=True;MultipleActiveResultSets=true");
            }

            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var persons = new[]
            {
                new Person { Id = 1, FirstName = "Lisa", LastName = "Johansson", Address1 = "Gatan 5", PostCode = "75455", City = "Uppsala", Country = "Sverige", BirthDate = new DateTime(1975, 8, 3), JoinDate = new DateTime(2014, 3, 12) },
                new Person { Id = 2, FirstName = "Oscar", LastName = "Bengtsson", Address1 = "Vägen 55", PostCode = "75450", City = "Uppsala", Country = "Sverige", BirthDate = new DateTime(1992, 2, 26), JoinDate = new DateTime(2020, 9, 6) },
                new Person { Id = 3, FirstName = "Fia", LastName = "Sten", Address1 = "Långgatan 9", PostCode = "11011", City = "Stockholm", Country = "Sverige", BirthDate = new DateTime(2002, 12, 31), JoinDate = new DateTime(2018, 11, 9) },
                new Person { Id = 4, FirstName = "Kalle", LastName = "Berg", Address1 = "Stora vägen 42", PostCode = "95433", City = "Umeå", Country = "Sverige", BirthDate = new DateTime(1984, 10, 15), JoinDate = new DateTime(2010, 6, 21) }
            };

            modelBuilder.Entity<Person>()
                .HasData(persons);

            MyDbFunctions.Register(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Person> Person { get; set; }
    }
}
