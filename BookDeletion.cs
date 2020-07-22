using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Unipa.LibraryManagementSystem.Project2
{
    public partial class BookDeletion : Form
    {
        public BookDeletion()
        {
            InitializeComponent();
        }

        private void BookDeletion_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void BookDeletion_FormClosed(object sender, FormClosedEventArgs e)
        {
            BookDeletion.GetBookDeletionInstance.Hide();
            BookTransactions.GetBookTransactionInstance.Show();
        }
    }
}
