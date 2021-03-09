using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
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

        private void button1_Click(object sender, EventArgs e)
        {
            
                string num1 = textBox1.Text;
                string num2 = textBox2.Text;

                string regex = @"^[0-9]+$";

            if (Regex.Match(num1, regex).Success && Regex.Match(num2, regex).Success)
            {
                Calculate(double.Parse(num1), double.Parse(num2));
            }
            else
                {
                    MessageBox.Show(" Enter A Valid Number ");
                }
            }


        private void Calculate(double num1, double num2)
        {
            // double num1 = double.Parse(textBox1.Text);
            //double num2 = double.Parse(textBox2.Text);
            double calculated_value = 0;
           // checkForEmptySpace();
            if (radioButton1.Checked)
            {

                calculated_value = num1 + num2;

            }
            else if (radioButton2.Checked)
            {
                calculated_value = num1 - num2;

            }
            else if (radioButton3.Checked)
            {
                calculated_value = num1 * num2;

            }
            else if (radioButton4.Checked)
            {


                calculated_value = num1 / num2;



            }
            MessageBox.Show($"{calculated_value}");
        }
        /* private void checkForEmptySpace()
        {
            if (textBox1.Text == "")
                textBox1.Text = "0";
            if (textBox1.Text == "")
                textBox1.Text = "0";
        }*/
    }
}

