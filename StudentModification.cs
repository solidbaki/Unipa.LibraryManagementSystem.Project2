using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

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
    }
}
