using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace IS_trudous
{
    public partial class Form4 : Form
    {
        private OleDbConnection myConnection;
        public Form4()
        {
            InitializeComponent();
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            myConnection = new OleDbConnection(connectionString);
            myConnection.Open();
        }
        public Form4(Form3 f)
        {
            InitializeComponent();
            f.Close();
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            myConnection = new OleDbConnection(connectionString);
            myConnection.Open();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 newForm = new Form3(this);
            newForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            string query = string.Format( "INSERT INTO vakansii (v_name, v_opit, v_obraz,v_pol,v_zp,v_tip,v_dop,v_telephone,v_address,v_dostup) VALUES ('{0}','{1}','{2}','{3}',{4},'{5}','{6}','{7}','{8}',{9})", textBox1.Text,OpitcomboBox1.Text,ObrazcomboBox1.Text,PolcomboBox1.Text,Convert.ToInt32(ZPtextBox2.Text),comboBox1.Text,textBox2.Text,textBox3.Text,textBox4.Text,0);

            // создаем объект OleDbCommand для выполнения запроса к БД MS Access
            OleDbCommand command = new OleDbCommand(query, myConnection);

            // выполняем запрос к MS Access
            command.ExecuteNonQuery();
           
            myConnection.Close();
            Form3 newForm = new Form3(this);
            newForm.Show();
            
        }

        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            myConnection.Close();
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            myConnection.Close();
        }
    }
}
