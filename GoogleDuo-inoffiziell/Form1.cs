using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoogleDuo_inoffiziell
{
    public partial class Form1 : Form
    {

        ChromiumWebBrowser chromium;

        public Form1()
        {
            InitializeComponent();

            // Initialzie the Browser on Start
            BrowserInitialize();
        }


        public void BrowserInitialize()
        {
            var settings = new CefSettings();

            settings.CachePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\TS-GoogleDuo";

            Cef.Initialize(settings);

            // Start Chromium Webbrowser
            chromium = new ChromiumWebBrowser("https://duo.google.com");

            // Add Chromium to window
            this.Controls.Add(chromium);

            // Dockstyle to fill Form
            chromium.Dock = DockStyle.Fill;

            // Start the Browser and Initialize it
            InitializeComponent();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Stop Cef (Chromium Web Browser Wrapper) if the is getting Closed
            Cef.Shutdown();
        }
    }
}
