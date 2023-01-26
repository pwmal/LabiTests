using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3_Kurs_2_semestr_Labi
{
    public partial class Form1 : Form
    {
        double firstNum;
        string operation;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = "0";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == "0" && textBox1.Text != null) || textBox1.Text == "Нельзя делить на ноль")
            {
                textBox1.Text = (sender as Button).Text;
            }
            else
            {
                textBox1.Text = textBox1.Text + (sender as Button).Text;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                operation = (sender as Button).Text;
                firstNum = Convert.ToSingle(textBox1.Text);
                textBox2.Text = firstNum + " " + (sender as Button).Text;
                textBox1.Text = "";
            }
        }
        private void button16_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                operation = "x^y";
                firstNum = Convert.ToSingle(textBox1.Text);
                textBox2.Text = firstNum + "^y ";
                textBox1.Text = "";
            }
            
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                operation = "√";
                firstNum = Convert.ToSingle(textBox1.Text);
                textBox2.Text = "√ " + firstNum;
                textBox1.Text = "";
            }
            
        }

        private void button15_Click(object sender, EventArgs e)
        {
            double secondNum;
            double Result;
            if (operation == "√")
            {
                Result = Math.Sqrt(firstNum);
                textBox1.Text = Convert.ToString(Result);
                firstNum = Result;
                textBox2.Text = "";
            }
            else
            {
                secondNum = Convert.ToSingle(textBox1.Text);

                if (operation == "+")
                {
                    Result = (firstNum + secondNum);
                    textBox1.Text = Convert.ToString(Result);
                    firstNum = Result;
                    textBox2.Text = "";
                }
                if (operation == "-")
                {
                    Result = (firstNum - secondNum);
                    textBox1.Text = Convert.ToString(Result);
                    firstNum = Result;
                    textBox2.Text = "";
                }
                if (operation == "*")
                {
                    Result = (firstNum * secondNum);
                    textBox1.Text = Convert.ToString(Result);
                    firstNum = Result;
                    textBox2.Text = "";
                }
                if (operation == "x^y")
                {
                    Result = Math.Pow(firstNum, secondNum);
                    textBox1.Text = Convert.ToString(Result);
                    firstNum = Result;
                    textBox2.Text = "";
                }
                if (operation == "/")
                {
                    if (secondNum == 0)
                    {
                        textBox1.Text = "Нельзя делить на ноль";

                    }
                    else
                    {
                        Result = (firstNum / secondNum);
                        textBox1.Text = Convert.ToString(Result);
                        firstNum = Result;
                        textBox2.Text = "";
                    }
                }
            }
            
        }

        private void button19_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button20_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void button18_Click(object sender, EventArgs e)
        {
            textBox1.Text += ",";
        }
    }
}
