using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Model
{
    public class Tourist : User
    {
        

        public bool IsPresent { get; set; }


        public Tourist(string username, string password, UserType userType) : base(username, password, userType)
        {
        }
        public Tourist(string username, string password, UserType userType, bool isPresent) : base(username, password, userType)
        {
            IsPresent = isPresent;
        }
    }
}
