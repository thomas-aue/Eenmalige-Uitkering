using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EenmaligeUitkering
{
    public partial class Form1 : Form
    {        
        int years = 0;
        double maandsalaris;
        double uitkering;

        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "0.0";
        }
        
        private void Button1_Click(object sender, EventArgs e)
        {
            int grens = 1425;
            maandsalaris = double.Parse(textBox1.Text);
            
            if (years < 21 && comboBox1.Text == "Ongehuwd")
            {
                grens = 1300;
            }

            if (maandsalaris < grens)
            {
                uitkering = maandsalaris * 12 * 0.0175;
                if (uitkering < 250)
                {
                    uitkering = 250;
                }
            }
            else
                uitkering = 0;

            label1.Text = "€" + uitkering.ToString();
            maandsalaris = 0;
            uitkering = 0;
        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            years = DateTime.Now.Year - dateTimePicker1.Value.Year;

            if (dateTimePicker1.Value.AddYears(years) > DateTime.Now) years--;
        }

        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && textBox1.Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, "  ^ [0-9]"))
            {
                textBox1.Text = "";
            }
        }
    }
}