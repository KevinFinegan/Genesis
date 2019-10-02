using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenesisGUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.UnhandledException += new UnhandledExceptionEventHandler(UnhandledHandler);

            DevExpress.UserSkins.BonusSkins.Register();
            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.Skins.SkinManager.EnableMdiFormSkins();

            //KF uncomment this to test UnhandledHandler
            //int i = int.Parse("exception");

            Application.Run(new MDIMain());
        }

        static void UnhandledHandler(object sender, UnhandledExceptionEventArgs args){
            Exception e = (Exception) args.ExceptionObject;

            //KF: Sometimes better to show in a non-DX way so that if the dlls are not there then it still runs ok.
            MessageBox.Show(e.Message, "Unhandled Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);

            g.LogEventSilently(e.Message, EventLogging.Events.EventLevel.Exception);
        }
    }
}
