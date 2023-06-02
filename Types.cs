using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp5
{
    public class Order : IType<Order>
    {
        public string Name { get; set; }

        public Order() { }
        public Order(string n)
        {
            Name = n;
        }

        virtual public void Add(List<Order> orders, Order orderr, TreeView TreeTaxonomy, string name) { }
        virtual public void Read(List<Order> orders, Order orderr, TreeView TreeTaxonomy) { }
        virtual public bool Check(List<Order> orders, string name) { return false; }
        virtual public void Delete(List<Order> orders, TreeView TreeTaxonomy) { }
        virtual public void Change(List<Order> orders, TreeView TreeTaxonomy, string name) { }
        //virtual public void Show(List<Order> orders) { }
    }

    public class OrderAdd : Order
    {
        override public void Add(List<Order> orders, Order orderr, TreeView TreeTaxonomy, string name)
        {
            Order order = new Order(name);
            orders.Add(order);
            StreamWriter us = new StreamWriter("Orders.txt", true);
            us.WriteLine(order.Name);
            us.Close();
            TreeTaxonomy.Nodes.Add(new TreeNode(name));
        }
    }

    public class OrderRead : Order
    {
        override public void Read(List<Order> orders, Order orderr, TreeView TreeTaxonomy)
        {
            StreamReader us = new StreamReader("Orders.txt");
            string name = us.ReadLine();
            while (name != null)
            {
                Order order = new Order(name);
                orders.Add(order);
                TreeNode orderTree = new TreeNode(order.Name);
                TreeTaxonomy.Nodes.Add(orderTree);
                name = us.ReadLine();
            }
            us.Close();
        }
    }

    public class OrderCheck : Order
    {
        override public bool Check(List<Order> orders, string name)
        {
            for (int i = 0; i < orders.Count; i++)
            {
                if (orders[i].Name == name)
                    return true;
            }
            return false;
        }
    }

    public class OrderDelete : Order
    {
        override public void Delete(List<Order> orders, TreeView TreeTaxonomy)
        {
            orders.Remove(orders.Find(order => order.Name == TreeTaxonomy.SelectedNode.Text));
            File.WriteAllLines("Orders.txt",
                File.ReadAllLines("Orders.txt", Encoding.Default).Where(s => !s.Contains(TreeTaxonomy.SelectedNode.Text)),
                Encoding.Default);
            TreeTaxonomy.SelectedNode.Remove();
        }
    }

    public class OrderChange : Order
    {
        public override void Change(List<Order> orders, TreeView TreeTaxonomy, string name)
        {
            string[] ord = File.ReadAllLines("Orders.txt");
            StreamWriter us = new StreamWriter("Orders.txt");
            foreach (string s in ord)
            {
                if (s == TreeTaxonomy.SelectedNode.Text)
                    us.WriteLine(name);
                else us.WriteLine(s);
            }
            us.Close();
            if (File.Exists("Families\\" + TreeTaxonomy.SelectedNode.Text + ".txt"))
            {
                File.Copy("Families\\" + TreeTaxonomy.SelectedNode.Text + ".txt", "Families\\" + name + ".txt");
                File.Delete("Families\\" + TreeTaxonomy.SelectedNode.Text + ".txt");
            }
            orders.Find(order => order.Name == TreeTaxonomy.SelectedNode.Text).Name = name;
            TreeTaxonomy.SelectedNode.Text = name;
        }
    }
    /// <summary>
    /// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// </summary>
    public class Family : Order, IType<Family>
    {
        public Order order;

        public Family() { }
        public Family(Order o)
        {
            order = o;
        }
        public Family(Order o, string n)
        {
            order = o;
            Name = n;
        }

        virtual public void Add(List<Family> families, Family family, TreeView TreeTaxonomy, string name) { }
        virtual public void Read(List<Family> families, Family falmily, TreeView TreeTaxonomy) { }
        virtual public bool Check(List<Family> families, string name) { return false; }
        virtual public void Delete(List<Family> families, TreeView TreeTaxonomy) { }
        virtual public void Change(List<Family> families, TreeView TreeTaxonomy, string name) { }
    }

    public class FamilyAdd : Family
    {
        override public void Add(List<Family> families, Family family, TreeView TreeTaxonomy, string name)
        {
            families.Add(family);
            StreamWriter us = new StreamWriter("Families\\" + TreeTaxonomy.SelectedNode.Text + ".txt", true);
            us.WriteLine(family.Name);
            us.Close();
            TreeTaxonomy.SelectedNode.Nodes.Add(name);
        }
    }

    public class FamilyCheck : Family
    {
        public override bool Check(List<Family> families, string name)
        {
            for (int i = 0; i < families.Count; i++)
            {
                if (families[i].Name == name)
                    return true;
            }
            return false;
        }
    }

    public class FamilyRead : Family
    {
        public override void Read(List<Family> families, Family family, TreeView TreeTaxonomy)
        {
            families.Add(family);
            for (int i = 0; i < TreeTaxonomy.Nodes.Count; i++)
            {
                if (TreeTaxonomy.Nodes[i].Text == family.order.Name)
                {
                    TreeTaxonomy.Nodes[i].Nodes.Add(family.Name);
                    break;
                }
            }
        }
    }

    public class FamilyDelete : Family
    {
        public override void Delete(List<Family> families, TreeView TreeTaxonomy)
        {
            families.Remove(families.Find(family => family.Name == TreeTaxonomy.SelectedNode.Text));
            File.WriteAllLines("Families\\" + TreeTaxonomy.SelectedNode.Parent.Text + ".txt",
                File.ReadAllLines("Families\\" + TreeTaxonomy.SelectedNode.Parent.Text + ".txt", Encoding.Default).Where(s => !s.Contains(TreeTaxonomy.SelectedNode.Text)),
                Encoding.Default);
            string[] path = Directory.GetFiles("Genuses\\");
            foreach (string s in path)
            {
                if (@"Genuses\" + TreeTaxonomy.SelectedNode.Text + ".txt" == s)
                {
                    string[] ge = Directory.GetFiles("Species\\");
                    StreamReader us = new StreamReader(s);
                    string a = us.ReadLine();
                    bool ends;
                    while (a != null)
                    {
                        ends = false;
                        foreach (string i in ge)
                        {
                            if (@"Species\" + a + ".txt" == i)
                            {
                                File.Delete(i);
                                ends = true;
                                break;
                            }
                            if (ends == true) break;
                        }
                        a = us.ReadLine();
                    }
                    us.Close();
                    File.Delete(s);
                    break;
                }
            }
            TreeTaxonomy.SelectedNode.Remove();
        }
    }

    public class FamilyChange : Family
    {
        public override void Change(List<Family> families, TreeView TreeTaxonomy, string name)
        {
            string[] fam = File.ReadAllLines("Families\\" + TreeTaxonomy.SelectedNode.Parent.Text + ".txt");
            StreamWriter us = new StreamWriter("Families\\" + TreeTaxonomy.SelectedNode.Parent.Text + ".txt");
            foreach (string s in fam)
            {
                if (s == TreeTaxonomy.SelectedNode.Text)
                    us.WriteLine(name);
                else us.WriteLine(s);
            }
            us.Close();
            if (File.Exists("Genuses\\" + TreeTaxonomy.SelectedNode.Text + ".txt"))
            {
                File.Copy("Genuses\\" + TreeTaxonomy.SelectedNode.Text + ".txt", "Genuses\\" + name + ".txt");
                File.Delete("Genuses\\" + TreeTaxonomy.SelectedNode.Text + ".txt");
            }
            families.Find(family => family.Name == TreeTaxonomy.SelectedNode.Text).Name = name;
            TreeTaxonomy.SelectedNode.Text = name;
        }
    }
    /// <summary>
    /// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// </summary>
    public class Genus : Family, IType<Genus>
    {
        public Family family;

        public Genus() { }
        public Genus(Family f)
        {
            family = f;
            order = f.order;
        }
        public Genus(Family f, string i)
        {
            family = f;
            order = f.order;
            Name = i;
        }

        virtual public void Add(List<Genus> genuses, Genus genus, TreeView TreeTaxonomy, string name) { }
        virtual public void Read(List<Genus> genuses, Genus genus, TreeView TreeTaxonomy) { }
        virtual public bool Check(List<Genus> genuses, string name) { return false; }
        virtual public void Delete(List<Genus> genuses, TreeView TreeTaxonomy) { }
        virtual public void Change(List<Genus> genuses, TreeView TreeTaxonomy, string name) { }
    }

    public class GenusAdd : Genus
    {
        override public void Add(List<Genus> genuses, Genus genus, TreeView TreeTaxonomy, string name)
        {
            genuses.Add(genus);
            StreamWriter us = new StreamWriter("Genuses\\" + TreeTaxonomy.SelectedNode.Text + ".txt", true);
            us.WriteLine(genus.Name);
            us.Close();
            TreeTaxonomy.SelectedNode.Nodes.Add(name);
        }
    }

    public class GenusCheck : Genus
    {
        public override bool Check(List<Genus> genuses, string name)
        {
            for (int i = 0; i < genuses.Count; i++)
            {
                if (genuses[i].Name == name)
                    return true;
            }
            return false;
        }
    }

    public class GenusRead : Genus
    {
        public override void Read(List<Genus> genuses, Genus genus, TreeView TreeTaxonomy)
        {
            genuses.Add(genus);
            bool ends = false;
            for (int i = 0; i < TreeTaxonomy.Nodes.Count; i++)
            {
                for (int j = 0; j < TreeTaxonomy.Nodes[i].Nodes.Count; j++)
                {
                    if (TreeTaxonomy.Nodes[i].Nodes[j].Text == genus.family.Name)
                    {
                        TreeTaxonomy.Nodes[i].Nodes[j].Nodes.Add(genus.Name);
                        ends = true;
                        break;
                    }
                }
                if (ends == true) break;
            }
        }
    }

    public class GenusDelete : Genus
    {
        public override void Delete(List<Genus> genuses, TreeView TreeTaxonomy)
        {
            genuses.Remove(genuses.Find(family => family.Name == TreeTaxonomy.SelectedNode.Text));
            File.WriteAllLines("Genuses\\" + TreeTaxonomy.SelectedNode.Parent.Text + ".txt",
                File.ReadAllLines("Genuses\\" + TreeTaxonomy.SelectedNode.Parent.Text + ".txt", Encoding.Default).Where(s => !s.Contains(TreeTaxonomy.SelectedNode.Text)),
                Encoding.Default);
            string[] path = Directory.GetFiles("Species\\");
            foreach (string s in path)
            {
                if (@"Species\" + TreeTaxonomy.SelectedNode.Text + ".txt" == s)
                {
                    File.Delete(s);
                    break;
                }
            }
            TreeTaxonomy.SelectedNode.Remove();
        }
    }

    public class GenusChange : Genus
    {
        public override void Change(List<Genus> genuses, TreeView TreeTaxonomy, string name)
        {
            string[] gen = File.ReadAllLines("Genuses\\" + TreeTaxonomy.SelectedNode.Parent.Text + ".txt");
            StreamWriter us = new StreamWriter("Genuses\\" + TreeTaxonomy.SelectedNode.Parent.Text + ".txt");
            foreach (string s in gen)
            {
                if (s == TreeTaxonomy.SelectedNode.Text)
                    us.WriteLine(name);
                else us.WriteLine(s);
            }
            us.Close();
            if (File.Exists("Species\\" + TreeTaxonomy.SelectedNode.Text + ".txt"))
            {
                File.Copy("Species\\" + TreeTaxonomy.SelectedNode.Text + ".txt", "Species\\" + name + ".txt");
                File.Delete("Species\\" + TreeTaxonomy.SelectedNode.Text + ".txt");
            }
            genuses.Find(genus => genus.Name == TreeTaxonomy.SelectedNode.Text).Name = name;
            TreeTaxonomy.SelectedNode.Text = name;
        }
    }
    /// <summary>
    /// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// </summary>
    public class Specie : Genus, IType<Specie>
    {
        public Genus genus;

        public Specie() { }
        public Specie(Genus g, string i)
        {
            genus = g;
            family = g.family;
            order = g.order;
            Name = i;
        }

        virtual public void Add(List<Specie> species, Specie specie, TreeView TreeTaxonomy, string name) { }
        virtual public void Read(List<Specie> species, Specie specie, TreeView TreeTaxonomy) { }
        virtual public bool Check(List<Specie> species, string name) { return false; }
        virtual public void Delete(List<Specie> species, TreeView TreeTaxonomy) { }
        virtual public void Change(List<Specie> species, TreeView TreeTaxonomy, string name) { }
    }

    public class SpecieAdd : Specie
    {
        override public void Add(List<Specie> species, Specie specie, TreeView TreeTaxonomy, string name)
        {
            species.Add(specie);
            StreamWriter us = new StreamWriter("Species\\" + TreeTaxonomy.SelectedNode.Text + ".txt", true);
            us.WriteLine(specie.Name);
            us.Close();
            TreeTaxonomy.SelectedNode.Nodes.Add(name);
        }
    }

    public class SpecieCheck : Specie
    {
        public override bool Check(List<Specie> species, string name)
        {
            for (int i = 0; i < species.Count; i++)
            {
                if (species[i].Name == name)
                    return true;
            }
            return false;
        }
    }

    public class SpecieRead : Specie
    {
        public override void Read(List<Specie> species, Specie specie, TreeView TreeTaxonomy)
        {
            species.Add(specie);
            bool ends = false;
            for (int i = 0; i < TreeTaxonomy.Nodes.Count; i++)
            {
                for (int j = 0; j < TreeTaxonomy.Nodes[i].Nodes.Count; j++)
                {
                    for (int k = 0; k < TreeTaxonomy.Nodes[i].Nodes[j].Nodes.Count; k++)
                    {
                        if (TreeTaxonomy.Nodes[i].Nodes[j].Nodes[k].Text == specie.genus.Name)
                        {
                            TreeTaxonomy.Nodes[i].Nodes[j].Nodes[k].Nodes.Add(specie.Name);
                            ends = true;
                            break;
                        }
                    }
                    if (ends == true) break;
                }
                if (ends == true) break;
            }
        }
    }

    public class SpecieDelete : Specie
    {
        public override void Delete(List<Specie> species, TreeView TreeTaxonomy)
        {
            species.Remove(species.Find(genus => genus.Name == TreeTaxonomy.SelectedNode.Text));
            File.WriteAllLines("Species\\" + TreeTaxonomy.SelectedNode.Parent.Text + ".txt",
                File.ReadAllLines("Species\\" + TreeTaxonomy.SelectedNode.Parent.Text + ".txt", Encoding.Default).Where(s => !s.Contains(TreeTaxonomy.SelectedNode.Text)),
                Encoding.Default);
            TreeTaxonomy.SelectedNode.Remove();
        }
    }

    public class SpecieChange : Specie
    {
        public override void Change(List<Specie> species, TreeView TreeTaxonomy, string name)
        {
            string[] spe = File.ReadAllLines("Species\\" + TreeTaxonomy.SelectedNode.Parent.Text + ".txt");
            StreamWriter us = new StreamWriter("Species\\" + TreeTaxonomy.SelectedNode.Parent.Text + ".txt");
            foreach (string s in spe)
            {
                if (s == TreeTaxonomy.SelectedNode.Text)
                    us.WriteLine(name);
                else us.WriteLine(s);
            }
            us.Close();
            species.Find(specie => specie.Name == TreeTaxonomy.SelectedNode.Text).Name = name;
            TreeTaxonomy.SelectedNode.Text = name;
        }
    }

    public class AllRead
    {
        public void Read(List<Order> orders, List<Family> families, List<Genus> genuses, List<Specie> species, TreeView TreeTaxonomy)
        {
            orders.Clear();
            families.Clear();
            genuses.Clear();
            species.Clear();
            if (!File.Exists("Orders.txt"))
            {
                StreamWriter uu = new StreamWriter("Orders.txt");
                uu.Close();
            }
            OrderRead orderread = new OrderRead();
            orderread.Read(orders, orderread, TreeTaxonomy);
            FamilyRead familyRead = new FamilyRead();
            if (!Directory.Exists("Families"))
                Directory.CreateDirectory("Families");
            if (!Directory.Exists("Genuses"))
                Directory.CreateDirectory("Genuses");
            if (!Directory.Exists("Species"))
                Directory.CreateDirectory("Species");
            string[] path = Directory.GetFiles("Families\\");
            foreach (string a in path)
            {
                StreamReader fa = new StreamReader(a);
                string a1 = a.Replace(@"Families\", "");
                string input = fa.ReadLine();
                while (input != null)
                {
                    Family family = new Family(orders.Find(order => order.Name == a1.Replace(".txt", "")), input);
                    familyRead.Read(families, family, TreeTaxonomy);
                    input = fa.ReadLine();
                }
                fa.Close();
            }
            GenusRead genusRead = new GenusRead();
            path = Directory.GetFiles("Genuses\\");
            foreach (string a in path)
            {
                StreamReader fa = new StreamReader(a);
                string a1 = a.Replace(@"Genuses\", "");
                string input = fa.ReadLine();
                while (input != null)
                {
                    Genus genus = new Genus(families.Find(famil => famil.Name == a1.Replace(".txt", "")), input);
                    genusRead.Read(genuses, genus, TreeTaxonomy);
                    input = fa.ReadLine();
                }
                fa.Close();
            }
            SpecieRead specieRead = new SpecieRead();
            path = Directory.GetFiles("Species\\");
            foreach (string a in path)
            {
                StreamReader fa = new StreamReader(a);
                string a1 = a.Replace(@"Species\", "");
                string input = fa.ReadLine();
                while (input != null)
                {
                    Specie specie = new Specie(genuses.Find(genu => genu.Name == a1.Replace(".txt", "")), input);
                    specieRead.Read(species, specie, TreeTaxonomy);
                    input = fa.ReadLine();
                }
                fa.Close();
            }
        }
    }

    public class AllSort
    {
        public void Sort(TreeView TreeTaxonomy)
        {
            TreeTaxonomy.Nodes.Clear();
            string[] orders = File.ReadAllLines("Orders.txt");
            Array.Sort(orders);
            foreach (string o in orders)
            {
                TreeTaxonomy.Nodes.Add(o);
                if (File.Exists("Families\\" + o + ".txt"))
                {
                    /*foreach (string f in File.ReadAllLines("Families\\" + o + ".txt"))
                    {
                        TreeTaxonomy.Nodes[TreeTaxonomy.Nodes.Count - 1].Nodes.Add(f);
                        if (File.Exists("Genuses\\" + f + ".txt"))
                        {
                            foreach (string g in File.ReadAllLines("Genuses\\" + o + ".txt"))
                            {
                                //TreeTaxonomy.Nodes[TreeTaxonomy.Nodes.Count - 1].Nodes[].Nodes.Add(g);
                            }
                        }
                    }*/
                }
            }
        }
    }

    public class Orders
    {
    }
}
