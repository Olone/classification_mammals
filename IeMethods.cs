using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public static class IeMethods
    {
        [DllImport("urlmon.dll", CharSet = CharSet.Ansi)]
        private static extern int UrlMkSetSessionOption(int dwOption, string pBuffer, int dwBufferLength, int dwReserved);

        public static void SetAnotherUserAgent(string ua)
        {
            const int urlmonOptionUseragent = 0x10000001;
            const int urlmonOptionUseragentRefresh = 0x10000002;
            var UserAgent = ua;
            UrlMkSetSessionOption(urlmonOptionUseragentRefresh, null, 0, 0);
            UrlMkSetSessionOption(urlmonOptionUseragent, UserAgent, UserAgent.Length, 0);
        }

        public static void SetBrowserEmulation(int version)
        {
            string program = Application.ExecutablePath.Split('\\').Reverse().ToList()[0];
            var key = "SOFTWARE\\Microsoft\\Internet Explorer\\Main\\FeatureControl\\FEATURE_BROWSER_EMULATION";

            RegistryKey hkcu = Registry.CurrentUser.CreateSubKey(key);
            hkcu.SetValue(program, version, RegistryValueKind.DWord);
            hkcu.Close();
        }
    }
}
