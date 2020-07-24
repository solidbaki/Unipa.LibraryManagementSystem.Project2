using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Unipa.LibraryManagementSystem.Project2
{
    public partial class BookTransactions : Form
    {
        public BookTransactions()
        {
            InitializeComponent();
        }

        private void BookTransactions_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            MainScreen mainScreen = new MainScreen();
            mainScreen.Show();
        }

        private void BookTransactions_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            BookRegistration.GetBookRegistrationInstance.Show();
            BookTransactions.GetBookTransactionInstance.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BookDeletion.GetBookDeletionInstance.Show();
            BookTransactions.GetBookTransactionInstance.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BookModification.GetBookModificationInstance.Show();
            BookTransactions.GetBookTransactionInstance.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            BookStatus.GetBookStatusInstance.Show();
            BookTransactions.GetBookTransactionInstance.Hide();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            BookLoan.GetBookLoanInstance.Show();
            BookTransactions.GetBookTransactionInstance.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            BookReturn.GetBookReturnInstance.Show();
            BookTransactions.GetBookTransactionInstance.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            BookList.GetBookListInstance.Show();
            BookTransactions.GetBookTransactionInstance.Hide();
        }
    }
}
