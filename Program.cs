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

                var createTableCmd = connection.CreateCommand();
                createTableCmd.CommandText = "CREATE TABLE IF NOT EXISTS students(Name VARCHAR(50) NOT NULL, SchoolNumber VARCHAR(10) NOT NULL, PRIMARY KEY (SchoolNumber))";
                createTableCmd.ExecuteNonQuery();

                var createTableCmd2 = connection.CreateCommand();
                createTableCmd2.CommandText = "CREATE TABLE IF NOT EXISTS books(BookName VARCHAR(50) NOT NULL, AuthorName VARCHAR(50), Description VARCHAR(10) , BookNumber VARCHAR(10), PRIMARY KEY (BookNumber))";
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
