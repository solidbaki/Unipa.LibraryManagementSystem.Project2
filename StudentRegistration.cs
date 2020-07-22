using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

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
    }
}
