using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Unipa.LibraryManagementSystem.Project2
{
    public partial class BookStatus : Form
    {
        public BookStatus()
        {
            InitializeComponent();
        }

        private void BookStatus_Load(object sender, EventArgs e)
        {

        }

        private void BookStatus_FormClosed(object sender, FormClosedEventArgs e)
        {
            BookTransactions.GetBookTransactionInstance.Show();
            BookStatus.GetBookStatusInstance.Hide();
        }
    }
}
