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
                                    queryCmd.CommandText = $"SELECT BookName FROM books WHERE BookNumber={bkNum}";
                                    var bookName = queryCmd.ExecuteScalar();

                                    //Get current date and get loaned date, both of them are DateTime objects
                                    DateTime dateOfLoan = DateTime.ParseExact(loanDate, "MM.dd.yyyy", System.Globalization.CultureInfo.InvariantCulture);
                                    DateTime currDate = DateTime.Now;
                                    var daysPassed = calculateBusinessDays(dateOfLoan, currDate);

                                    
                                    if (daysPassed > 10)
                                    {
                                        label3.Text = $"{studentName} successfully returned {bookName} with book ID: {bkNum} {daysPassed - 10} business days late";
                                        double penaltyFee = (daysPassed - 10) * 1.5;
                                    }
                                    else
                                    {
                                        label3.Text = $"{studentName} successfully returned {bookName} with book ID: {bkNum}";
                                    }

                                    //After a book is returned, books db. table should be updated, book should be available again 
                                    //and IsLoan field become 

                                    //Set IsAvailable = 1
                                    queryCmd.CommandText =  $"UPDATE books SET IsAvailable=1 WHERE BookNumber={bkNum}";
                                    queryCmd.ExecuteNonQuery();

                                    //Set DateOfLoan "-"
                                    queryCmd.CommandText = $"UPDATE books SET DateOfLoan='-' WHERE BookNumber={bkNum}";
                                    queryCmd.ExecuteNonQuery();

                                    if (isAvailable == null)
                                        label3.Text = "No such book exists";
                                }
                            }
                            transaction.Commit();
                        }
                    }
                    catch (SqliteException ex)
                    {
                        label3.Text = $"Database Error: {ex.Message}";
                    }
                    catch (IndexOutOfRangeException ex)
                    {
                        label3.Text = $"Book is already in library, can't be returned";
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

        private int calculateBusinessDays(DateTime start, DateTime stop)
        {
            int days = 0;

            //Create an array for holidays, then add all of them to the loop, as DateTime objects and compare 

            while (start <= stop)
            {
                if (start.DayOfWeek != DayOfWeek.Saturday   && start.DayOfWeek != DayOfWeek.Sunday &&  //NOT WEEKEND
                    !(start.Day == 1 && start.Month == 1)   &&                                         //NOT HOLIDAY
                    !(start.Day == 23 && start.Month == 4)  &&   
                    !(start.Day == 19 && start.Month == 5)  &&
                    !(start.Day == 1 && start.Month == 5)   &&
                    !(start.Day == 30 && start.Month == 8)  &&
                    !(start.Day == 29 && start.Month == 10) &&
                    !(start.Day == 15 && start.Month == 8)  &&
                    !(start.Day == 28 && start.Month == 7))
                {
                    ++days;
                }
                start = start.AddDays(1);
            }
            //MessageBox.Show($"There is {days} business days between {start} and {stop}");
            return days;
        }
    }
}
