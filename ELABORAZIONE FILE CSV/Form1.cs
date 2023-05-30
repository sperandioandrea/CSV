using System;
using System.Windows.Forms;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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

        //FUNZIONE 5: AGGIUNGERE UN RECORD IN CODA
        public void AggiuntaCoda(string coda1, string coda2, string coda3, char a = ',')
        {
            if (File.Exists(path))
            {
                using (StreamWriter sw = new StreamWriter(path, true))
                {
                    sw.WriteLine(coda1 + a + coda2 + a + coda3 + a);
                }
            }
            else
            {
                MessageBox.Show("Non esiste il file");
            }
        }
        //BOTTONE FUNZIONE 5
        private void button5_Click(object sender, EventArgs e)
        {
            AggiuntaCoda(textBox3.Text, textBox4.Text, textBox5.Text);
        }

        //FUNZIONE 6: VISUALIZZARE DEI DATI TRAMITE 3 CAMPI A SCELTA
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
        //DATAGRIDVIEW FUNZIONE 6
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        //FUNZIONE 7: RICERCA
        public string Ricerca()
        {
            string[] record = File.ReadAllLines(path);
            for (int i = 0; i < record.Length; i++)
            {
                string[] campi = record[i].Split(';');
                if (checkBox1.Checked == true) 
                { 
                    if (campi[0].ToLower() == textBox1.Text.ToLower())
                    {
                        return record[i];
                    }
                    if (checkBox2.Checked == true)
                    {
                        if (campi[1].ToLower() == textBox2.Text.ToLower())
                        {
                            return record[i];
                        }
                    }
                    if (checkBox3.Checked == true)
                    {
                        if (campi[2].ToLower() == textBox2.Text.ToLower())
                        {
                            return record[i];
                        }
                    }
                }
                
            }
            return "";
        }
        //BOTTONE FUNZIONE 7
        private void button6_Click(object sender, EventArgs e)
        {
            Ricerca();
        }

        //FUNZIONE 8: MODIFICA RECORD

        //BOTTONE FUNZIONE 8
        private void button7_Click(object sender, EventArgs e)
        {

        }
        public int ncampi;

        //FUNZIONE 9: CANCELLAZIONE LOGICA
        public bool CancellazioneLogica(string cancella)
        {
            bool c = false;
            string[] record = File.ReadAllLines(path);
            using (StreamWriter sw = new StreamWriter(path))
            {
                for (int i = 0; i < record.Length; i++)
                {
                    string[] campi = record[i].Split(';');
                    if (cancella.ToLower() == campi[0].ToLower())
                    {
                        campi[ncampi - 1] = "1";
                        record[i] = String.Join(";", campi);
                        c = true;
                        break;
                    }
                }
                for (int i = 0; i < record.Length; i++)
                    sw.WriteLine(record[i]);
            }
            return c;
        }
        //BOTTONE FUNZIONE 9
        private void button8_Click(object sender, EventArgs e)
        {
            CancellazioneLogica(textBox6.Text);
        }
    }
}
