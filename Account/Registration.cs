using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Account
{

    public partial class Registration : UserControl
    {
        bool activate1 = false;
        bool activate2 = false;
        public delegate void OkHandler(object source, MyEventArgs arg);
        public event OkHandler OkEvent;

        public Registration()
        {
            InitializeComponent();
        }

        private void Registration_Load(object sender, EventArgs e)
        {

        }

        public LinkLabel LinkLabel1
        {
            get { return linkLabel1; }
        }

        public TextBox TextBox1
        {
            get { return textBox1; }
        }

        public Label Label8
        {
            get { return label8; }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && comboBox1.Text != "" && textBox3.Text == textBox4.Text)
            {
                //MyEventArgsReg arg = new MyEventArgsReg();
                MyEventArgs arg = new MyEventArgs();
                if (OkEvent != null)
                {
                    arg.name = textBox1.Text;
                    arg.password = textBox4.Text;
                    arg.quastion = comboBox1.Text;
                    arg.answer = textBox1.Text;
                    OkEvent(this, arg);
                }
            }
            else
            {
                if (textBox1.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && comboBox1.Text != "" && textBox3.Text != textBox4.Text)
                    MessageBox.Show("Пароль не совпадает");
                else
                    MessageBox.Show("Заполните все поля");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            label7.Text = "";
            label8.Text = "";
        }

        private void textBox4_KeyUp(object sender, KeyEventArgs e)
        {
            Pass();
        }

        private void textBox3_KeyUp(object sender, KeyEventArgs e)
        {
            Pass();
        }

        void Pass()
        {
            if (activate1 && activate2)
            {
                if (textBox3.Text == textBox4.Text && textBox3.Text != "")
                {
                    label7.ForeColor = Color.Green;
                    label7.Text = "Пароли совпадают";
                }
                else
                {
                    if (textBox3.Text != "" || textBox4.Text != "")
                    {
                        label7.ForeColor = Color.Red;
                        label7.Text = "Пароли не совпадают";
                    }
                    else
                    {
                        label7.Text = "";
                    }
                }
            }
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            activate1 = true;
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            activate2 = true;
        }
    }
}
