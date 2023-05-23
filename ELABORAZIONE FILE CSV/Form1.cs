using System;
using System.Windows.Forms;
using System.IO;

namespace ELABORAZIONE_FILE_CSV
{
    public partial class Form1 : Form
    {
        public string path; //nome del file
        public int numerocampi;
        public Form1()
        {
            InitializeComponent();

            path = Path.GetFullPath("..\\..\\..\\CSV\\sperandio1.csv");
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
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
        public int ContaCampi(char a = ";")
        {
            string[] record = File.ReadAllLines(path);
            numerocampi = record[0].Split(a).Length;
            return numerocampi;
        }
        //BOTTONE FUNZIONE 2
        private void button2_Click(object sender, EventArgs e)
        {
            ContaCampi();
        }
    }
}
