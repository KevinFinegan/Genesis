using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenesisGUI
{
    
    public class CustomerSaveEventArgs : EventArgs
    {
        public Guid CustomerId { get; set; }
        public string NewFullName { get; set; }
    }
}
