using Microsoft.Data.Sqlite;

namespace Unipa.LibraryManagementSystem.Project2
{
    partial class StudentList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private static StudentList studentListInstance;
        public static StudentList GetStudentListInstance
        {
            get
            {
                if (studentListInstance == null || studentListInstance.IsDisposed)
                    studentListInstance = new StudentList();
                return studentListInstance;
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
        private void getStudentsFromDatabase()
        {
            var studentsName = "";
            var studentsNum = "";
            var connectionStringBuilder = new SqliteConnectionStringBuilder();

            //Use DB in project directory.  If it does not exist, create it:
            connectionStringBuilder.DataSource = "./SqliteDB.db";

            using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {

                    var selectStudentInformation = connection.CreateCommand();
                    selectStudentInformation.CommandText = "SELECT Name,SchoolNumber FROM students";
                    using (var reader = selectStudentInformation.ExecuteReader())
                    {
                        var counter = 1;
                        while (reader.Read())
                        {
                            studentsName += System.Convert.ToString(counter) + " " + reader.GetString(0) + "\n";
                            studentsNum += reader.GetString(1) + "\n";
                            counter++;
                        }
                    }
                }
                label3.Text = studentsName;
                label4.Text = studentsNum;
                connection.Close();

            }
        }
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(130, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Student Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(491, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(184, 31);
            this.label2.TabIndex = 1;
            this.label2.Text = "Student Number";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(130, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(229, 295);
            this.label3.TabIndex = 2;
            this.label3.Text = "Student Names";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(491, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(219, 295);
            this.label4.TabIndex = 3;
            this.label4.Text = "Student Numbers";
            // 
            // StudentList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "StudentList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Library Management System - Student List";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.StudentList_FormClosed);
            this.Load += new System.EventHandler(this.StudentList_Load);
            this.ResumeLayout(false);
            this.PerformLayout();



        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}