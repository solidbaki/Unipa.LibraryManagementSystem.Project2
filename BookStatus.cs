using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Unipa.LibraryManagementSystem.Project2
{
    public partial class BookStatus : Form
    {
        public BookStatus()
        {
            InitializeComponent();
        }

        private void BookStatus_Load(object sender, EventArgs e)
        {

        }

        private void BookStatus_FormClosed(object sender, FormClosedEventArgs e)
        {
            BookTransactions.GetBookTransactionInstance.Show();
            BookStatus.GetBookStatusInstance.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder();

            //Use DB in project directory.  If it does not exist, create it:
            connectionStringBuilder.DataSource = "./SqliteDB.db";
            if (textBox1.Text == "")
            {
                label3.Text = "Please enter book ID";
            }
            using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
            {
                try
                {
                    connection.Open();

                    using (var transaction = connection.BeginTransaction())
                    {
                        var queryCmd = connection.CreateCommand();

                        if (textBox1.Text != null)
                        {
                            var bkId = Convert.ToInt32(textBox1.Text);

                            queryCmd.CommandText = $"SELECT IsAvailable FROM books WHERE BookNumber = {bkId}";
                            var queryResult = queryCmd.ExecuteScalar();
                            Convert.ToInt32(queryResult);
                           
                            if (queryResult != null)
                            {
                                if (queryResult.ToString() == "1")
                                {
                                    label3.Text = $"Book ID: {bkId} is available";
                                }
                                else if (queryResult.ToString() == "0")
                                {
                                    label3.Text = $"Book ID: {bkId} is not available";
                                }
                            }
                            else
                            {
                                label3.Text = "No such book exists in database";
                            }
                        }
                        else if (textBox1.Text == "")
                            label3.Text = "Please enter book ID";
                    }

                        connection.Close();
                }   
                catch (SqliteException ex)
                {
                    MessageBox.Show("Database Error: " + ex.Message);
                }
            }
        }
    }
}
