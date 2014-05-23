using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using lkvChat.webservice;
using lkvChat.Object;
namespace lkvChat
{
    public partial class login : Form 
    {
        public user user{get;set;}        
        public login()
        {
            this.user = new user();           
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chat chatserv = new chat();
            
            try
            {
                chatserv.login("http://support.ekecompany.com/index.php", this.user, this.username.Text, this.password.Text);
                this.Close();
                
            }
            catch (Exception exception)
            {

            }
        }
    }
}
