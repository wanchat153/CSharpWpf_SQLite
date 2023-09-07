using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpWpf_SQLite
{
    internal class DataAccess
    {
        public async static void InitializeDatabase()
        {
            using (SqliteConnection db = new SqliteConnection($"Filename=sqliteSample.db"))
            {
                db.Open();
                String tableCommand = "CREATE TABLE IF NOT " +
                    "EXISTS MyTable (Primary_Key INTEGER PRIMARY KEY, " +
                    "Text_Entry NVARCHAR(2048) NULL)";

                SqliteCommand createTable = new SqliteCommand(tableCommand, db);
                createTable.ExecuteReader();
                db.Close();
            }
        }

        //INSERT INTO MyTable data
        public static void AddData(string inputText)
        {
            using (SqliteConnection db = new SqliteConnection($"Filename=sqliteSample.db"))
            {
                db.Open();
                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                // Use parameterized query to prevent SQL injection attacks
                insertCommand.CommandText = "INSERT INTO MyTable VALUES (NULL, @Entry);";
                insertCommand.Parameters.AddWithValue("@Entry", inputText);
                insertCommand.ExecuteReader();
                db.Close();
            }
        }
    }
}
