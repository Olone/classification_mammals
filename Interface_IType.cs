using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    interface IType<T>
    {
        string Name { get; set; }
        void Add(List<T> type, T type1, TreeView TreeTaxonomy, string name);
        void Read(List<T> type, T type1, TreeView TreeTaxonomy);
        bool Check(List<T> type, string name);
        void Delete(List<T> type, TreeView TreeTaxonomy);
        void Change(List<T> tupe, TreeView TreeTaxonomy, string name);
    }
}
