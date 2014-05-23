using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lkvChat.Object
{
    public class user
    {
        public string username;
        public string pass;
        public bool status;
        public void setLogged(string u,string p)
        {
            username = u;
            pass = p;
            this.status = true;
        }
    }
}
