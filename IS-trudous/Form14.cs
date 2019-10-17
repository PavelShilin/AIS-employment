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
    public partial class Form14 : Form
    {
        public int peredachaID;
        private OleDbConnection myConnection;
        public Form14()
        {
            InitializeComponent();
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            myConnection = new OleDbConnection(connectionString);
            myConnection.Open();
        }
        public Form14(Form5 f5,int perem)
        {
            InitializeComponent();
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            myConnection = new OleDbConnection(connectionString);
            myConnection.Open();
            peredachaID = f5.peredachaID;
            f5.Close();
        }

        private void Form14_Load(object sender, EventArgs e)
        {
            string query = "SELECT r_name, r_familiya, r_otchestvo,r_opit,r_obraz,r_pol,r_telephone,r_email,r_data,r_age FROM rabotniki WHERE r_id=" + Convert.ToString(peredachaID);


            OleDbDataAdapter dat = new OleDbDataAdapter(query, myConnection);

            DataTable dt1 = new DataTable();
            dat.Fill(dt1);
            //int status = Convert.ToInt32();
            imyatextBox1.Text = Convert.ToString(dt1.Rows[0][0]);
            familiyatextBox1.Text = Convert.ToString(dt1.Rows[0][1]);
            OtchestvotextBox1.Text = Convert.ToString(dt1.Rows[0][2]);
            OpitcomboBox1.Text = Convert.ToString(dt1.Rows[0][3]);
            ObrazcomboBox1.Text = Convert.ToString(dt1.Rows[0][4]);
            PolcomboBox1.Text = Convert.ToString(dt1.Rows[0][5]);
            textBox3.Text = Convert.ToString(dt1.Rows[0][6]);
            emailtextBox1.Text = Convert.ToString(dt1.Rows[0][7]);
            dateTimePicker1.Value = Convert.ToDateTime(dt1.Rows[0][8]);
            agetextBox1.Text= Convert.ToString(dt1.Rows[0][9]);

        }

        private void button2_Click(object sender, EventArgs e)
        {
           // MessageBox.Show(Convert.ToString(peredachaID));
            string query4 = "UPDATE rabotniki SET r_dostup=0 WHERE r_id =" + Convert.ToString(peredachaID);

            OleDbCommand updat = new OleDbCommand(query4, myConnection);
            updat.ExecuteNonQuery();
            myConnection.Close();

            Form5 newForm = new Form5(this);
            newForm.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query5 = string.Format("UPDATE rabotniki SET r_name = '{0}', r_familiya='{1}', r_otchestvo='{2}',r_opit='{3}',r_obraz='{4}',r_pol='{5}',r_telephone='{6}',r_email='{7}',r_data='{8}',r_age={9},r_dostup={11} WHERE r_id={10}", imyatextBox1.Text, familiyatextBox1.Text, OtchestvotextBox1.Text, OpitcomboBox1.Text, ObrazcomboBox1.Text, PolcomboBox1.Text, textBox3.Text, emailtextBox1.Text,dateTimePicker1.Value, Convert.ToInt32(agetextBox1.Text), peredachaID, 0);

            //string query4 = "UPDATE vakansii SET v_dostup=0 WHERE v_id =" + Convert.ToString(idselect);

            OleDbCommand updat = new OleDbCommand(query5, myConnection);
            updat.ExecuteNonQuery();
            myConnection.Close();
            Form5 newForm = new Form5(this);
            newForm.Show();
        }
    }
}
