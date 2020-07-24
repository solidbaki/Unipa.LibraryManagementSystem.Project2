﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Transactions;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;

namespace Unipa.LibraryManagementSystem.Project2
{
    public partial class BookModification : Form
    {
        public BookModification()
        {
            InitializeComponent();
        }

        private void BookModification_FormClosed(object sender, FormClosedEventArgs e)
        {
            BookModification.GetBookModificationInstance.Hide();
            BookTransactions.GetBookTransactionInstance.Show();
        }

        private void BookModification_Load(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label3.Text = "New Author's Name:";
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label3.Text = "New Book Name:";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            label3.Text = "New Description:";

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

                    if (textBox1.Text != "" && textBox2.Text != "" && radioButton1.Checked)
                    {
                        //Modify Book Name
                        var bkId = Convert.ToInt32(textBox1);
                        var bkName = Convert.ToString(textBox2.Text);
                        insertCmd.CommandText = $"UPDATE books SET BookName='{bkName}' WHERE BookNumber='{bkId}'";
                        insertCmd.ExecuteNonQuery();
                        transaction.Commit();
                    }
                    else if (textBox1.Text != "" && textBox2.Text != "" && radioButton2.Checked)
                    {
                        //Modify Author Name
                        var bkId = Convert.ToInt32(textBox1);
                        var authName = Convert.ToString(textBox2.Text);
                        insertCmd.CommandText = $"UPDATE books SET AuthorName='{authName}' WHERE BookNumber='{bkId}'";
                        insertCmd.ExecuteNonQuery();
                        transaction.Commit();
                    }
                    else if (textBox1.Text != "" && textBox2.Text != "" && radioButton3.Checked)
                    {
                        //Modify Description
                        //TextBox2 filled: holds Student Number -> Student Name
                        var bkId = Convert.ToInt32(textBox1);
                        var bkDesc = Convert.ToString(textBox2.Text);
                        insertCmd.CommandText = $"UPDATE books SET Description='{bkDesc}' WHERE BookNumber='{bkId}'";
                        insertCmd.ExecuteNonQuery();
                        transaction.Commit();
                    }
                    else
                    {
                        MessageBox.Show("Wrong Credentials");
                    }
                    transaction.Commit();
                }   
            }
        }
    }
}
