using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Unipa.LibraryManagementSystem.Project2
{
    public partial class BookLoan : Form
    {
        public BookLoan()
        {
            InitializeComponent();
        }

        private void BookLoan_FormClosed(object sender, FormClosedEventArgs e)
        {
            BookLoan.GetBookLoanInstance.Hide();
            BookTransactions.GetBookTransactionInstance.Show();
        }

        private void BookLoan_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
