using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenesisGUI
{
    public interface IGenesisGUIForm : IComparable {
        int Id {get; set;}   
        string Description {get;}
        void SetDescription();
        MDIMain GUIParent {get; set;} 

        void RemoveFormFromListOfWindows();

    }
}
