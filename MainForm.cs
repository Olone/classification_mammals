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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            IeMethods.SetBrowserEmulation(11001);
            InitializeComponent();
        }
        public Users user = new Users();
        public Moderators moderator = new Moderators();
        public Admin admin = new Admin();
        public List<Users> users = new List<Users>();
        public List<Moderators> moderators = new List<Moderators>();
        public List<Admin> admins = new List<Admin>();
        public List<Order> orders = new List<Order>();
        public List<Family> families = new List<Family>();
        public List<Genus> genuses = new List<Genus>();
        public List<Specie> species = new List<Specie>();

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (!File.Exists("Active.txt"))
            {
                StreamWriter uu = new StreamWriter("Active.txt");
                uu.Close();
            }
            StreamReader us = new StreamReader("Active.txt");
            string s = us.ReadLine();
            if (s == null)
                Close();
            else if (s == "User")
            {
                user.Nik = us.ReadLine();
                user.Password = us.ReadLine();
                LabelNik.Text = user.Nik;
                ButtonAddElement.Visible = false;
                ButtonDelete.Visible = false;
                ButtonChange.Visible = false;
            }
            else if (s == "Moderator")
            {
                moderator.Nik = us.ReadLine();
                moderator.Password = us.ReadLine();
                LabelNik.Text = moderator.Nik;
            }
            else
            {
                admin.Nik = us.ReadLine();
                admin.Password = us.ReadLine();
                LabelNik.Text = admin.Nik;
                ButtonToUsers.Visible = true;
            }
            us.Close();
            AllRead allRead = new AllRead();
            allRead.Read(orders, families, genuses, species, TreeTaxonomy);
        }

        private void ButtonAddElement_Click(object sender, EventArgs e)
        {
            if (LabelInputName.Visible == true)
            {
                if (ButtonAddElement.Text == "Добавить пользователя")
                {
                    if (TextBoxInputName.Text == null)
                        MessageBox.Show("Введите никнейм нового пользователя!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        UsersCheck usersCheck = new UsersCheck();
                        ModeratorsCheck moderatorsCheck = new ModeratorsCheck();
                        AdminCheck adminCheck = new AdminCheck();
                        if (usersCheck.Check(users, TextBoxInputName.Text) == false || moderatorsCheck.Check(moderators, TextBoxInputName.Text) == false || adminCheck.Check(admins, TextBoxInputName.Text) == false)
                            MessageBox.Show("Пользователь с таким никнеймом уже существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                        {
                            UsersAdd usersAdd = new UsersAdd();
                            usersAdd.Add(users, TextBoxNik.Text, TextBoxInputName.Text);
                            StreamWriter us = new StreamWriter("Users.txt", true);
                            us.WriteLine(TextBoxNik.Text);
                            us.WriteLine(TextBoxInputName.Text);
                            us.Close();
                            TreeTaxonomy.Nodes.Add(TextBoxNik.Text);
                            LabelInputName.Visible = false;
                            LabelInputName.Text = "Введите название типа:";
                            LabelNewNik.Visible = false;
                            TextBoxInputName.Visible = false;
                            TextBoxInputName.Text = null;
                            TextBoxNik.Visible = false;
                            TextBoxNik.Text = null;
                        }
                    }
                }
                else
                {
                    if (TextBoxInputName.Text == null)
                        MessageBox.Show("Введите название нового типа!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    switch (TreeTaxonomy.SelectedNode.Level)
                    {
                        case 0:
                            FamilyCheck familycheck = new FamilyCheck();
                            if (familycheck.Check(families, TextBoxInputName.Text))
                            {
                                MessageBox.Show("Семейство с таким названием уже существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }
                            FamilyAdd familyadd = new FamilyAdd();
                            for (int i = 0; i < orders.Count; i++)
                            {
                                if (orders[i].Name == TreeTaxonomy.SelectedNode.Name)
                                {
                                    familycheck.order = orders[i];
                                    break;
                                }
                            }
                            Family family = new Family(orders.Find(order => order.Name == TreeTaxonomy.SelectedNode.Text), TextBoxInputName.Text);
                            familyadd.Add(families, family, TreeTaxonomy, TextBoxInputName.Text);
                            LabelInputName.Visible = false;
                            TextBoxInputName.Visible = false;
                            ButtonChange.Text = "Изменить тип";
                            ButtonDelete.Enabled = true;
                            ButtonInfo.Enabled = true;
                            TextBoxInputName.Text = null;
                            ButtonSort.Enabled = true;
                            break;
                        case 1:
                            GenusCheck genuscheck = new GenusCheck();
                            if (genuscheck.Check(genuses, TextBoxInputName.Text))
                            {
                                MessageBox.Show("Род с таким названием уже существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }
                            GenusAdd genusadd = new GenusAdd();
                            for (int i = 0; i < families.Count; i++)
                            {
                                if (families[i].Name == TreeTaxonomy.SelectedNode.Name)
                                {
                                    genuscheck.family = families[i];
                                    break;
                                }
                            }
                            Genus genus = new Genus(families.Find(famil => famil.Name == TreeTaxonomy.SelectedNode.Text), TextBoxInputName.Text);
                            genusadd.Add(genuses, genus, TreeTaxonomy, TextBoxInputName.Text);
                            LabelInputName.Visible = false;
                            TextBoxInputName.Visible = false;
                            ButtonChange.Text = "Изменить тип";
                            ButtonDelete.Enabled = true;
                            ButtonInfo.Enabled = true;
                            TextBoxInputName.Text = null;
                            ButtonSort.Enabled = true;
                            break;
                        case 2:
                            SpecieCheck speciecheck = new SpecieCheck();
                            if (speciecheck.Check(genuses, TextBoxInputName.Text))
                            {
                                MessageBox.Show("Вид с таким названием уже существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }
                            SpecieAdd specieadd = new SpecieAdd();
                            for (int i = 0; i < genuses.Count; i++)
                            {
                                if (genuses[i].Name == TreeTaxonomy.SelectedNode.Name)
                                {
                                    speciecheck.genus = genuses[i];
                                    break;
                                }
                            }
                            Specie specie = new Specie(genuses.Find(genu => genu.Name == TreeTaxonomy.SelectedNode.Text), TextBoxInputName.Text);
                            specieadd.Add(species, specie, TreeTaxonomy, TextBoxInputName.Text);
                            LabelInputName.Visible = false;
                            TextBoxInputName.Visible = false;
                            ButtonChange.Text = "Изменить тип";
                            ButtonDelete.Enabled = true;
                            ButtonInfo.Enabled = true;
                            TextBoxInputName.Text = null;
                            ButtonSort.Enabled = true;
                            break;
                        default:
                            break;
                    }
                }
            }
            else
            {
                if (ButtonAddElement.Text == "Пользователи")
                {
                    UsersShow usersShow = new UsersShow();
                    usersShow.Show(TreeTaxonomy);
                    ButtonAddElement.Text = "Добавить пользователя";
                    ButtonChange.Text = "Повысить до модератора";
                    ButtonDelete.Text = "Удалить пользователя";
                    ButtonToUsers.Text = "Назад";
                }
                else if (ButtonAddElement.Text == "Добавить")
                {
                    LabelInputName.Visible = true;
                    LabelInputName.Text = "Введите пароль нового пользователя:";
                    TextBoxInputName.Visible = true;
                    LabelNewNik.Visible = true;
                    TextBoxNik.Visible = true;
                }
                else
                {
                    LabelInputName.Visible = true;
                    TextBoxInputName.Visible = true;
                    ButtonChange.Text = "Назад";
                    ButtonDelete.Enabled = false;
                    ButtonInfo.Enabled = false;
                    ButtonSort.Enabled = false;
                    switch (TreeTaxonomy.SelectedNode.Level)
                    {
                        case 0:
                            LabelInputName.Text = "Введите название нового семейства:";
                            break;
                        case 1:
                            LabelInputName.Text = "Введите название нового рода:";
                            break;
                        case 2:
                            LabelInputName.Text = "Введите название нового вида:";
                            break;
                        case 3:
                            MessageBox.Show("Невозможно создать тип ниже вида!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            LabelInputName.Visible = false;
                            TextBoxInputName.Visible = false;
                            ButtonChange.Text = "Изменить тип";
                            ButtonDelete.Enabled = true;
                            ButtonInfo.Enabled = true;
                            ButtonSort.Enabled = true;
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (ButtonDelete.Text == "Назад")
            {
                LabelInputName.Visible = false;
                TextBoxInputName.Visible = false;
                ButtonAddElement.Enabled = true;
                ButtonInfo.Enabled = true;
                ButtonDelete.Text = "Удалить тип";
                ButtonSort.Enabled = true;
            }
            else if (ButtonDelete.Text == "Администраторы")
            {
                AdminShow adminShow = new AdminShow();
                adminShow.Show(TreeTaxonomy);
                ButtonAddElement.Visible = false;
                ButtonChange.Text = "Понизить до модератора";
                ButtonDelete.Text = "Удалить администратора";
                ButtonToUsers.Text = "Назад";
            }
            else if (ButtonDelete.Text == "Удалить пользователя")
            {
                UsersDelete usersDelete = new UsersDelete();
                usersDelete.Delete(users, TreeTaxonomy);
            }
            else if (ButtonDelete.Text == "Удалить модератора")
            {
                ModeratorsDelete moderatorsDelete = new ModeratorsDelete();
                moderatorsDelete.Delete(moderators, TreeTaxonomy);
            }
            else if (ButtonDelete.Text == "Удалить администратора")
            {
                AdminDelete adminDelete = new AdminDelete();
                adminDelete.Delete(admins, TreeTaxonomy);
            }
            else switch (TreeTaxonomy.SelectedNode.Level)
            {
                    case 1:
                        FamilyDelete familyDelete = new FamilyDelete();
                        familyDelete.Delete(families, TreeTaxonomy);
                        break;
                    case 2:
                        GenusDelete genusDelete = new GenusDelete();
                        genusDelete.Delete(genuses, TreeTaxonomy);
                        break;
                    case 3:
                        SpecieDelete specieDelete = new SpecieDelete();
                        specieDelete.Delete(species, TreeTaxonomy);
                        break;
                    default:
                        break;
            }
            //public OrderDelete orderdelete = new OrderDelete();
            //orderdelete.Delete(orders, TreeTaxonomy);
    }

        private void ButtonInfo_Click(object sender, EventArgs e)
        {
            try
            {
                WebBrowserInfo.Navigate("https://ru.wikipedia.org/wiki/" + TreeTaxonomy.SelectedNode.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Выберите тип!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
     
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            TreeTaxonomy.Dispose();
            ButtonAddElement.Dispose();
            ButtonDelete.Dispose();
            ButtonInfo.Dispose();
            LabelInputName.Dispose();
            LabelNik.Dispose();
            TextBoxInputName.Dispose();
            WebBrowserInfo.Dispose();
            ButtonChange.Dispose();
        }

        private void ButtonSort_Click(object sender, EventArgs e)
        {
            if (ButtonSort.Text == "Сортировать по алфавиту")
            {
                AllSort allSort = new AllSort();
                allSort.Sort(TreeTaxonomy);
                ButtonSort.Text = "Сортировать по умолчанию";
            }
            else
            {
                TreeTaxonomy.Nodes.Clear();  
                AllRead allRead = new AllRead();
                allRead.Read(orders, families, genuses, species, TreeTaxonomy);
                ButtonSort.Text = "Сортировать по алфавиту";
            }     
        }

        private void ButtonChange_Click(object sender, EventArgs e)
        {
            if (ButtonChange.Text == "Назад")
            {
                LabelInputName.Visible = false;
                TextBoxInputName.Visible = false;
                ButtonChange.Text = "Изменить тип";
                ButtonDelete.Enabled = true;
                ButtonInfo.Enabled = true;
                TextBoxInputName.Text = null;
                ButtonSort.Enabled = true;
            }
            else if (ButtonChange.Text == "Модераторы")
            {
                ModeratorsShow moderatorsShow = new ModeratorsShow();
                moderatorsShow.Show(TreeTaxonomy);
                ButtonAddElement.Text = "Понизить до пользователя";
                ButtonChange.Text = "Повысить до администратора";
                ButtonDelete.Text = "Удалить модератора";
                ButtonToUsers.Text = "Назад";
            }
            else if (ButtonChange.Text == "Повысить до модератора")
            {                          
                string[] s = File.ReadAllLines("Users.txt");
                StreamWriter us = new StreamWriter("Users.txt", false);
                string nik = null, password = null;
                foreach (string s1 in s)
                {
                    if (s1 == TreeTaxonomy.SelectedNode.Text)
                        nik = s1;
                    else if (nik != null && password == null)
                        password = s1;
                    else us.WriteLine(s1);
                }
                us.Close();
                us = new StreamWriter("Moderators.txt", true);
                us.WriteLine(nik);
                us.WriteLine(password);
                us.Close();
                AllUsersRead allUsersRead = new AllUsersRead();
                allUsersRead.Read(users, moderators, admins);
                UserModerator userModerator = new UserModerator();
                userModerator.UserToModerator(users, moderators, TreeTaxonomy);
            }
            else if (ButtonChange.Text == "Повысить до администратора")
            {
                string[] s = File.ReadAllLines("Moderators.txt");
                StreamWriter us = new StreamWriter("Moderators.txt", false);
                string nik = null, password = null;
                foreach (string s1 in s)
                {
                    if (s1 == TreeTaxonomy.SelectedNode.Text)
                        nik = s1;
                    else if (nik != null && password == null)
                        password = s1;
                    else us.WriteLine(s1);
                }
                us.Close();
                us = new StreamWriter("Admin.txt", true);
                us.WriteLine(nik);
                us.WriteLine(password);
                us.Close();
                AllUsersRead allUsersRead = new AllUsersRead();
                allUsersRead.Read(users, moderators, admins);
                UserModerator userModerator = new UserModerator();
                userModerator.UserToModerator(users, moderators, TreeTaxonomy);
            }
            else
            {
                if (LabelInputName.Visible)
                {
                    if (TextBoxInputName.Text == null)
                        MessageBox.Show("Введите новое название типа!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        switch (TreeTaxonomy.SelectedNode.Level)
                        {
                            case 0:
                                OrderCheck ordercheck = new OrderCheck();
                                if (ordercheck.Check(orders, TextBoxInputName.Text))
                                {
                                    MessageBox.Show("Отряд с таким названием уже существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    break;
                                }
                                OrderChange orderchange = new OrderChange();
                                orderchange.Change(orders, TreeTaxonomy, TextBoxInputName.Text);
                                LabelInputName.Visible = false;
                                break;
                            case 1:
                                FamilyCheck familycheck = new FamilyCheck();
                                if (familycheck.Check(families, TextBoxInputName.Text))
                                {
                                    MessageBox.Show("Семейство с таким названием уже существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    break;
                                }
                                FamilyChange familychange = new FamilyChange();
                                familychange.Change(families, TreeTaxonomy, TextBoxInputName.Text);
                                LabelInputName.Visible = false;
                                break;
                            case 2:
                                GenusCheck genuscheck = new GenusCheck();
                                if (genuscheck.Check(genuses, TextBoxInputName.Text))
                                {
                                    MessageBox.Show("Род с таким названием уже существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    break;
                                }
                                GenusChange genuschange = new GenusChange();
                                genuschange.Change(genuses, TreeTaxonomy, TextBoxInputName.Text);
                                LabelInputName.Visible = false;
                                break;
                            case 3:
                                SpecieCheck speciecheck = new SpecieCheck();
                                if (speciecheck.Check(species, TextBoxInputName.Text))
                                {
                                    MessageBox.Show("Вид с таким названием уже существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    break;
                                }
                                SpecieChange speciechange = new SpecieChange();
                                speciechange.Change(species, TreeTaxonomy, TextBoxInputName.Text);
                                LabelInputName.Visible = false;  
                                break;
                            default:
                                break;
                        }
                        if (!LabelInputName.Visible)
                        {
                            ButtonAddElement.Enabled = true;
                            ButtonInfo.Enabled = true;
                            ButtonSort.Enabled = true;
                            TextBoxInputName.Visible = false;
                        }
                    }
                }
                else
                {
                    LabelInputName.Visible = true;
                    LabelInputName.Text = "Введите новое название:";
                    ButtonAddElement.Enabled = false;
                    ButtonInfo.Enabled = false;
                    ButtonSort.Enabled = false;
                    ButtonDelete.Text = "Назад";
                    TextBoxInputName.Visible = true;
                }
            }
        }

        private void ButtonToUsers_Click(object sender, EventArgs e)
        {
            if (ButtonToUsers.Text == "Перейти к списку пользователей" || ButtonToUsers.Text == "Назад")
            {
                ButtonAddElement.Text = "Пользователи";
                ButtonChange.Text = "Модераторы";
                ButtonDelete.Text = "Администраторы";
                ButtonToUsers.Text = "Перейти к списку типов";
                ButtonInfo.Visible = false;
                ButtonSort.Visible = false;
                WebBrowserInfo.Visible = false;
                TreeTaxonomy.Nodes.Clear();
            }
            else
            {
                TreeTaxonomy.Nodes.Clear();
                AllRead allRead = new AllRead();
                allRead.Read(orders, families, genuses, species, TreeTaxonomy);
                ButtonAddElement.Text = "Добавить тип";
                ButtonAddElement.Visible = true;
                ButtonChange.Text = "Изменить тип";
                ButtonDelete.Text = "Удалить тип";
                ButtonToUsers.Text = "Перейти к списку пользователей";
                ButtonInfo.Visible = true;
                ButtonSort.Visible = true;
                WebBrowserInfo.Visible = true;
            }
        }
    }
}