using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1ewr
{
    public partial class Form1 : Form
    {
        private string path = @"info.dat";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Create| FileMode.Append)))
            {
                // записываем в файл значение каждого поля структуры
                
                    writer.Write(textBox1.Text);
                    writer.Write(textBox2.Text);
                    writer.Write(textBox3.Text);

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                while (reader.BaseStream.Position != reader.BaseStream.Length)
                {

                    string Authorname = reader.ReadString();
                    string bookName = reader.ReadString();
                    string bookHousName = reader.ReadString();

                    if (textBox4.Text.ToString() == "")
                    {
                        MessageBox.Show("Ви не ввели назву видавництва в пошуку");
                        return;
                    }

                    if (bookHousName == textBox4.Text.ToString())
                    {
                        richTextBox1.AppendText(" Автор: " + Authorname + "\n Назва книги: " + bookName + "\n Назва видавництва:" + bookHousName + "\n");
                    }

                }
            }

        }
    }
}
