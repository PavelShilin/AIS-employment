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
    public partial class Form8 : Form
    {
        private OleDbConnection myConnection;
        public Form8()
        {
            InitializeComponent();
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            myConnection = new OleDbConnection(connectionString);
            myConnection.Open();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            myConnection.Close();
            this.Close();
        }
        void PrintPageHandler(object sender, PrintPageEventArgs e)
        {
            //Замените на e.Graphics.DrawImage или любую другую логику
            e.Graphics.DrawString("Привет", new Font("Arial", 14), Brushes.Black, 0, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PrintDocument printDoc = new PrintDocument();
            printDoc.PrintPage += PrintPageHandler;
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDoc;
            if (printDialog.ShowDialog() == DialogResult.OK) printDialog.Document.Print();
        }

        private void Form8_Load(object sender, EventArgs e)
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
            Chart1.Titles.Add("Возрастные категории");
            Chart1.Titles[0].Font = new Font("Utopia", 16);

            Chart1.Series.Add(new Series("ColumnSeries")
            {
                ChartType = SeriesChartType.Pie
            });
            string sqlExpression = "SELECT * FROM rabotniki";
            OleDbCommand command = new OleDbCommand(sqlExpression, myConnection);
            OleDbDataReader reader = command.ExecuteReader();
            double molodie = 0;
            double srednee = 0;
            double starie = 0;

            while (reader.Read()) // построчно считываем данные
            {
                object id = reader.GetValue(0);
                if (Convert.ToInt32(reader.GetValue(8)) < 30) { molodie++; } else if (Convert.ToInt32(reader.GetValue(8)) > 50) { starie++; } else { srednee++; };


            }
            // Salary series data




            //double procent_gen = col_gen * 100 / (col_gen + col_mug);
           // double procent_mug = col_mug * 100 / (col_gen + col_mug);

            double[] yValues = { molodie, srednee, starie };
            string[] xValues = { "Меньше 30 лет-" + Convert.ToString(Math.Round(yValues[0], 1)) + " Человек(а)", "Средние года-" + Convert.ToString(Math.Round(yValues[1], 1)) + " Человек(а)", "Старше 50-" + Convert.ToString(yValues[2])+" Человек(а)" };
            Chart1.Series["ColumnSeries"].Points.DataBindXY(xValues, yValues);

            Chart1.ChartAreas[0].Area3DStyle.Enable3D = true;
        }
    }
}
