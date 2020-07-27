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
    public partial class BookReturn : Form
    {
        public BookReturn()
        {
            InitializeComponent();
        }

        private void BookReturn_FormClosed(object sender, FormClosedEventArgs e)
        {
            BookTransactions.GetBookTransactionInstance.Show();
            BookReturn.GetBookReturnInstance.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                label3.Text = "Please enter book ID";
            else
            {
                var connectionStringBuilder = new SqliteConnectionStringBuilder();
                connectionStringBuilder.DataSource = "./SqliteDB.db";

                using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
                {
                    try
                    {
                        connection.Open();
                        using (var transaction = connection.BeginTransaction())
                        {
                            var bkNum = Convert.ToInt32(textBox1.Text);
                            var queryCmd = connection.CreateCommand();

                            queryCmd.CommandText = $"SELECT IsAvailable FROM books WHERE BookNumber = {bkNum}";
                            var isAvailable = queryCmd.ExecuteScalar();

                            queryCmd.CommandText = $"SELECT DateOfLoan FROM books WHERE BookNumber ={bkNum} ";
                            var dtOfLoan = queryCmd.ExecuteScalar();

                            queryCmd.CommandText = $"SELECT DateOfLoan FROM books WHERE BookNumber ={bkNum} ";
                            var stdName = queryCmd.ExecuteScalar();
                            //If book is not available and date of loann not null and book exists

                            if (isAvailable != null)
                            {

                            }
                            else if (isAvailable == null)
                                label3.Text = "No such book exists";
                        }
                    }
                    catch (SqliteException ex)
                    {
                        label3.Text = $"Database Error: {ex.Message}";
                    }
                    catch (Exception ex)
                    {
                        label3.Text = $"Error: {ex.Message}";
                    }
                    finally
                    {
                        connection.Close();
                    }
                }

            }
        }
    }
}
