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
            
            main.ShowDialog();

            if (main.user == null)
            {
                login loginfrom = new login();
                var result = loginfrom.ShowDialog();
                if (result == DialogResult.OK)
                {
                    main.user = loginfrom.user;
                    if (main.user.status)
                    {
                        Conversation conversation = new Conversation();
                        conversation.ShowDialog();
                    }
                }
            }
            
            
        }
    }
}
