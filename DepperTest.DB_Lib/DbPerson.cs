using Dapper;
using DepperTest.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DepperTest.DB_Lib
{
    public class DbPerson
    {
        private readonly string _str;
        public DbPerson() 
        {
            _str = GetConnectionString("connection_to_db.txt");
        }

        private static string GetConnectionString(string path)
        {
            return File.ReadAllText(path);
        }

        public List<Person> GetAllPersons()
        {
            using var db = new SqlConnection(_str);
            var sql = "SELECT * FROM users";
            var persons = db.Query<Person>(sql);
            return persons.ToList();
        }

        public List<dynamic> GetTable(string table)
        {
            using var db = new SqlConnection(_str);
            var sql = $"SELECT * FROM {table}";
            var persons = db.Query(sql);
            return persons.ToList();
        }
    }
}
