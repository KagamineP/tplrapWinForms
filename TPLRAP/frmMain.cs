/**
 * frmMain.cs
 * Created by KagamineP (Dmitry Kiryanov)
 * Licensed under BSD 3-Clause License
 */

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
        private ChromiumWebBrowser chromeBrowser;

        public FrmMain()
        {
#if DEBUG
            MessageBox.Show(Properties.Resources.DebugMessageText, Properties.Resources.DebugMessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            MessageBox.Show("CefSharp version: " + AssemblyInfo.AssemblyVersion, "Debug configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
#endif
            InitializeComponent();
            InitializeChromium();
        }

        public ChromiumWebBrowser ChromeBrowser { get => chromeBrowser; set => chromeBrowser = value; }

        #region All, what connected with CefSharp settings
        public void InitializeChromium()
        {
            CefSettings settings = new CefSettings();
            Cef.Initialize(settings);
            ChromeBrowser = new ChromiumWebBrowser("http://tplinkwifi.net/");
            this.Controls.Add(ChromeBrowser);
            ChromeBrowser.Dock = DockStyle.Fill;
            ChromeBrowser.MenuHandler = new MenuHandler();

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
#if DEBUG
            AutoUpdater.Start("http://kagaminep.ru/tplrap/insider/insider.xml");
#else
            AutoUpdater.Start("http://kagaminep.ru/tplrap/release/release.xml");
#endif
        }
#endregion
    }
}
