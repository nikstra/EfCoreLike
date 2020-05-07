using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EfCoreLike
{
    class Program
    {
        const int TSQL_ISO8601_DATE_FORMAT = 23;

        static void Main(string[] args)
        {
            using var db = new AppDbContext();
            db.Database.Migrate();

            IQueryable<Entities.Person> result;
            
            while(true)
            {
                Console.WriteLine("Enter search word (or date in ISO format) or 'Q' to quit.");
                Console.Write("Search: ");

                var input = Console.ReadLine();
                if (input.Length == 1 && input.ToUpperInvariant() == "Q")
                    break;

                var pattern = "%" + input + "%";
                result = FreeTextSearch(db, pattern);
                Console.WriteLine("Results:");
                foreach (var person in result)
                {
                    Console.WriteLine(
                        $"{person.Id}) {person.FirstName} {person.LastName}," +
                        $" {person.Address1} {person.Address2}," +
                        $" {person.PostCode} {person.City}, {person.Country}," +
                        $" {person.BirthDate.ToString("yyyy-MM-dd")}, {person.JoinDate.ToString("yyyy-MM-dd")}");
                }

                Console.WriteLine(result.Any()
                    ? string.Empty
                    : "Nothing found." + Environment.NewLine);
            }
        }

        private static IQueryable<Entities.Person> FreeTextSearch(AppDbContext db, string pattern)
        {
            return db.Person
                .Where(p =>
                    EF.Functions.Like(p.FirstName, pattern) ||
                    EF.Functions.Like(p.LastName, pattern) ||
                    EF.Functions.Like(p.Address1, pattern) ||
                    EF.Functions.Like(p.Address2, pattern) ||
                    EF.Functions.Like(p.PostCode, pattern) ||
                    EF.Functions.Like(p.City, pattern) ||
                    EF.Functions.Like(p.Country, pattern) ||
                    EF.Functions.Like(p.BirthDate.Convert("VARCHAR", TSQL_ISO8601_DATE_FORMAT), pattern) ||
                    EF.Functions.Like(p.JoinDate.Convert("VARCHAR", TSQL_ISO8601_DATE_FORMAT), pattern));
        }
    }
}
