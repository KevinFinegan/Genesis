using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenesisGUI
{
    public class Authorization{
        public enum SecurityFunctions
        {
            ViewOrders,
            EditCustomer
        }

        
        //This is a mock-up of a security class, in a real application the security would be held in the database and loaded into the cache on start-up

        private HashSet<SecurityFunctions> _AllowedFunctions;

        public Authorization() {
            _AllowedFunctions = new HashSet<SecurityFunctions>();

            _AllowedFunctions.Add(SecurityFunctions.ViewOrders);
            //KF Comment this out to see the error
            _AllowedFunctions.Add(SecurityFunctions.EditCustomer);
        }

        public bool CanUser(SecurityFunctions e){
            return _AllowedFunctions.Contains(e);
        }

    }
}
