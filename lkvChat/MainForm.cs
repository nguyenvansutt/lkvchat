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
    public partial class MainForm : Form
    {
        public user user;
        public MainForm()
        {
            InitializeComponent();
            
        }
        public void loadData(user userlogin)
        {
            this.user = userlogin;
            chat chatserv = new chat();

            try
            {
                chatserv.getListChat("http://support.ekecompany.com/index.php", this.user, this.user.username, this.user.pass);
                

            }
            catch (Exception exception)
            {

            }
        }

    }
}
