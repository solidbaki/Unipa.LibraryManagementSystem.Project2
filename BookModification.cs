using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

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
    }
}
