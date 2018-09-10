using System;
using System.Windows.Forms;

namespace linapl.CalculatorApp
{
    public partial class Form1 : Form
    {
        private MathOperation _mathOp;

        public Form1()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            _mathOp = new MathOperation();
            _mathOp.mathSign = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn1_Click(object sender, EventArgs e)
        {
            _mathOp.AddDigit(1);
            textBox1.Text += 1;
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            _mathOp.AddDigit(2);
            textBox1.Text += 2;
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            _mathOp.AddDigit(3);
            textBox1.Text += 3;
        }

        private void multiplyBtn_Click(object sender, EventArgs e)
        {
            if (_mathOp.mathSign != "" || _mathOp.firstDigit != 0 && _mathOp.firstDigit != 0)
            {
                _mathOp.GoMathOperation();
            }
            else
            {
                _mathOp.firstDigit = _mathOp.secondDigit;
                _mathOp.secondDigit = 0;
            }
            _mathOp.mathSign = "*";
            textBox1.Text = _mathOp.firstDigit + " " + _mathOp.mathSign + " ";
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            _mathOp.AddDigit(4);
            textBox1.Text += 4;
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            _mathOp.AddDigit(5);
            textBox1.Text += 5;
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            _mathOp.AddDigit(6);
            textBox1.Text += 6;
        }

        private void divideBtn_Click(object sender, EventArgs e)
        {
            if (_mathOp.mathSign != "" || _mathOp.firstDigit != 0 && _mathOp.firstDigit != 0)
            {
                _mathOp.GoMathOperation();
            }
            else
            {
                _mathOp.firstDigit = _mathOp.secondDigit;
                _mathOp.secondDigit = 0;
            }
            _mathOp.mathSign = "/";
            textBox1.Text = _mathOp.firstDigit + " " + _mathOp.mathSign + " ";
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            _mathOp.AddDigit(7);
            textBox1.Text += 7;
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            _mathOp.AddDigit(8);
            textBox1.Text += 8;
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            _mathOp.AddDigit(9);
            textBox1.Text += 9;
        }

        private void plusBtn_Click(object sender, EventArgs e)
        {
            if (_mathOp.mathSign != "" || _mathOp.firstDigit != 0 && _mathOp.firstDigit != 0)
            {
                _mathOp.GoMathOperation();
            }
            else
            {
                _mathOp.firstDigit = _mathOp.secondDigit;
                _mathOp.secondDigit = 0;
            }
            _mathOp.mathSign = "+";
            textBox1.Text = _mathOp.firstDigit + " " + _mathOp.mathSign + " ";
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            _mathOp.firstDigit = 0;
            _mathOp.secondDigit = 0;
            textBox1.Text = "";
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            _mathOp.AddDigit(0);
            textBox1.Text += 0;
        }

        private void resultBtn_Click(object sender, EventArgs e)
        {
            if (_mathOp.mathSign != "")
            {
                _mathOp.GoMathOperation();
            }
            
            _mathOp.secondDigit = 0;
            textBox1.Text = _mathOp.firstDigit.ToString();
        }

        private void minusBtn_Click(object sender, EventArgs e)
        {
            if (_mathOp.mathSign != "" || _mathOp.firstDigit != 0 && _mathOp.firstDigit != 0)
            {
                _mathOp.GoMathOperation();
            }
            else
            {
                _mathOp.firstDigit = _mathOp.secondDigit;
                _mathOp.secondDigit = 0;
            }
            _mathOp.mathSign = "-";
            textBox1.Text = _mathOp.firstDigit + " " + _mathOp.mathSign + " ";
        }
    }
}
