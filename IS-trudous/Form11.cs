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


namespace IS_trudous
{
    public partial class Form11 : Form
    {
        public int indexstroki;
       
        private OleDbConnection myConnection;
        public Form11()
        {
            InitializeComponent();
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            myConnection = new OleDbConnection(connectionString);
            myConnection.Open();
        }
        public Form11(Form5 f5)
        {
            InitializeComponent();
            f5.Close();
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            myConnection = new OleDbConnection(connectionString);
            myConnection.Open();

        }
        public Form11(Form5 f5, int index_Str)
        {
            InitializeComponent();
            f5.Close();
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            myConnection = new OleDbConnection(connectionString);
            myConnection.Open();
            indexstroki = f5.indexGG;

        }
        private void Form11_Load(object sender, EventArgs e)
        {
            string query = "SELECT rabotniki.r_name, rabotniki.r_familiya, vakansii.v_name, v_zp, v_dop, v_telephone, v_address FROM vakansii INNER JOIN rabotniki ON(vakansii.v_obraz= rabotniki.r_obraz) AND(vakansii.v_opit = rabotniki.r_opit) WHERE rabotniki.r_id =" + Convert.ToString(this.indexstroki);



            OleDbCommand command = new OleDbCommand(query, myConnection);
            OleDbDataAdapter da = new OleDbDataAdapter(query, myConnection);



            dataGridView1.AllowUserToAddRows = false; //ne запрешаем пользователю самому добавлять строки

            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt; //выводим в грид

        }
        private void Form11_FormClosing(object sender, FormClosingEventArgs e)
        {
            myConnection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            myConnection.Close();
            Form5 newForm = new Form5(this);
            newForm.Show();
        }
    }
}
