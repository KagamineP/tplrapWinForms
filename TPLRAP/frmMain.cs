using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using CefSharp.WinForms.Internals;
using AutoUpdaterDotNET;

namespace TPLRAP
{
    public partial class FrmMain : Form
    {
        public ChromiumWebBrowser chromeBrowser;

        public FrmMain()
        {
#if DEBUG
            MessageBox.Show(Properties.Resources.DebugMessageText, Properties.Resources.DebugMessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            MessageBox.Show("CefSharp version: " + AssemblyInfo.AssemblyVersion, "Debug configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
#endif
            InitializeComponent();
            InitializeChromium();
        }

        #region All, what connected with CefSharp settings
        public void InitializeChromium()
        {
            CefSettings settings = new CefSettings();
            Cef.Initialize(settings);
            chromeBrowser = new ChromiumWebBrowser("http://tplinkwifi.net/");
            this.Controls.Add(chromeBrowser);
            chromeBrowser.Dock = DockStyle.Fill;
            chromeBrowser.MenuHandler = new menuHandler();
        }
        #endregion


        #region Response to clicking the close button is DISABLED. If you need this function, uncomment it.
        /* protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (CloseCancel()==false)
            {
                e.Cancel = true;
            };
        }

        public static bool CloseCancel()
        {
            var result = MessageBox.Show(Properties.Resources.ConfirmExitMessage, Properties.Resources.DebugMessageTitle,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
                return true;
            else
                return false;
        }
        */
        #endregion


        #region AutoUpdater
        private void FrmMain_Load(object sender, EventArgs e)
        {
            AutoUpdater.Start("http://kagaminep.ru/tplrap/updates/tplrap.xml");
        }
        #endregion
    }
}
