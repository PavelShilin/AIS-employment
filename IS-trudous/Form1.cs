using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IS_trudous
{
    public partial class Form1 : Form
    {

        public string user;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "Admin" && textBox2.Text == "1" || textBox1.Text == "admin" && textBox2.Text == "1")
            {
                user = "admin";
                Form2 newForm = new Form2(this);
                newForm.Show();
                
            }
            else
            if (textBox1.Text == "user" && textBox2.Text == "1" || textBox1.Text == "User" && textBox2.Text == "1")
            {
                user = "user";
                Form2 newForm = new Form2(this);
                newForm.Show();

            }     
            else
            {
                MessageBox.Show("Неверное имя пользователя или пароль");

            }
        }

        
    }
}
