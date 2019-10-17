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
    public partial class Form3 : Form
    {
        private int index_str;
        public int peredachaID;
        private int indexGG;
        private OleDbConnection myConnection;

        public Form3()
        {
            InitializeComponent();
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            myConnection = new OleDbConnection(connectionString);
            myConnection.Open();
        }
        public Form3(Form4 f4)
        {
            InitializeComponent();
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            myConnection = new OleDbConnection(connectionString);
            myConnection.Open();
            f4.Close();
        }
        public Form3(Form12 f12)
        {
            InitializeComponent();
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            myConnection = new OleDbConnection(connectionString);
            myConnection.Open();
            f12.Close();
        }
        public Form3(Form13 f13)
        {
            InitializeComponent();
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            myConnection = new OleDbConnection(connectionString);
            myConnection.Open();
            f13.Close();
        }





        private void Form3_Load(object sender, EventArgs e)
        {
            // текст запроса
            string query = "SELECT * FROM vakansii";


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



            
        }

        private void Form3_Close(object sender, EventArgs e)
        {
            myConnection.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            myConnection.Close();
            Form4 newForm = new Form4(this);
            newForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

                //MessageBox.Show(dataGridView1[2, 2].Value));
                index_str = dataGridView1.CurrentRow.Index;
                // MessageBox.Show(Convert.ToString(index_str));

                //MessageBox.Show(Convert.ToString(dataGridView1[0, index_str].Value));

                string query1 = string.Format("DELETE  FROM vakansii WHERE v_id={0}", dataGridView1[0, index_str].Value);
                OleDbCommand command = new OleDbCommand(query1, myConnection);
                command.ExecuteNonQuery();

                string query = "SELECT * FROM vakansii";
                OleDbDataAdapter da = new OleDbDataAdapter(query, myConnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt; //выводим в грид

                myConnection.Close();

            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int index_str = dataGridView1.CurrentRow.Index;
            myConnection.Close();

            peredachaID = Convert.ToInt32(dataGridView1[0, index_str].Value);
            Form13 newForm = new Form13(this, peredachaID);
            newForm.Show();


        }

        private void button5_Click(object sender, EventArgs e)
        {
            index_str = dataGridView1.CurrentRow.Index;
            string query3 = "SELECT v_dostup FROM vakansii WHERE v_id =  "+ Convert.ToString(dataGridView1[0, index_str].Value);
            OleDbDataAdapter dat = new OleDbDataAdapter(query3, myConnection);
           
            DataTable dt1 = new DataTable();
            DataTable dt = new DataTable();
            dat.Fill(dt);
            //int status = Convert.ToInt32();
            if (Convert.ToInt32(dt.Rows[0][0]) == 1)
            {
                MessageBox.Show("Запись занята другим пользователем");
            }
            else {
                index_str = dataGridView1.CurrentRow.Index;
                peredachaID = Convert.ToInt32(dataGridView1[0, index_str].Value);

                string query4 = "UPDATE vakansii SET v_dostup=1 WHERE v_id =" + Convert.ToString(peredachaID);

                OleDbCommand updat = new OleDbCommand(query4, myConnection);
                updat.ExecuteNonQuery();

                myConnection.Close();

                Form12 newForm = new Form12(this,peredachaID);
                newForm.Show();



            }
            
            

        }

        private void button6_Click(object sender, EventArgs e)
        {
            index_str = dataGridView1.CurrentRow.Index;
            peredachaID = Convert.ToInt32(dataGridView1[0, index_str].Value);
            string query = "SELECT * FROM vakansii";
            OleDbDataAdapter da = new OleDbDataAdapter(query, myConnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt; //выводим в грид

           
        }
    }
}
