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
    public partial class StudentModification : Form
    {
        public StudentModification()
        {
            InitializeComponent();
        }

        private void StudentModification_FormClosed(object sender, FormClosedEventArgs e)
        {
            StudentTransactions.GetStudentTransactionsInstance.Show();
            StudentModification.GetStudentModificationInstance.Hide();
        }

        private void StudentModification_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
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

                    if (textBox1.Text != "" && textBox2.Text != "")
                    {
                        label5.Text = "Please enter only one of the sides";
                    }
                    else if (textBox1.Text != "" && textBox2.Text == "" && textBox3.Text != "" && textBox4.Text == "")
                    {
                        //TextBox1 filled: holds Current Student Number -> New Student Number, tb3 : new school num
                        var currStdNum = Convert.ToString(textBox1.Text);
                        var newStdNum = Convert.ToString(textBox3.Text);
                        insertCmd.CommandText = $"UPDATE students SET SchoolNumber='{newStdNum}' WHERE SchoolNumber='{currStdNum}'";
                        insertCmd.ExecuteNonQuery();
                        
                        //Warning label modified after student modification
                        label5.Text = $"{currStdNum} modified to {newStdNum}";
                        transaction.Commit();
                    }
                    else if (textBox2.Text != "" && textBox4.Text != "" && textBox1.Text == "" && textBox3.Text == "")
                    {   
                        //TextBox2 filled: holds Student Number -> Student Name
                        var stdName = Convert.ToString(textBox4.Text);
                        var stdNum = Convert.ToString(textBox2.Text);
                        insertCmd.CommandText = $"UPDATE students SET Name='{stdName}' WHERE SchoolNumber='{stdNum}'";
                        insertCmd.ExecuteNonQuery();

                        //Warning label modified after student modification
                        label5.Text = $"Student with number {stdNum} changed his/her name to {stdName}";
                        transaction.Commit();
                    } else
                    {
                        label5.Text = "Wrong Credentials";
                    }
                }
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }
    }
}