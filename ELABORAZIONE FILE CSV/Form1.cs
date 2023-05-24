using System;
using System.Windows.Forms;
using System.IO;

namespace ELABORAZIONE_FILE_CSV
{
    public partial class Form1 : Form
    {
        public string path; //nome del file
        public int numerocampi;
        public int lunghezzamassima;
        public Form1()
        {
            InitializeComponent();

            path = Path.GetFullPath("..\\..\\..\\CSV\\sperandio1.csv");
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        //FUNZIONE VISUALIZZA
        public void Visualizza()
        {
            dataGridView1.Rows.Clear();
            string[] record = File.ReadAllLines(path);
            for (int i = 0; i < record.Length; i++)
            {
                string[] campi = record[i].Split(';');
                if (campi[1] == "")
                {
                    dataGridView1.Rows.Add(campi[0]);
                }
                else
                {
                    dataGridView1.Rows.Add(campi[0], campi[1], campi[2]);
                }
            }
        }

        //FUNZIONE 1: AGGIUNTA
        public void Aggiunta(char a = ';')
        {
            string[] record = File.ReadAllLines(path);
            if (File.Exists(path))
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    Random r = new Random();
                    record[0] += ";miovalore";
                    sw.WriteLine(record[0]);

                    for (int i = 1; i < record.Length; i++)
                    {
                        record[i] += a + r.Next(10, 20).ToString();
                        sw.WriteLine(record[i]); 
                    }
                }
            }
        }
        //BOTTONE FUNZIONE 1
        private void button1_Click(object sender, EventArgs e)
        {
            Aggiunta();
        }

        //FUNZIONE 2: CONTACAMPI
        public int ContaCampi(char a = ';')
        {
            string[] record = File.ReadAllLines(path);
            numerocampi = record[0].Split(a).Length;
            return numerocampi;
        }
        //BOTTONE FUNZIONE 2
        private void button2_Click(object sender, EventArgs e)
        {
            ContaCampi();
            MessageBox.Show("Il numero dei campi è: " + numerocampi);
        }

        //FUNZIONE 3: LUNGHEZZA MAX RECORD
        public int LunghezzaMaxRecord(char a = ';')
        {
            string[] record = File.ReadAllLines(path);
            for (int i = 0; i < record.Length; i++)
            {
                string[] campi = record[i].Split(a);
                for (int j = 0; j < numerocampi; j++)
                {
                    if (campi[j].Length > lunghezzamassima)
                    {
                        lunghezzamassima = campi[j].Length;
                    }
                    if (campi[j].Length == 0)
                    {
                        break;
                    }
                }
            }
            return lunghezzamassima;    
        }
        //BOTTONE FUNZIONE 3
        private void button3_Click(object sender, EventArgs e)
        {
            LunghezzaMaxRecord();
            MessageBox.Show("La lunghezza massima dei record presenti è: " + lunghezzamassima);
        }

        //FUNZIONE 4: INSERIMENTO NUMERO DI SPAZI NEL RECORD
        public void NumeroSpazi()
        {
            string[] record = File.ReadAllLines(path);
            using (StreamWriter sw = new StreamWriter(path))
            {
                for (int i = 0; i < record.Length; i++)
                {
                    record[i] = record[i].PadRight(200);   
                    sw.WriteLine(record[i]);
                }
            }
            
        }
        //BOTTONE FUNZIONE 4
        private void button4_Click(object sender, EventArgs e)
        {
            NumeroSpazi();
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
