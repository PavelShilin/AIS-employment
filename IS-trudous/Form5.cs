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
    public partial class Form5 : Form
    {
        private int index_str;
        public int indexGG;
        public int peredachaID;
        private OleDbConnection myConnection;
        public Form5()
        {
            InitializeComponent();
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            myConnection = new OleDbConnection(connectionString);
            myConnection.Open();
        }
        public Form5(Form6 f6)
        {
            InitializeComponent();
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            myConnection = new OleDbConnection(connectionString);
            myConnection.Open();
            f6.Close();
        }
        public Form5(Form11 f11)
        {
            InitializeComponent();
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            myConnection = new OleDbConnection(connectionString);
            myConnection.Open();
            f11.Close();
        }
        public Form5(Form14 f14)
        {
            InitializeComponent();
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            myConnection = new OleDbConnection(connectionString);
            myConnection.Open();
            f14.Close();
        }


        private void Form5_Load(object sender, EventArgs e)
        {
            string query = "SELECT * FROM rabotniki";



            OleDbCommand command = new OleDbCommand(query, myConnection);
            OleDbDataAdapter da = new OleDbDataAdapter(query, myConnection);



            dataGridView1.AllowUserToAddRows = false; //ne запрешаем пользователю самому добавлять строки

            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt; //выводим в грид

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            myConnection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            myConnection.Close();
            Form6 newForm = new Form6(this);
            newForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            int index_str = dataGridView1.CurrentRow.Index;
            myConnection.Close();

            indexGG = Convert.ToInt32(dataGridView1[0, index_str].Value);
            Form11 newForm = new Form11(this, index_str);
            newForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {

                //MessageBox.Show(dataGridView1[2, 2].Value));
                index_str = dataGridView1.CurrentRow.Index;
                // MessageBox.Show(Convert.ToString(index_str));

                //MessageBox.Show(Convert.ToString(dataGridView1[0, index_str].Value));

                string query1 = string.Format("DELETE  FROM rabotniki WHERE r_id={0}", dataGridView1[0, index_str].Value);
                OleDbCommand command = new OleDbCommand(query1, myConnection);
                command.ExecuteNonQuery();

                string query = "SELECT * FROM rabotniki";
                OleDbDataAdapter da = new OleDbDataAdapter(query, myConnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt; //выводим в грид

            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM rabotniki";
            OleDbDataAdapter da = new OleDbDataAdapter(query, myConnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt; //выводим в грид

        }

        private void button5_Click(object sender, EventArgs e)
        {
            index_str = dataGridView1.CurrentRow.Index;
            string query3 = "SELECT r_dostup FROM rabotniki WHERE r_id = " + Convert.ToString(dataGridView1[0, index_str].Value);
            OleDbDataAdapter dat = new OleDbDataAdapter(query3, myConnection);

            DataTable dt1 = new DataTable();
            DataTable dt = new DataTable();
            dat.Fill(dt);
            //int status = Convert.ToInt32();
            if (Convert.ToInt32(dt.Rows[0][0]) == 1)
            {
                MessageBox.Show("Запись занята другим пользователем");
            }
            else
            {
                index_str = dataGridView1.CurrentRow.Index;
                peredachaID = Convert.ToInt32(dataGridView1[0, index_str].Value);

                string query4 = "UPDATE rabotniki SET r_dostup=1 WHERE r_id =" + Convert.ToString(peredachaID);

                OleDbCommand updat = new OleDbCommand(query4, myConnection);
                updat.ExecuteNonQuery();

                myConnection.Close();

                Form14 newForm = new Form14(this, peredachaID);
                newForm.Show();



            }
        }
    }
}
