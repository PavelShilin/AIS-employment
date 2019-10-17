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
    public partial class Form12 : Form
    {
        private int idselect;
        private OleDbConnection myConnection;
        public Form12()
        {
            InitializeComponent();
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            myConnection = new OleDbConnection(connectionString);
            myConnection.Open();
        }
        public Form12(Form3 f3)
        {
            InitializeComponent();
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            myConnection = new OleDbConnection(connectionString);
            myConnection.Open();
            f3.Close();

        }
        public Form12(Form3 f3,int peredacha)
        {
            InitializeComponent();
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            myConnection = new OleDbConnection(connectionString);
            myConnection.Open();
            f3.Close();
            idselect = f3.peredachaID;


        }


        private void Form12_Load(object sender, EventArgs e)
        {
            string query = "SELECT v_name, v_opit, v_obraz,v_pol,v_zp,v_tip,v_dop,v_telephone,v_address FROM vakansii WHERE v_id="+Convert.ToString(idselect);


            OleDbDataAdapter dat = new OleDbDataAdapter(query, myConnection);

            DataTable dt1 = new DataTable();
            dat.Fill(dt1);
            //int status = Convert.ToInt32();
            textBox1.Text = Convert.ToString(dt1.Rows[0][0]);
             OpitcomboBox1.Text = Convert.ToString(dt1.Rows[0][1]);
            ObrazcomboBox1.Text = Convert.ToString(dt1.Rows[0][2]);
           PolcomboBox1.Text = Convert.ToString(dt1.Rows[0][3]);
            ZPtextBox2.Text = Convert.ToString(dt1.Rows[0][4]);
            comboBox1.Text = Convert.ToString(dt1.Rows[0][5]);
            textBox2.Text = Convert.ToString(dt1.Rows[0][6]);
            textBox3.Text = Convert.ToString(dt1.Rows[0][7]);
            textBox4.Text = Convert.ToString(dt1.Rows[0][8]);
   

        }

            private void button2_Click(object sender, EventArgs e)
            {
            string query4 = "UPDATE vakansii SET v_dostup=0 WHERE v_id =" + Convert.ToString(idselect);

            OleDbCommand updat = new OleDbCommand(query4, myConnection);
            updat.ExecuteNonQuery();
            myConnection.Close();
                Form3 newForm = new Form3(this);
                newForm.Show();
            }

        private void button1_Click(object sender, EventArgs e)
        {
            string query5 = string.Format("UPDATE vakansii SET v_name = '{0}', v_opit='{1}', v_obraz='{2}',v_pol='{3}',v_zp={4},v_tip='{5}',v_dop='{6}',v_telephone='{7}',v_address='{8}',v_dostup={10} WHERE v_id={9}", textBox1.Text, OpitcomboBox1.Text, ObrazcomboBox1.Text, PolcomboBox1.Text, Convert.ToInt32(ZPtextBox2.Text), comboBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, idselect, 0);

            //string query4 = "UPDATE vakansii SET v_dostup=0 WHERE v_id =" + Convert.ToString(idselect);

            OleDbCommand updat = new OleDbCommand(query5, myConnection);
            updat.ExecuteNonQuery();
            myConnection.Close();
            Form3 newForm = new Form3(this);
            newForm.Show();

        }
    }
    }
