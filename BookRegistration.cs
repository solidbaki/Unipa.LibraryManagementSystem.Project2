using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Unipa.LibraryManagementSystem.Project2
{
    public partial class BookRegistration : Form
    {
        public BookRegistration()
        {
            InitializeComponent();
        }

        private void BookRegistration_FormClosed(object sender, FormClosedEventArgs e)
        {
            BookTransactions.GetBookTransactionInstance.Show();
            BookRegistration.GetBookRegistrationInstance.Hide();
        }

        private void BookRegistration_Load(object sender, EventArgs e)
        {

        }
    }
}
