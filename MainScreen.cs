using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Unipa.LibraryManagementSystem.Project2
{
    public partial class MainScreen : Form
    {
        public MainScreen()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            
            StudentTransactions.GetStudentTransactionsInstance.Show();
            


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            // Calling the object's singleton property
            BookTransactions.GetBookTransactionInstance.Show();
        }

        private void MainScreen_Load(object sender, EventArgs e)
        {

        }

        private void MainScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
