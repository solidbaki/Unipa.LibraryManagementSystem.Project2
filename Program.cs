using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;

namespace Unipa.LibraryManagementSystem.Project2
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder();

            //Use DB in project directory.  If it does not exist, create it:
            connectionStringBuilder.DataSource = "./SqliteDB.db";

            using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
            {
                connection.Open();

                //Students Db. Table Creation
                var createTableCmd = connection.CreateCommand();
                createTableCmd.CommandText = "CREATE TABLE IF NOT EXISTS students(Name TEXT NOT NULL, SchoolNumber TEXT NOT NULL PRIMARY KEY)";
                createTableCmd.ExecuteNonQuery();

                //Book Db. Table Creation
                var createTableCmd2 = connection.CreateCommand();
                createTableCmd2.CommandText = "CREATE TABLE IF NOT EXISTS books(BookName TEXT NOT NULL, AuthorName TEXT, Description TEXT , BookNumber INTEGER PRIMARY KEY AUTOINCREMENT, IsAvailable INTEGER DEFAULT 1, DateOfLoan TEXT DEFAULT '-')";
                createTableCmd2.ExecuteNonQuery();

                
                connection.Close();

            }

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainScreen());
        }
    }
}
