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

                            
                            if (isAvailable == null)
                                label3.Text = "Book doesn't exist";
                            else if (isAvailable.ToString() == "1")
                                label3.Text = "Book is not borrowed";

                            else if (isAvailable.ToString() == "0")
                            {
                                queryCmd.CommandText = $"SELECT DateOfLoan FROM books WHERE BookNumber={bkNum}";

                                if (queryCmd.ExecuteScalar() == null)
                                {

                                    label3.Text = $"No such book exists with ID: {bkNum}";
                                }
                                else
                                {
                                    var dtOfLoan = queryCmd.ExecuteScalar().ToString();
                                    MessageBox.Show(dtOfLoan.ToString());
                                    string[] dtOfLoanAndStdNum = dtOfLoan.Split(" ");

                                    var loanDate = dtOfLoanAndStdNum[0];
                                    var studentNumber = dtOfLoanAndStdNum[1];

                                    //Get student info
                                    queryCmd.CommandText = $"SELECT Name FROM students WHERE SchoolNumber ={studentNumber}";
                                    var studentName = queryCmd.ExecuteScalar().ToString();

                                    //Query Check if book exists
                                    queryCmd.CommandText = $"SELECT * FROM books WHERE BookNumber={bkNum}";
                                    var bookInfo = queryCmd.ExecuteScalar();

                                    //Get current date and get loaned date, both of them are DateTime objects
                                    DateTime dateOfLoan = DateTime.ParseExact(loanDate, "MM.dd.yyyy", System.Globalization.CultureInfo.InvariantCulture);
                                    DateTime currDate = DateTime.Now;
                                    calculateBusinessDays(dateOfLoan, currDate);
                                   
                                    //label3.Text = Convert.ToString(currDate.Subtract(dateOfLoan));
                                    //MessageBox.Show(Convert.ToString(currDate.Subtract(dateOfLoan).Days));
                                    
                                    //Set IsAvailable = 1
                                    //queryCmd.CommandText =  $"SET books UPDATE IsAvailable=1 WHERE BookNumber={bkNum}";
                                    //queryCmd.ExecuteNonQuery();

                                    //Set Date of Loan "-"
                                    //queryCmd.CommandText = $"SET books UPDATE DateOfLoan='-' WHERE BookNumber={bkNum}";
                                    //queryCmd.ExecuteNonQuery();

                                    label3.Text = $"Book ID:{bkNum} returned by {studentName} at the date {currDate} loan date {dateOfLoan}";

                                    if (isAvailable == null)
                                        label3.Text = "No such book exists";
                                }
                            }
                           
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

        public double calculateBusinessDays(DateTime start, DateTime stop)
        {
            int days = 0;
            while (start <= stop)
            {
                if (start.DayOfWeek != DayOfWeek.Saturday && start.DayOfWeek != DayOfWeek.Sunday)
                {
                    ++days;
                }
                start = start.AddDays(1);
            }
            MessageBox.Show($"There is {days} days between {start} and {stop}");
            if (days > 10)
                return (days - 10) * (1.5);
            return 0;
        }
    }
}
