using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    interface IUsers<T>
    {
        string Nik { get; set; }
        string Password { get; set; }
        bool Check(List<T> users, string nik);
        int Check(List<T> users, string nik, string password);
        void Add(List<T> users, string nik, string password);
        void Show(TreeView TreeUsers);
    }
}
