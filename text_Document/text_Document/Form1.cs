using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;//New Libary
namespace text_Document
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string fileName, filepath;
        StreamWriter sw;

        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                filepath = folderBrowserDialog1.SelectedPath.ToString();
                textBox1.Text = filepath;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(openFileDialog1.FileName);
                string row = sr.ReadLine();
                while (row != null)
                {
                    listBox1.Items.Add(row);
                    row = sr.ReadLine();
                }
                sr.Close();
            }
        }

        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Text Files|*.txt";
            saveFileDialog1.Title = "Text document recording";
            saveFileDialog1.ShowDialog();
            StreamReader sw = new StreamReader(saveFileDialog1.FileName);
            sw.WriteLine(richTextBox1.Text);
            sw.Close();
            MessageBox.Show("File Save !");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fileName = textBox2.Text;
            sw = File.CreateText(filepath + "\\" + fileName + ".txt");
            sw.Close();
        }
    }
}
