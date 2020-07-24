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
    public partial class BookDeletion : Form
    {
        public BookDeletion()
        {
            InitializeComponent();
        }

        private void BookDeletion_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void BookDeletion_FormClosed(object sender, FormClosedEventArgs e)
        {
            BookDeletion.GetBookDeletionInstance.Hide();
            BookTransactions.GetBookTransactionInstance.Show();
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

                    if (textBox1.Text == "")
                    {
                        label3.Text = "Please enter Book ID";
                    }
                    else
                    {
                        try
                        {
                            var bookNum = Convert.ToInt32(textBox1.Text);
                            insertCmd.CommandText = $"DELETE FROM books WHERE BookNumber={bookNum}";
                            insertCmd.ExecuteNonQuery();

                            transaction.Commit();
                        }   catch (Exception ex)
                        {
                            label3.Text = $"Exception: {ex.Message}";
                        }


                        
                    }

                }
                connection.Close();
            }
        }
    }
}
