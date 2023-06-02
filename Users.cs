using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp5
{
    public class Users : IUsers<Users>
    {
        public string Nik { get; set; }
        public string Password { get; set; }

        public Users() { }

        public Users(string n, string p)
        {
            Nik = n;
            Password = p;
        }

        virtual public bool Check(List<Users> users, string nik) { return false; }
        virtual public int Check(List<Users> users, string nik, string password) { return 0; }
        virtual public void Add(List<Users> users, string nik, string password) { }
        virtual public void Show(TreeView TreeUsers) { }
    }

    public class UsersCheck : Users
    {
        override public bool Check(List<Users> users, string nik)
        {
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].Nik == nik)
                    return false;
            }
            return true;
        }

        override public int Check(List<Users> users, string nik, string password)
        {
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].Nik == nik)
                    if (users[i].Password == password)
                        return 0;
                    else return 2;
            }
            return 1;
        }
    }

    public class UsersAdd : Users
    {
        override public void Add(List<Users> users, string nik, string password)
        {
            Users user = new Users(nik, password);
            users.Add(user);     
        }
    }

    public class UsersShow : Users
    {
        override public void Show(TreeView TreeUsers)
        {
            TreeUsers.Nodes.Clear();
            StreamReader us = new StreamReader("Users.txt");
            string nik = us.ReadLine();
            while (nik != null)
            {
                TreeUsers.Nodes.Add(nik);
                us.ReadLine();
                nik = us.ReadLine();
            }
            us.Close();
        }
    }

    public class UsersDelete : Users
    {
        public void Delete(List<Users> users, TreeView TreeUsers)
        {
            users.Remove(users.Find(user => user.Nik == TreeUsers.SelectedNode.Text));
            File.WriteAllLines("Users.txt",
                File.ReadAllLines("Users.txt", Encoding.Default).Where(s => !s.Contains(TreeUsers.SelectedNode.Text)),
                Encoding.Default);
            TreeUsers.SelectedNode.Remove();
        }
    }
    /// <summary>
    /// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// </summary>

    public class Moderators : Users, IUsers<Moderators>
    {
        public Moderators() { }

        public Moderators(string n, string p)
        {
            Nik = n;
            Password = p;
        }

        virtual public bool Check(List<Moderators> moderators, string nik) { return false; }
        virtual public int Check(List<Moderators> moderators, string nik, string password) { return 0; }
        virtual public void Add(List<Moderators> moderators, string nik, string password) { }
        //virtual public void Show(TreeView TreeModers) { }
    }

    public class ModeratorsCheck : Moderators
    {
        override public bool Check(List<Moderators> moderators, string nik)
        {
            for (int i = 0; i < moderators.Count; i++)
            {
                if (moderators[i].Nik == nik)
                    return false;
            }
            return true;
        }

        override public int Check(List<Moderators> moderators, string nik, string password)
        {
            for (int i = 0; i < moderators.Count; i++)
            {
                if (moderators[i].Nik == nik)
                    if (moderators[i].Password == password)
                        return 0;
                    else return 2;
            }
            return 1;
        }
    }

    public class ModeratorsAdd : Moderators
    {
        override public void Add(List<Moderators> moderators, string nik, string password)
        {
            Moderators moderator = new Moderators(nik, password);
            moderators.Add(moderator);
        }
    }

    public class ModeratorsShow : Moderators
    {
        override public void Show(TreeView TreeModers)
        {
            TreeModers.Nodes.Clear();
            StreamReader us = new StreamReader("Moderators.txt");
            string nik = us.ReadLine();
            while (nik != null)
            {
                TreeModers.Nodes.Add(nik);
                us.ReadLine();
                nik = us.ReadLine();
            }
            us.Close();
        }
    }

    public class ModeratorsDelete : Moderators
    {
        public void Delete(List<Moderators> moderators, TreeView TreeModerators)
        {
            moderators.Remove(moderators.Find(user => user.Nik == TreeModerators.SelectedNode.Text));
            File.WriteAllLines("Moderators.txt",
                File.ReadAllLines("Moderators.txt", Encoding.Default).Where(s => !s.Contains(TreeModerators.SelectedNode.Text)),
                Encoding.Default);
            TreeModerators.SelectedNode.Remove();
        }
    }
    /// <summary>
    /// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// </summary>
    public class Admin : Moderators, IUsers<Admin>
    {
        public Admin() { }

        public Admin(string n, string p)
        {
            Nik = n;
            Password = p;
        }
        virtual public bool Check(List<Admin> admin, string nik) { return false; }
        virtual public int Check(List<Admin> admin, string nik, string password) { return 0; }
        virtual public void Add(List<Admin> admin, string nik, string password) { }
        //virtual public void Show(TreeView TreeUsers) { }
    }

    public class AdminCheck : Admin
    {
        override public bool Check(List<Admin> admin, string nik)
        {
            for (int i = 0; i < admin.Count; i++)
            {
                if (admin[i].Nik == nik)
                    return false;
            }
            return true;
        }

        override public int Check(List<Admin> admin, string nik, string password)
        {
            for (int i = 0; i < admin.Count; i++)
            {
                if (admin[i].Nik == nik)
                    if (admin[i].Password == password)
                        return 0;
                    else return 2;
            }
            return 1;
        }
    }

    public class AdminAdd : Admin
    {
        override public void Add(List<Admin> admin, string nik, string password)
        {
            Admin admins = new Admin(nik, password);
            admin.Add(admins);
        }
    }

    public class AdminShow : Admin
    {
        override public void Show(TreeView TreeAdmin)
        {
            TreeAdmin.Nodes.Clear();
            StreamReader us = new StreamReader("Admin.txt");
            string nik = us.ReadLine();
            while (nik != null)
            {
                TreeAdmin.Nodes.Add(nik);
                us.ReadLine();
                nik = us.ReadLine();
            }
            us.Close();
        }
    }

    public class AdminDelete : Admin
    {
        public void Delete(List<Admin> admins, TreeView TreeAdmins)
        {
            admins.Remove(admins.Find(user => user.Nik == TreeAdmins.SelectedNode.Text));
            File.WriteAllLines("Admin.txt",
                File.ReadAllLines("Admin.txt", Encoding.Default).Where(s => !s.Contains(TreeAdmins.SelectedNode.Text)),
                Encoding.Default);
            TreeAdmins.SelectedNode.Remove();
        }
    }

    public class AllUsersRead
    {
        public void Read(List<Users> users, List<Moderators> moderators, List<Admin> admins)
        {
            users.Clear();
            moderators.Clear();
            admins.Clear();
            if (File.Exists("Users.txt") == false)
            {
                StreamWriter uu = new StreamWriter("Users.txt");
                uu.Close();
            }
            var us = new StreamReader("Users.txt");
            string nik = us.ReadLine();
            string password = us.ReadLine();
            while (nik != null)
            {
                UsersAdd usersAdd = new UsersAdd();
                usersAdd.Add(users, nik, password);
                nik = us.ReadLine();
                password = us.ReadLine();
            }
            us.Close();
            if (File.Exists("Moderators.txt") == false)
            {
                StreamWriter uu = new StreamWriter("Moderators.txt");
                uu.Close();
            }
            us = new StreamReader("Moderators.txt");
            nik = us.ReadLine();
            password = us.ReadLine();
            while (nik != null)
            {
                ModeratorsAdd moderatorsAdd = new ModeratorsAdd();
                moderatorsAdd.Add(moderators, nik, password);
                nik = us.ReadLine();
                password = us.ReadLine();
            }
            us.Close();
            if (File.Exists("Admin.txt") == false)
            {
                StreamWriter uu = new StreamWriter("Admin.txt");
                uu.Close();
            }
            us = new StreamReader("Admin.txt");
            nik = us.ReadLine();
            password = us.ReadLine();
            while (nik != null)
            {
                AdminAdd adminAdd = new AdminAdd();
                adminAdd.Add(admins, nik, password);
                nik = us.ReadLine();
                password = us.ReadLine();
            }
            us.Close();
        }
    }

    public class UserModerator
    {
        public void UserToModerator(List<Users> users, List<Moderators> moderators, TreeView TreeUsers)
        {
            /*Moderators moderator = new Moderators(users.Find(user => user.Nik == TreeUsers.SelectedNode.Text).Nik, users.Find(user => user.Nik == TreeUsers.SelectedNode.Text).Password);
            moderators.Add(moderator);
            users.Remove(users.Find(user => user.Nik == TreeUsers.SelectedNode.Text));*/
            /*File.WriteAllLines("Users.txt",
                File.ReadAllLines("Users.txt", Encoding.Default).Where(s => !s.Contains(TreeUsers.SelectedNode.Text)),
                Encoding.Default);*/
            TreeUsers.SelectedNode.Remove();
        }
    }
}
