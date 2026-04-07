using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MassIndex_calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            float masa = float.Parse(textBox1.Text);
            float inaltime = float.Parse(textBox2.Text);
            BMICalculator BMI = new BMICalculator(inaltime, masa);
            PICalculator PI = new PICalculator(inaltime, masa);



            textBox3.Text = BMI.Calculate();
            textBox4.Text = PI.Calculate();

            textBox5.Text = BMI.WeightCategory();
            textBox6.Text = PI.WeightCategory();



            textBox7.Text = BMI.IdealWeight();
            textBox8.Text = PI.IdealWeight();

        }

       

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
        
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
