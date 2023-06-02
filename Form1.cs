using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp5
{

    public partial class Form1 : Form
    {
        public Form1()
        {    
            InitializeComponent();
        }

        public static List<Users> users = new List<Users>();
        public static List<Moderators> moderators = new List<Moderators>();
        public static List<Admin> admin = new List<Admin>();
        private void Form1_Load(object sender, EventArgs e)
        {
            AllUsersRead allUsersRead = new AllUsersRead();
            allUsersRead.Read(users, moderators, admin);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            LabelEmptyNik.Visible = false;
            LabelEmptyPassword.Visible = false;
            LabelNotSamePasswords.Visible = false;
            if (LabelRepeatPassword.Visible == false)
            {
                LabelRepeatPassword.Visible = true;
                TextBoxRepeatPassword.Visible = true;
                ButtonEntry.Text = "Назад";
            }
            else
            {
                if (TextBoxNik.Text == "")
                {
                    LabelEmptyNik.Text = "Введите никнейм";
                    LabelEmptyNik.Visible = true;
                }
                else if (TextBoxPassword.Text == "")
                {
                    LabelEmptyPassword.Text = "Введите пароль";
                    LabelEmptyPassword.Visible = true;
                }
                else if (TextBoxNik.Text.Length > 15)
                {
                    LabelEmptyNik.Text = "Никнейм не должен превышать 15 символов";
                    LabelEmptyNik.Visible = true;
                }
                else
                {
                    UsersCheck usersCheck = new UsersCheck();
                    ModeratorsCheck moderatorsCheck = new ModeratorsCheck();
                    AdminCheck adminCheck = new AdminCheck();
                    if ((usersCheck.Check(users, TextBoxNik.Text) == false) || (moderatorsCheck.Check(moderators, TextBoxNik.Text) == false) || (adminCheck.Check(admin, TextBoxNik.Text) == false))
                    {
                        LabelEmptyNik.Text = "Такой пользователь уже существует";
                        LabelEmptyNik.Visible = true;
                    }
                    else if (TextBoxPassword.Text != TextBoxRepeatPassword.Text)
                    {
                        LabelNotSamePasswords.Visible = true;
                    }
                    else
                    {
                        UsersAdd usersAdd = new UsersAdd();
                        usersAdd.Add(users, TextBoxNik.Text, TextBoxPassword.Text);
                        StreamWriter us = new StreamWriter("Users.txt", true);
                        us.WriteLine(TextBoxNik.Text);
                        us.WriteLine(TextBoxPassword.Text);
                        us.Close();
                        us = new StreamWriter("Active.txt", false);
                        us.WriteLine("User");
                        us.WriteLine(TextBoxNik.Text);
                        us.WriteLine(TextBoxPassword.Text);
                        us.Close();
                        Close();
                    }
                }
            }
        }

        private void Entry_Click(object sender, EventArgs e)
        {
            LabelEmptyNik.Visible = false;
            LabelEmptyPassword.Visible = false;
            if (ButtonEntry.Text == "Назад")
            {
                LabelRepeatPassword.Visible = false;
                TextBoxRepeatPassword.Visible = false;
                LabelRepeatPassword.Visible = false;
                ButtonEntry.Text = "Вход";
                LabelNotSamePasswords.Visible = false;
            }
            else
            {
                if (TextBoxNik.Text == "")
                {
                    LabelEmptyNik.Text = "Введите никнейм";
                    LabelEmptyNik.Visible = true;
                }
                else if (TextBoxPassword.Text == "")
                {
                    LabelEmptyPassword.Text = "Введите пароль";
                    LabelEmptyPassword.Visible = true;
                }
                else
                {
                    UsersCheck usersCheck = new UsersCheck();
                    ModeratorsCheck moderatorsCheck = new ModeratorsCheck();
                    AdminCheck adminCheck = new AdminCheck();
                    if ((usersCheck.Check(users, TextBoxNik.Text, TextBoxPassword.Text) == 1) && (moderatorsCheck.Check(moderators, TextBoxNik.Text, TextBoxPassword.Text) == 1) && (adminCheck.Check(admin, TextBoxNik.Text, TextBoxPassword.Text) == 1))
                    {
                        LabelEmptyNik.Text = "Такого пользователя не существует";
                        LabelEmptyNik.Visible = true;
                    }
                    else if ((usersCheck.Check(users, TextBoxNik.Text, TextBoxPassword.Text) == 2) || (moderatorsCheck.Check(moderators, TextBoxNik.Text, TextBoxPassword.Text) == 2) || (adminCheck.Check(admin, TextBoxNik.Text, TextBoxPassword.Text) == 2))
                    {
                        LabelEmptyPassword.Text = "Неверный пароль";
                        LabelEmptyPassword.Visible = true;
                    }
                    else
                    {
                        StreamWriter us = new StreamWriter("Active.txt", false);
                        if (usersCheck.Check(users, TextBoxNik.Text, TextBoxPassword.Text) == 0)
                            us.WriteLine("User");
                        else if (moderatorsCheck.Check(moderators, TextBoxNik.Text, TextBoxPassword.Text) == 0)
                            us.WriteLine("Moderator");
                        else us.WriteLine("Admin");
                        us.WriteLine(TextBoxNik.Text);
                        us.WriteLine(TextBoxPassword.Text);
                        us.Close();
                        Close();
                    }
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ButtonEntry.Dispose();
            ButtonRegistration.Dispose();
            TextBoxNik.Dispose();
            TextBoxPassword.Dispose();
            TextBoxRepeatPassword.Dispose();
            LabelEmptyNik.Dispose();
            LabelEmptyPassword.Dispose();
            LabelNotSamePasswords.Dispose();
            LabelPassword.Dispose();
            LabelRepeatPassword.Dispose();
            LabelNik.Dispose();
        }
    }
}
