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
    public partial class Form9 : Form
    {
        private OleDbConnection myConnection;
        public Form9()
        {
            InitializeComponent();
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            myConnection = new OleDbConnection(connectionString);
            myConnection.Open();
        }


        private void button2_Click(object sender, EventArgs e)
        {
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

        private void Chart1_Click(object sender, EventArgs e)
        {

        }

        private void Form9_Load(object sender, EventArgs e)
        {
            string sqlExpression = "SELECT * FROM rabotniki";
            OleDbCommand command = new OleDbCommand(sqlExpression, myConnection);
            OleDbDataReader reader = command.ExecuteReader();
            int bez = 0;
            int srednee = 0;
            int special = 0;
            int visshee = 0;
            int neokvisshee = 0;


            while (reader.Read()) // построчно считываем данные
            {
                object id = reader.GetValue(0);
                if (Convert.ToString(reader.GetValue(5)) == "без") { bez++; } else if (Convert.ToString(reader.GetValue(5)) == "Среднее") { srednee++; } else if (Convert.ToString(reader.GetValue(5)) == "Высшее") { visshee++; } else if (Convert.ToString(reader.GetValue(5)) == "Среднее специальное") { special++; } else { neokvisshee++; }


            }

            // Data arrays.
            string[] seriesArray = { "Без образования", "Среднее", "Высшее","Среднее специальное","Неполное высшее"};
            int[] pointsArray = { bez, srednee,visshee,special,neokvisshee };

            // Set palette.
            this.Chart1.Palette = ChartColorPalette.SeaGreen;

            // Set title.
            this.Chart1.Titles.Add("Образование");

            // Add series.
            for (int i = 0; i < seriesArray.Length; i++)
            {
                // Add series.
                Series series = this.Chart1.Series.Add(seriesArray[i]);

                // Add point.
                series.Points.Add(pointsArray[i]);
            }
            myConnection.Close();
        }
    }
}
