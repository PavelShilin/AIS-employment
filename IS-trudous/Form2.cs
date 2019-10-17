using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Configuration;
using System.Data.OleDb;

namespace IS_trudous
{
    public partial class Form2 : Form
    {
        private OleDbConnection myConnection;
        public Form2()
        {
            InitializeComponent();
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            myConnection = new OleDbConnection(connectionString);
            myConnection.Open();


        }
        public Form2(Form1 f1)
        {
            InitializeComponent();
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            myConnection = new OleDbConnection(connectionString);
            myConnection.Open();
            label6.Text=f1.user;

        }
        



        private void Form2_Load(object sender, EventArgs e)
        {

            timer1.Enabled = true;
        }

        private void SpravochnikiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void VakansiiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 newForm = new Form3();
            newForm.Show();
        }

        private void BezrabotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 newForm = new Form5();
            newForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
           var connectionString1 = ConfigurationManager.ConnectionStrings["otkuda"].ConnectionString;
           var connectionString2 = ConfigurationManager.ConnectionStrings["kuda"].ConnectionString;
            //MessageBox.Show(connectionString1);
            //MessageBox.Show(connectionString2);
            
            try
            {
                // connectionString = "@" + connectionString;
                File.Copy(@connectionString1, @connectionString2, true);
                MessageBox.Show("Резервное копирование выполнено!  ", connectionString2);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void Otchot1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form7 newForm = new Form7();
            newForm.Show();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
          
           
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            myConnection.Close();
            myConnection.Open();
            string sqlExpression = "SELECT * FROM vakansii";
            OleDbCommand command = new OleDbCommand(sqlExpression, myConnection);
            OleDbDataReader reader = command.ExecuteReader();
            int col_vakansiy = 0;

            while (reader.Read()) // построчно считываем данные
            {
                col_vakansiy++;
            }
            myConnection.Close();
            
            myConnection.Open();
            string sqlExpression2 = "SELECT * FROM rabotniki";
            OleDbCommand command2 = new OleDbCommand(sqlExpression2, myConnection);
            OleDbDataReader reader2 = command2.ExecuteReader();
            int col_rabotnikov = 0;

            while (reader2.Read()) // построчно считываем данные
            {
                col_rabotnikov++;
            }

            myConnection.Close();
            label4.Text = Convert.ToString(col_vakansiy);
            label5.Text = Convert.ToString(col_rabotnikov);
        }

        private void возрастToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form8 newForm = new Form8();
            newForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OprogrameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 newForm = new AboutBox1();
            newForm.Show();
            
        }

        private void образованиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form9 newForm = new Form9();
            newForm.Show();
        }

        private void VremenayaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form10 newform = new Form10();
            newform.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
