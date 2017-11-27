using Acr.UserDialogs;
using SharpXMPP;
using SharpXMPP.XMPP.Client.Elements;
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
        private string _domain = "@chinwag.im";


        public LoginPage ()
		{
			InitializeComponent ();
		}


        public void Login_Click(object sender, EventArgs args)
        {
            var login = _login.Text;
            var pass = _pass.Text;

            var client = new XmppClient(new SharpXMPP.XMPP.JID($"{login}@{_domain}"), pass);
            client.Connect();
            client.ConnectionFailed += Client_ConnectionFailed;
            client.SignedIn += Client_SignedIn;
        }

        private void Client_SignedIn(XmppConnection sender, SignedInArgs e)
        {
            sender.Send(new XMPPMessage() {
                Text = "Hello RORU!",
                To = e.Jid
            });
        }

        private void Client_ConnectionFailed(XmppConnection sender, ConnFailedArgs e)
        {
            UserDialogs.Instance.Alert(new AlertConfig
            {
                Message = e.Message
            });
        }
    }
}