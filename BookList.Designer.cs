using Microsoft.Data.Sqlite;
using System.Windows.Forms;

namespace Unipa.LibraryManagementSystem.Project2
{

    partial class BookList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private static BookList bkListInstance;
        public static BookList GetBookListInstance
        {
            get
            {
                if (bkListInstance == null || bkListInstance.IsDisposed)
                    bkListInstance = new BookList();
                return bkListInstance;
            }
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(31, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(762, 455);
            this.label1.TabIndex = 0;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // BookList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 509);
            this.Controls.Add(this.label1);
            this.Name = "BookList";
            this.Text = "Library Management System - Book List";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BookList_FormClosed);
            this.Load += new System.EventHandler(this.BookList_Load);
            this.ResumeLayout(false);

        }

        private string getBooksFromDatabase()
        {
            var books = "";
            var connectionStringBuilder = new SqliteConnectionStringBuilder();

            //Use DB in project directory.  If it does not exist, create it:
            connectionStringBuilder.DataSource = "./SqliteDB.db";

            using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
            {
                connection.Open();
                try
                {
                    using (var transaction = connection.BeginTransaction())
                    {

                        var selectBookInformation = connection.CreateCommand();
                        selectBookInformation.CommandText = "SELECT BookName,AuthorName,Description,BookNumber FROM books";
                        using (var reader = selectBookInformation.ExecuteReader())
                        {
                            var counter = 1;
                            while (reader.Read())
                            {
                                var message = System.Convert.ToString(counter) +
                                    "      Book Name: " + reader.GetString(0) +
                                      " -- Author Name: " + reader.GetString(1) +
                                      " -- Description: " + reader.GetString(2) +
                                      " -- Book ID: " + reader.GetString(3) + "\n";

                                books += message;
                                counter++;
                            }
                        }
                    }

                }   catch (SqliteException ex)
                {
                    if (ex.SqliteExtendedErrorCode == 5)
                    {
                        MessageBox.Show("Database Locked");
                    }
                }   connection.Close();

            }   return books;
        }

        #endregion

        private System.Windows.Forms.Label label1;
    }
}