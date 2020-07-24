using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;

namespace Unipa.LibraryManagementSystem.Project2
{
    public partial class BookRegistration : Form
    {
        public BookRegistration()
        {
            InitializeComponent();
        }

        private void BookRegistration_FormClosed(object sender, FormClosedEventArgs e)
        {
            BookTransactions.GetBookTransactionInstance.Show();
            BookRegistration.GetBookRegistrationInstance.Hide();
        }

        private void BookRegistration_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder();

            //Use DB in project directory.  If it does not exist, create it:
            connectionStringBuilder.DataSource = "./SqliteDB.db";

            using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    var insertCmd = connection.CreateCommand();

                    if ((textBox1.Text == "" && textBox2.Text == "" && textBox3.Text == "") || (textBox1.Text == "" && textBox2.Text=="") ||
                        (textBox1.Text == "" && textBox3.Text == "") || (textBox2.Text == "" && textBox3.Text == ""))
                    {
                        label4.Text = "Please enter book information";
                    }   
                    else if (textBox1.Text == "")
                    {
                        label4.Text = "Please enter book name";
                    }
                    else if (textBox2.Text == "")
                    {
                        label4.Text = "Please enter author's name";
                    }
                    else if (textBox3.Text == "")
                    {
                        label4.Text = "Please enter book description";
                    }
                    else
                    {
                        var bkName = Convert.ToString(textBox1.Text);
                        var bkAuthName = Convert.ToString(textBox2.Text);
                        var bkDesc = Convert.ToString(textBox3.Text);
                        insertCmd.CommandText = $"INSERT INTO books(BookName,AuthorName,Description) VALUES('{bkName}','{bkAuthName}','{bkDesc}')";
                        insertCmd.ExecuteNonQuery();


                        //Read the newly inserted data:
                        var selectCmd = connection.CreateCommand();
                        selectCmd.CommandText = "SELECT BookName,AuthorName,Description FROM books";

                        label4.Text = $"{bkName} by {bkAuthName} added to the system";

                        transaction.Commit();
                    }

                }
                connection.Close();
            }
        }
    }
}
