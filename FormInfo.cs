using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class FormInfo : Form
    {
        public FormInfo()
        {
            IeMethods.SetBrowserEmulation(11001);
            InitializeComponent();
        }

        private void FormInfo_Load(object sender, EventArgs e)
        {
            WebBrowserInfo.Url = new Uri("https://ru.wikipedia.org/wiki/Млекопитающие");
            WebBrowserInfo.Update();
        }

        private void FormInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            WebBrowserInfo.Dispose();
        }
    }
}
