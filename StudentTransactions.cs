using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Unipa.LibraryManagementSystem.Project2
{
    public partial class StudentTransactions : Form
    {
        public StudentTransactions()
        {
            InitializeComponent();
        }

        private void StudentTransactions_Load(object sender, EventArgs e)
        {

        }

        private void StudentTransactions_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainScreen.getMainScreenInstance.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            StudentTransactions.GetStudentTransactionsInstance.Hide();
            StudentRegistration.GetStudentRegistrationInstance.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StudentTransactions.GetStudentTransactionsInstance.Hide();
            StudentDeletion.getStudentDeletionInstance.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            StudentModification.GetStudentModificationInstance.Show();
            StudentTransactions.GetStudentTransactionsInstance.Hide();
        }
    }
}
