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
    public partial class StudentRegistration : Form
    {
        public StudentRegistration()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void StudentRegistration_Load(object sender, EventArgs e)
        {

        }

        private void StudentRegistration_FormClosed(object sender, FormClosedEventArgs e)
        {
            StudentRegistration.GetStudentRegistrationInstance.Hide();
            StudentTransactions.GetStudentTransactionsInstance.Show();
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

                    if (textBox1.Text == "" && textBox2.Text == "")
                    {
                        label4.Text = "Please enter student name and student number";
                    }
                    else if (textBox1.Text == "")
                    {
                        label4.Text = "Please enter student name";
                    }
                    else if (textBox2.Text == "")
                    {
                        label4.Text = "Please enter school number";
                    }
                    else
                    {
                        var stdName = Convert.ToString(textBox1.Text);
                        var stdNum = Convert.ToString(textBox2.Text);
                        insertCmd.CommandText = $"INSERT INTO students VALUES( '{stdName}', '{stdNum}')";
                        insertCmd.ExecuteNonQuery();


                        //Read the newly inserted data:
                        var selectCmd = connection.CreateCommand();
                        selectCmd.CommandText = "SELECT Name,SchoolNumber FROM students";

                        using (var reader = selectCmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var message = reader.GetString(0) + " " + reader.GetString(1);
                                MessageBox.Show(message); ;
                            }
                        }

                        transaction.Commit();
                    }

                }
                connection.Close();
            }

        } 
    }
}
