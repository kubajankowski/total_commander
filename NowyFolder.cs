using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Commander
{
    public partial class NowyFolder : Form
    {
        public string sciezka1 { get; private set; }

        public NowyFolder(string sciezka)
        {
            InitializeComponent();
            sciezka1 = sciezka;
        }

        private void NowyFolder_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string activeDir = sciezka1;
            string path = Path.Combine(activeDir + textBox1.Text); 
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                MessageBox.Show("Katalog został utworzony", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                {
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Taki katalog już istnieje, podaj inną nazwę.", "UWAGA !",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
