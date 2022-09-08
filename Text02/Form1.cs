using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Text02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamWriter streamWriter = new StreamWriter(@"..\..\soubory\text.txt");
            streamWriter.WriteLine("První");
            streamWriter.WriteLine("Druhý");
            streamWriter.Write('A');
            streamWriter.Write("***");
            streamWriter.Write('X');
            streamWriter.Close();
            StreamReader streamReader = new StreamReader(openFileDialog1.FileName);
            int i = 0;
            int pM = 0, pV = 0, pC = 0;
            while (!streamReader.EndOfStream)
            {
                i++;
                string s = streamReader.ReadLine();
                if (char.IsLower(s[i])) ++pM;
                else if (char.IsUpper(s[i])) ++pV;
                else if (char.IsNumber(s[i])) ++pC;

            }
            StreamWriter sw = new StreamWriter(openFileDialog1.FileName, true);
            streamWriter.WriteLine("Pocet malych: " + pM);
            streamWriter.WriteLine("Pocet velkych: " + pV);
            streamWriter.WriteLine("Pocet cislic: " + pC);
            streamWriter.Close();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                listBox1.Items.Clear();
                StreamReader sReader = new StreamReader(openFileDialog1.FileName);
                while (!sReader.EndOfStream)
                {

                    string s = streamReader.ReadLine();
                    listBox1.Items.Add(s);
                }
            }
            else
            {
                MessageBox.Show("Nebyl vybrán žádný soubor, ty nulo!");
                //listBox3.Items.Add("nebyl vybrán soubor");
            }
}
    }
}
