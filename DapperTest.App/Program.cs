using DepperTest.DB_Lib;
using System;

namespace DapperTest.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var db = new DbPerson();

            foreach(var person in db.GetAllPersons())
            {
               Console.WriteLine($"#{person.Id} {person.FirstName} {person.LastName}  {person.Age}");
            }

            Console.WriteLine("\n\n");
            foreach (var person in db.GetTable("users"))
            {
                Console.WriteLine($"#{person.Id}:  {person.FirstName} {person.LastName},  {person.Age}");
            }
        }
    }
}
