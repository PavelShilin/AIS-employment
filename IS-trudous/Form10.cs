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
    public partial class Form10 : Form
    {
        private OleDbConnection myConnection;
        public Form10()
        {
            InitializeComponent();
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            myConnection = new OleDbConnection(connectionString);
            myConnection.Open();
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            // текст запроса
            string query = "SELECT * FROM vremenaya";


            // создаем объект OleDbCommand для выполнения запроса к БД MS Access
            OleDbCommand command = new OleDbCommand(query, myConnection);
            OleDbDataAdapter da = new OleDbDataAdapter(query, myConnection);
            //  SqlDataReader reader = command.ExecuteReader();
            // выполняем запрос и выводим результат в textBox1


            dataGridView1.AllowUserToAddRows = false; //ne запрешаем пользователю самому добавлять строки

            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt; //выводим в грид
                                           // dataGridView1.Sort
            myConnection.Close();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            myConnection.Close();
            this.Close();
        }
    }
}
