using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BintoDec_a_DectoBin_Stach
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string DecToBin(int n)
        {
            string binarni = string.Empty;

            while (n > 0)
            {
                int pomocna = n % 2;
                binarni = pomocna + binarni;
                n = n / 2;
            }

            return binarni;
        }
                

        double BinToDec(string binarni)
        {
            binarni = binarni.Trim();
            int[] pole = new int[binarni.Length];

            int x = -1;
            for (int i = pole.Length - 1; i >= 0; i--)
            {
                x++;
                pole[x] = binarni[i] - '0'; 
            }

            double vysledek = 0;
            for (int i = 0; i < pole.Length; i++)
            {
                vysledek = vysledek + (pole[i] * Math.Pow(2, i));
            }

            return vysledek;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                label1.Text = DecToBin(int.Parse(textBox1.Text));
            }catch(FormatException ex) { label1.Text = "Zadej cislo"; }
        }

        

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                label2.Text = BinToDec(textBox2.Text).ToString();                
            }
            catch (FormatException ex) { label2.Text = "Zadej cislo"; }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '1') && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
    }
}
