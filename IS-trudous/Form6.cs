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
    public partial class Form6 : Form
    {
        private OleDbConnection myConnection;
        public Form6()
        {
            InitializeComponent();
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            myConnection = new OleDbConnection(connectionString);
            myConnection.Open();
        }
        public Form6(Form5 f5)
        {
            InitializeComponent();
            f5.Close();
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            myConnection = new OleDbConnection(connectionString);
            myConnection.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
            string query = string.Format("INSERT INTO rabotniki (r_name, r_familiya,r_otchestvo,r_opit,r_obraz,r_pol,r_data,r_age,r_telephone,r_email,r_dostup) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}',{7},'{8}','{9}',{10})", imyatextBox1.Text,familiyatextBox1.Text,OtchestvotextBox1.Text, OpitcomboBox1.Text, ObrazcomboBox1.Text, PolcomboBox1.Text, dateTimePicker1.Value, Convert.ToInt32(agetextBox1.Text), textBox3.Text,emailtextBox1.Text,0);

            // создаем объект OleDbCommand для выполнения запроса к БД MS Access
            OleDbCommand command = new OleDbCommand(query, myConnection);

            // выполняем запрос к MS Access
            command.ExecuteNonQuery();

            myConnection.Close();
            Form5 newForm = new Form5(this);
            newForm.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            Form5 newForm = new Form5(this);
            newForm.Show();
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }
    }
}
