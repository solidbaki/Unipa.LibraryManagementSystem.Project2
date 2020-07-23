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
    public partial class StudentDeletion : Form
    {
        public StudentDeletion()
        {
            InitializeComponent();
        }

        private void StudentDeletion_FormClosed(object sender, FormClosedEventArgs e)
        {
            StudentDeletion.getStudentDeletionInstance.Hide();
            StudentTransactions.GetStudentTransactionsInstance.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
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

                    if (textBox1.Text == "")
                    {
                        MessageBox.Show("Please enter a student number");
                    }
                    else
                    {
                        var stdNum = Convert.ToString(textBox1.Text);
                        insertCmd.CommandText = $"DELETE FROM students WHERE SchoolNumber='{stdNum}'";
                        insertCmd.ExecuteNonQuery();


                        //Read the newly inserted data:
                        var selectCmd = connection.CreateCommand();
                        selectCmd.CommandText = "SELECT Name FROM students";

                        using (var reader = selectCmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var message = reader.GetString(0);
                                MessageBox.Show(message);
                            }
                        }

                        transaction.Commit();
                    }

                }
                //connection.Close();
            }
        }
    }
}
