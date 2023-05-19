using System;
using System.Windows.Forms;
using System.IO;

namespace ELABORAZIONE_FILE_CSV
{
    public partial class Form1 : Form
    {
        public string path;
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
            string[] linea = File.ReadAllLines(path);
            if (File.Exists(path))
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    Random r = new Random();
                    linea[0] += ";miovalore";
                    sw.WriteLine(linea[0]);

                    for (int i = 1; i < linea.Length; i++)
                    {
                        linea[i] += a + r.Next(10, 20).ToString();
                        sw.WriteLine(linea[i]); 
                    }
                }
            }
        }
        //BOTTONE FUNZIONE 1
        private void button1_Click(object sender, EventArgs e)
        {
            Aggiunta();
        }
    }
}
