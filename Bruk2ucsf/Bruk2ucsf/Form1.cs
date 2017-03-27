using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bruk2ucsfGui
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog.FileName;
                button2.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.DefaultExt = "ucsf";
            saveFileDialog.Filter = "Ucsf-files (*.ucsf)|*.ucsf";

       

           
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string cmd = "bruk2ucsf.exe " + textBox1.Text + " " + saveFileDialog.FileName;
                    try
                    {
                        Process.Start("bruk2ucsf.exe", '"' + textBox1.Text + '"' + " " + '"' + saveFileDialog.FileName + '"');
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Conversion failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            
        }
    }
}
