using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;
using System.Text;
using lkvChat.webservice;
using lkvChat.Object;
namespace lkvChat
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
        
            chat chatserv = new chat();            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);                       
            
            var main = new MainForm();
            login loginform = new login();
            var result = loginform.ShowDialog();
            if (result == DialogResult.OK)
            {
                
                if (loginform.user.status)
                {
                    main.loadData(loginform.user);
                    main.ShowDialog();
                }
            }

           

           
            
        }
    }
}
