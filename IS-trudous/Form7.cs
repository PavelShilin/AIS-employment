using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Configuration;
using System.Data.OleDb;



namespace IS_trudous
{

    public partial class Form7 : Form
    {
        private OleDbConnection myConnection;
        private string otdate;
        private string dodate;
        public Form7()
        {
            InitializeComponent();
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            myConnection = new OleDbConnection(connectionString);
            myConnection.Open();

        }


        private void Form7_Load(object sender, EventArgs e)
        {
            Chart1.Series.Clear();
            // Форматировать диаграмму
            Chart1.BackColor = Color.Gray;
            Chart1.BackSecondaryColor = Color.WhiteSmoke;
            Chart1.BackGradientStyle = GradientStyle.DiagonalRight;

            Chart1.BorderlineDashStyle = ChartDashStyle.Solid;
            Chart1.BorderlineColor = Color.Gray;
            Chart1.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;

            // Форматировать область диаграммы
            Chart1.ChartAreas[0].BackColor = Color.Wheat;

            // Добавить и форматировать заголовок
            Chart1.Titles.Add("Соотношение мужчин и женщин");
            Chart1.Titles[0].Font = new Font("Utopia", 16);

            Chart1.Series.Add(new Series("ColumnSeries")
            {
                ChartType = SeriesChartType.Pie
            });
            string sqlExpression = "SELECT * FROM rabotniki";
            OleDbCommand command = new OleDbCommand(sqlExpression, myConnection);
            OleDbDataReader reader = command.ExecuteReader();
            double col_gen = 0;
            double col_mug = 0;
            while (reader.Read()) // построчно считываем данные
            {
                object id = reader.GetValue(0);
                if (Convert.ToString(reader.GetValue(6)) == "муж") { col_mug++; } else {  col_gen++; }
               //MessageBox.Show(Convert.ToString(reader.GetValue(6)));
                //Console.WriteLine("{0} \t{1} \t{2}", id, name, age);
            }
            // Salary series data
            



            double procent_gen = col_gen*100/(col_gen+ col_mug);
            double procent_mug = col_mug * 100 / (col_gen + col_mug);

            double[] yValues = { procent_mug, procent_gen  };
            string[] xValues = { "% Мужчин= "+ Convert.ToString(Math.Round(yValues[0],1)), "% Женщин= "+ Convert.ToString(Math.Round(yValues[1], 1) )};
            Chart1.Series["ColumnSeries"].Points.DataBindXY(xValues, yValues);

            Chart1.ChartAreas[0].Area3DStyle.Enable3D = true;
        }



        private void button1_Click(object sender, EventArgs e)
        {
       

        }

        private void Form7_Paint(object sender, PaintEventArgs e)
        {
            //chart = new Chart();
        }
        void PrintPageHandler(object sender, PrintPageEventArgs e)
        {
            //Замените на e.Graphics.DrawImage или любую другую логику
            e.Graphics.DrawString("Привет", new Font("Arial", 14), Brushes.Black, 0, 0);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            PrintDocument printDoc = new PrintDocument();
            printDoc.PrintPage += PrintPageHandler;
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDoc;
            if (printDialog.ShowDialog() == DialogResult.OK) printDialog.Document.Print();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            myConnection.Close();
            this.Close();
        }

        private void Chart1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Chart1.Series.Clear();
            // Форматировать диаграмму
            Chart1.BackColor = Color.Gray;
            Chart1.BackSecondaryColor = Color.WhiteSmoke;
            Chart1.BackGradientStyle = GradientStyle.DiagonalRight;

            Chart1.BorderlineDashStyle = ChartDashStyle.Solid;
            Chart1.BorderlineColor = Color.Gray;
            Chart1.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;

            // Форматировать область диаграммы
            Chart1.ChartAreas[0].BackColor = Color.Wheat;

            // Добавить и форматировать заголовок
            //Chart1.Titles.Add("Соотношение мужчин и женщин");
            Chart1.Titles[0].Font = new Font("Utopia", 16);

            Chart1.Series.Add(new Series("ColumnSeries")
            {
                ChartType = SeriesChartType.Pie
            });
            //конвертирование дат
            otdate = Convert.ToString(dateTimePicker1.Value);
            otdate = otdate.Replace(".", "/");
            otdate = otdate.Remove(10, 8);
            otdate = "#" + otdate + "#";
            char mesyac1 = otdate[1];
            char mesyac2 = otdate[2];
            char day1 = otdate[4];
            char day2 = otdate[5];
            otdate = otdate.Remove(0, 6);
            otdate = "#" + day1 + day2 + "/" + mesyac1 + mesyac2 + otdate;
            dodate = Convert.ToString(dateTimePicker2.Value);
            dodate = dodate.Replace(".", "/");
            dodate = dodate.Remove(10, 8);
            dodate = "#" + dodate + "#";
            char mesyac11 = dodate[1];
            char mesyac22 = dodate[2];
            char day11 = dodate[4];
            char day22 = dodate[5];
            dodate = otdate.Remove(0, 6);
            dodate = "#" + day11 + day22 + "/" + mesyac11 + mesyac22 + dodate;

            string sqlExpression = string.Format("SELECT * FROM rabotniki  WHERE( ((rabotniki.r_data)>={0}) AND ((rabotniki.r_data)<={1}))", otdate,dodate);
            OleDbCommand command = new OleDbCommand(sqlExpression, myConnection);
            OleDbDataReader reader = command.ExecuteReader();
            double col_gen = 0;
            double col_mug = 0;
            while (reader.Read()) // построчно считываем данные
            {
                object id = reader.GetValue(0);
                if (Convert.ToString(reader.GetValue(6)) == "муж") { col_mug++; } else { col_gen++; }
                //MessageBox.Show(Convert.ToString(reader.GetValue(6)));
                //Console.WriteLine("{0} \t{1} \t{2}", id, name, age);
            }
            // Salary series data




            double procent_gen = col_gen * 100 / (col_gen + col_mug);
            double procent_mug = col_mug * 100 / (col_gen + col_mug);

            double[] yValues = { procent_mug, procent_gen };
            


            string[] xValues = { "% Мужчин= " + Convert.ToString(Math.Round(yValues[0], 1)), "% Женщин= " + Convert.ToString(Math.Round(yValues[1], 1)) };
            Chart1.Series["ColumnSeries"].Points.DataBindXY(xValues, yValues);

            Chart1.ChartAreas[0].Area3DStyle.Enable3D = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            otdate = Convert.ToString(dateTimePicker1.Value);
            otdate = otdate.Replace(".", "/");
            otdate = otdate.Remove(10,8);
            otdate = "#"+otdate+"#";
            char mesyac1 = otdate[1];
            char mesyac2 = otdate[2];
            char day1 = otdate[4];
            char day2 = otdate[5];
            otdate = otdate.Remove(0, 6);
            otdate = "#" + day1 + day2 + "/" + mesyac1 + mesyac2 + otdate;
            //MessageBox.Show("#"+day1+day2+"/"+mesyac1+ mesyac2+otdate);
           // MessageBox.Show(Convert.ToString(dateTimePicker1.Value));
        }
    }
}

