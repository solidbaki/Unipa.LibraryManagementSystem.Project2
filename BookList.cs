using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Unipa.LibraryManagementSystem.Project2
{
    public partial class BookList : Form
    {
        public BookList()
        {
            InitializeComponent();
        }

        private void BookList_FormClosed(object sender, FormClosedEventArgs e)
        {
            BookList.GetBookListInstance.Hide();
            BookTransactions.GetBookTransactionInstance.Show();
        }

        private void BookList_Load(object sender, EventArgs e)
        {
            label1.Text = getBooksFromDatabase();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
