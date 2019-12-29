using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ean12 = this.textBox1.Text;
            string eanDigit = CalculateChecksum(ean12).ToString();
            string eanOk = ean12.ToString() + eanDigit.ToString();
            this.label2.Text = eanOk;
            Clipboard.SetDataObject(eanOk);
            this.label3.Visible = true;
        }

        public static int CalculateChecksum(string code)
        {
            if (code == null || code.Length != 12)
                MessageBox.Show("不是12位数,请重新输入");
                //throw new ArgumentException("Code length should be 12, i.e. excluding the checksum digit");
                

            int sum = 0;
            for (int i = 0; i < 12; i++)
            {
                int v;
                if (!int.TryParse(code[i].ToString(), out v))
                    throw new ArgumentException("Invalid character encountered in specified code.");
                sum += (i % 2 == 0 ? v : v * 3);
            }
            int check = 10 - (sum % 10);
            return check % 10;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


	
    }
}
