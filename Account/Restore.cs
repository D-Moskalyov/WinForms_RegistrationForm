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
    
    public partial class Restore : UserControl
    {
        public delegate void OkHandler(object source, MyEventArgs arg);
        public event OkHandler OkEvent;

        public Restore()
        {
            InitializeComponent();
            //Class1 cl1 = new Class1();
        }

        private void Restore_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && comboBox1.Text != "")
            {
                //MyEventArgsRes arg = new MyEventArgsReg();
                MyEventArgs arg = new MyEventArgs();
                if (OkEvent != null)
                {
                    arg.name = textBox1.Text;
                    arg.quastion = comboBox1.Text;
                    arg.answer = textBox2.Text;
                    OkEvent(this, arg);
                }
            }
            else
            {
                MessageBox.Show("Заполните все поля");
            }
        }

        public LinkLabel LinkLabel1
        {
            get { return linkLabel1; }
        }


    }
}
