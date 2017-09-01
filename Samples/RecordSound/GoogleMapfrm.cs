using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecordSound
{
    public partial class GoogleMapfrm : Form
    {
        public GoogleMapfrm()
        {
            InitializeComponent();
            webBrowserGoogleMap.ScriptErrorsSuppressed = true;
        }

        private void GoogleMapfrm_Load(object sender, EventArgs e)
        {
            try
            {
                string lat = "40.713956";
                string lon = "-74.006653";
                string path = AssemblyDirectory + "\\map.html?lat=" + lat + "&lon=" + lon + "";
                webBrowserGoogleMap.Url = new Uri(path);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Unable to Retrieve Map");
            }
        }

        public static string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
