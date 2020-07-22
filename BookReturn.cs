using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Unipa.LibraryManagementSystem.Project2
{
    public partial class BookReturn : Form
    {
        public BookReturn()
        {
            InitializeComponent();
        }

        private void BookReturn_FormClosed(object sender, FormClosedEventArgs e)
        {
            BookTransactions.GetBookTransactionInstance.Show();
            BookReturn.GetBookReturnInstance.Hide();
        }
    }
}
