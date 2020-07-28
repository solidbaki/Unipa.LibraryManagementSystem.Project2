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
    public partial class BookLoan : Form
    {
        public BookLoan()
        {
            InitializeComponent();
        }

        private void BookLoan_FormClosed(object sender, FormClosedEventArgs e)
        {
            BookLoan.GetBookLoanInstance.Hide();
            BookTransactions.GetBookTransactionInstance.Show();
        }

        private void BookLoan_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //WILL BE MODIFIED
            var connectionStringBuilder = new SqliteConnectionStringBuilder();
            connectionStringBuilder.DataSource = "./SqliteDB.db";

            using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
            {
                if (textBox1.Text == "" && textBox2.Text == "")
                    label4.Text = "Please enter student number and book ID";
                else if (textBox1.Text == "")
                    label4.Text = "Please enter student number";
                else if (textBox2.Text == "")
                    label4.Text = "Please enter book ID";
                else
                {
                    try
                    {
                        connection.Open();
                        using (var transaction = connection.BeginTransaction())
                        {
                            var stdNum = Convert.ToString(textBox1.Text);
                            var bkId = Convert.ToInt32(textBox2.Text);
                            var queryCmd = connection.CreateCommand();
                            
                            queryCmd.CommandText = $"SELECT IsAvailable FROM books WHERE BookNumber = {bkId}";
                            var isAvailable = queryCmd.ExecuteScalar();

                            queryCmd.CommandText = $"SELECT 1 FROM students WHERE SchoolNumber ='{stdNum}' ";
                            var isStudentExists = queryCmd.ExecuteScalar();

                            // If student exists in the system, and book is available, assign the book to the student
                            //MessageBox.Show($"{stdNum} - {bkId}");

                            if (isAvailable != null && isStudentExists != null)
                            {
                                if (isAvailable.ToString() == "1" && isStudentExists.ToString() != "")
                                {

                                    queryCmd.CommandText = $"UPDATE books SET IsAvailable = 0 WHERE BookNumber = {bkId}";
                                    queryCmd.ExecuteNonQuery();

                                    var dateOfLoan = Convert.ToString(DateTime.Now.ToString("MM/dd/yyyy") + " " + stdNum);
                                    MessageBox.Show(dateOfLoan);
                                    queryCmd.CommandText = $"UPDATE books SET DateOfLoan='{dateOfLoan}' WHERE BookNumber={bkId}";
                                    queryCmd.ExecuteNonQuery();
                                    
                                    label4.Text = $"Book assigned : {dateOfLoan} to Student number: {stdNum}";

                                    transaction.Commit();
                                }
                                else if (isAvailable.ToString() == "0")
                                    label4.Text = "Book is not available";
                            }
                            else if (isAvailable == null)
                                label4.Text = "No such book exists";
                            else if (isStudentExists == null)
                                label4.Text = "No such student exists";
                        }
                    }
                    catch (SqliteException ex)
                    {
                        label4.Text = $"Database Error: {ex.Message}";
                    }
                    catch (Exception ex)
                    {
                        label4.Text = $"Error: {ex.Message}";
                    }
                }
                connection.Close();
            }   
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
