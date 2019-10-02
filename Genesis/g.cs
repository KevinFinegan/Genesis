using EventLogging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GenesisGUI.Authorization;

namespace GenesisGUI
{
    public class g {
        //g is short for Global.  Anything that the whole GUI needs to be able to access goes here, everyting should be marked as static.

        private static List<IGenesisGUIForm> _lstForms;
        private static IGenesisGUIForm _frmActiveForm;
        private static Authorization _authorization;
        private static Events _events;

        public static int MaxFormId {get; set;}
        public static string DefaultSkin {get; set;}

        public static IGenesisGUIForm ActiveForm {
            get {return _frmActiveForm;} 
            set{ _frmActiveForm = value;}
        }

        public static List<IGenesisGUIForm> Forms {
            get {return _lstForms; }
            set {_lstForms = value;}
        }
                       
        public static int FormsAdd(IGenesisGUIForm frm){
            _lstForms.Add(frm);
            return _lstForms.Count;
        }

        public g() {
            _lstForms = new List<IGenesisGUIForm>();
            _authorization = new Authorization();

            _events = new Events();
            _events.EventLevelToLog = Events.EventLevel.Exception;
            _events.ShowMessage = true;
            _events.OutputToDatabase = true;
            _events.OutputToLogFile = true;

            g.DefaultSkin = "Sharp";
        }

        public static bool CanUser(SecurityFunctions e) {
            return _authorization.CanUser(e);
        }

        public static void LogEvent(string message, Events.EventLevel level) {
            _events.LogEvent(message, level);
        }

        public static void LogEventSilently(string message, Events.EventLevel level) {
            _events.LogEvent(message, level, true);
        }

    }
}
