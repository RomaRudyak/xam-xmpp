using Sharp.Xmpp.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xam.XMMP
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();
		}


        public void Login_Click(object sender, EventArgs args)
        {
            var login = _login.Text;
            var pass = _pass.Text;

            using (var client = new XmppClient("jabber.to", login, pass))
            {
                client.SendMessage(new Sharp.Xmpp.Im.Message(new Sharp.Xmpp.Jid("xam.jab@jabber.to"), "Hi xam!!"));
            }
        }
	}
}