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
    public partial class Form13 : Form
    {
        public int indexstroki;

        private OleDbConnection myConnection;
        public Form13()
        {
            InitializeComponent();
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            myConnection = new OleDbConnection(connectionString);
            myConnection.Open();
        }
        public Form13(Form3 f3,int idselect)
        {
            InitializeComponent();
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            myConnection = new OleDbConnection(connectionString);
            myConnection.Open();
            f3.Close();
            indexstroki = f3.peredachaID;
        }

        private void Form13_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(Convert.ToString(this.indexstroki));
            string query = "SELECT rabotniki.r_name, rabotniki.r_familiya,rabotniki.r_otchestvo , rabotniki.r_age, rabotniki.r_pol,rabotniki.r_telephone,rabotniki.r_email  FROM rabotniki INNER JOIN vakansii ON(vakansii.v_obraz= rabotniki.r_obraz) AND(vakansii.v_opit = rabotniki.r_opit) WHERE vakansii.v_id =" + Convert.ToString(this.indexstroki);


           // OleDbCommand command = new OleDbCommand(query, myConnection);
            OleDbDataAdapter da = new OleDbDataAdapter(query, myConnection);

            dataGridView1.AllowUserToAddRows = false; //ne запрешаем пользователю самому добавлять строки

            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt; //выводим в грид
        }

        private void button1_Click(object sender, EventArgs e)
        {
            myConnection.Close();
            Form3 newForm = new Form3(this);
            newForm.Show();
        }
    }
}
