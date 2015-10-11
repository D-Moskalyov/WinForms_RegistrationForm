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
    
    public partial class Login : UserControl
    {
        public delegate void OkHandler(object source, MyEventArgs arg);
        public event OkHandler OkEvent;

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        public LinkLabel LinkLabel1
        {
            get { return linkLabel1; }
        }
        public LinkLabel LinkLabel2
        {
            get { return linkLabel2; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                //MyEventArgsLog arg = new MyEventArgsReg();
                MyEventArgs arg = new MyEventArgs();
                if (OkEvent != null)
                {
                    arg.name = textBox1.Text;
                    arg.password = textBox2.Text;
                    OkEvent(this, arg);
                }
            }
            else
            {
                MessageBox.Show("Заполните все поля");
            }
        }
    }
}
