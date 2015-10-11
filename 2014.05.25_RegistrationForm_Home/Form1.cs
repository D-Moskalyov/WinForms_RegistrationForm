using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Account;
using System.IO;

namespace _2014._05._25_RegistrationForm_Home
{

    public partial class Form1 : Form
    {
        StreamReader sr;
        StreamWriter sw;
        StreamReader srOnLine;
        //FileStream fS;

        public Form1()
        {
            InitializeComponent();
        }

        void LinkLabalLoginClick1(object sender, EventArgs e)
        {
            this.Controls.Remove(((LinkLabel)sender).Parent);

            Restore restore1 = new Restore();
            this.Controls.Add(restore1);
            restore1.Location = new System.Drawing.Point(63, 12);
            restore1.Name = "restore1";
            restore1.Size = new System.Drawing.Size(252, 209);
            restore1.TabIndex = 0;

            restore1.LinkLabel1.Click += LinkLabalRestoreClick1;
            restore1.OkEvent += new Account.Restore.OkHandler(Ok);
        }

        void LinkLabalLoginClick2(object sender, EventArgs e)
        {
            this.Controls.Remove(((LinkLabel)sender).Parent);

            Registration registration1 = new Registration();
            this.Controls.Add(registration1);
            registration1.Location = new System.Drawing.Point(2, 4);
            registration1.Name = "registration1";
            registration1.Size = new System.Drawing.Size(382, 358);
            registration1.TabIndex = 0;

            registration1.LinkLabel1.Click += LinkLabalRegistrationClick1;
            //registration1.TextBox1.Enter += TextBox1RegistrationEnter;
            //registration1.TextBox1.Leave += TextBox1RegistrationLeave;
            registration1.TextBox1.KeyUp += TextBox1RegistrationKeyUp;
            registration1.OkEvent += new Account.Registration.OkHandler(Ok);
        }

        void LinkLabalRegistrationClick1(object sender, EventArgs e)
        {
            this.Controls.Remove(((LinkLabel)sender).Parent);

            Login login1 = new Login();
            this.Controls.Add(login1);
            login1.Location = new System.Drawing.Point(79, 12);
            login1.Name = "login1";
            login1.Size = new System.Drawing.Size(217, 220);
            login1.TabIndex = 0;
            login1.LinkLabel1.Click += LinkLabalLoginClick1;

            login1.LinkLabel2.Click += LinkLabalLoginClick2;
            login1.OkEvent += new Account.Login.OkHandler(Ok);
        }

        void LinkLabalRestoreClick1(object sender, EventArgs e)
        {
            this.Controls.Remove(((LinkLabel)sender).Parent);

            Login login1 = new Login();
            this.Controls.Add(login1);
            login1.Location = new System.Drawing.Point(79, 12);
            login1.Name = "login1";
            login1.Size = new System.Drawing.Size(217, 220);
            login1.TabIndex = 0;
            login1.LinkLabel1.Click += LinkLabalLoginClick1;

            login1.LinkLabel2.Click += LinkLabalLoginClick2;
            login1.OkEvent += new Account.Login.OkHandler(Ok);
        }

        void Ok(object sender, MyEventArgs e)
        {
            if ((UserControl)sender is Login)
            {
                if (File.Exists("users.txt"))
                {
                    sr = new StreamReader("users.txt");
                    string name = e.name;
                    bool exist = false;

                    while (sr.Peek() > -1)
                    {
                        sr.ReadLine();
                        if (name == sr.ReadLine())
                        {
                            exist = true;
                            if (e.password == sr.ReadLine())
                            {
                                MessageBox.Show("Добро пожаловать");
                            }
                            else
                            {
                                MessageBox.Show("Не верный пароль");
                            }
                            break;
                        }
                        sr.ReadLine();
                        sr.ReadLine();
                        sr.ReadLine();
                    }
                    sr.Close();
                    if (!exist)
                    {
                        MessageBox.Show("Такого пользователя не существует");
                    }
                }
                else
                {
                    MessageBox.Show("Такого пользователя не существует");
                }

                //MessageBox.Show(string.Format("OkLog {0}", e.name));
            }
            if ((UserControl)sender is Registration)
            {
                if (File.Exists("users.txt"))
                {
                    sr = new StreamReader("users.txt");
                    string name = e.name;
                    bool exist = false;

                    while (sr.Peek() > -1)
                    {
                        sr.ReadLine();
                        if (name == sr.ReadLine())
                        {
                            exist = true;
                            MessageBox.Show("Пользователь уже существует");
                            break;
                        }
                        sr.ReadLine();
                        sr.ReadLine();
                        sr.ReadLine();
                    }
                    sr.Close();
                    if (!exist)
                    {
                        sw = new StreamWriter("users.txt", true);
                        sw.WriteLine();
                        sw.WriteLine(e.name);
                        sw.WriteLine(e.password);
                        sw.WriteLine(e.quastion);
                        sw.WriteLine(e.answer);
                        sw.Close();
                        MessageBox.Show("Вы зарегистрированы");
                    }
                }
                else
                {
                    sw = new StreamWriter("users.txt", true);
                    sw.WriteLine();
                    sw.WriteLine(e.name);
                    sw.WriteLine(e.password);
                    sw.WriteLine(e.quastion);
                    sw.WriteLine(e.answer);
                    sw.Close();
                    MessageBox.Show("Вы зарегистрированы");
                }

                //MessageBox.Show(string.Format("OkReg {0}", e.name));
            }
            if ((UserControl)sender is Restore)
            {
                if (File.Exists("users.txt"))
                {
                    sr = new StreamReader("users.txt");
                    string name = e.name;
                    bool exist = false;

                    while (sr.Peek() > -1)
                    {
                        sr.ReadLine();
                        if (name == sr.ReadLine())
                        {
                            exist = true;
                            string pass = sr.ReadLine();
                            if (e.quastion == sr.ReadLine() && e.answer == sr.ReadLine())
                            {
                                MessageBox.Show(string.Format("Ваш пароль: {0}", pass));
                            }
                            else
                            {
                                MessageBox.Show("Не верный вопрос || не верный ответ на него ");
                            }
                            break;
                        }
                        sr.ReadLine();
                        sr.ReadLine();
                        sr.ReadLine();
                    }
                    sr.Close();
                    if (!exist)
                    {
                        MessageBox.Show("Такого пользователя не существует");
                    }
                }
                else
                {
                    MessageBox.Show("Такого пользователя не существует");
                }

                //MessageBox.Show(string.Format("OkRes {0}", e.name));
            }
        }

        void TextBox1RegistrationKeyUp(object sender, EventArgs e)
        {
            bool exist = false;
            Registration regTmp = (Registration)((TextBox)sender).Parent;
            //TextBox tBoxTmp = ((TextBox)sender).Parent;
            srOnLine = new StreamReader("users.txt");
            if (regTmp.TextBox1.Text == "")
            {
                regTmp.Label8.Text = "";
            }
            else
            {
                //Указатель в начало
                while (srOnLine.Peek() > -1)
                {
                    srOnLine.ReadLine();
                    if (regTmp.TextBox1.Text == srOnLine.ReadLine())
                    {
                        exist = true;
                        regTmp.Label8.ForeColor = Color.Red;
                        regTmp.Label8.Text = "Имя занято";
                        break;
                    }
                    srOnLine.ReadLine();
                    srOnLine.ReadLine();
                    srOnLine.ReadLine();
                }
                if (!exist)
                {
                    regTmp.Label8.ForeColor = Color.Green;
                    regTmp.Label8.Text = "Имя свободно";
                }
            }
            srOnLine.Close();
        }

        //void TextBox1RegistrationEnter(object sender, EventArgs e)
        //{
        //    srOnLine = new StreamReader("users.txt");
        //}

        //void TextBox1RegistrationLeave(object sender, EventArgs e)
        //{
        //    srOnLine.Close();
        //}

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {

        }
    }
}