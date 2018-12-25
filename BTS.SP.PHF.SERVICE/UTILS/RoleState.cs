using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTS.SP.PHF.SERVICE.UTILS
{
    public class RoleState
    {
        public string STATE { get; set; }
        public bool View { get; set; }
        public bool Add { get; set; }
        public bool Edit { get; set; }
        public bool Delete { get; set; }
        public bool Approve { get; set; }

        public RoleState()
        {
            STATE = "";
            View = false;
            Add = false;
            Edit = false;
            Delete = false;
            Approve = false;
        }
    }
}