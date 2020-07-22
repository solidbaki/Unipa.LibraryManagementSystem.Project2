using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

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
    }
}
