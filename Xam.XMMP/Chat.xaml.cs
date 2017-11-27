using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xam.XMMP
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Chat : ContentPage
    {
        private readonly SharpXMPP.XMPP.Client.Roster.Elements.RosterItem _rester;
        private readonly SharpXMPP.XmppClient _xmppconnetction;
        private readonly ObservableCollection<string> _messages = new ObservableCollection<string>();

        public Chat(SharpXMPP.XMPP.Client.Roster.Elements.RosterItem rester, SharpXMPP.XmppClient xmppconnetction)
        {
            InitializeComponent();
            _rester = rester;
            _xmppconnetction = xmppconnetction;

            _msg.ItemsSource = _messages;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _xmppconnetction.Message += _xmppconnetction_Message;
        }

        protected override void OnDisappearing()
        {
            _xmppconnetction.Message -= _xmppconnetction_Message;
            base.OnDisappearing();
        }

        private void _xmppconnetction_Message(SharpXMPP.XmppConnection sender, SharpXMPP.XMPP.Client.Elements.XMPPMessage e)
        {
            Device.BeginInvokeOnMainThread(() =>
                _messages.Add(e.Text)
            );
        }


        private void Send_Clicked(object sender, EventArgs args)
        {
            string text = _newMsg.Text;
            if (string.IsNullOrWhiteSpace(text))
            {
                return;
            }
            _messages.Add(text);
            _xmppconnetction.Send(new SharpXMPP.XMPP.Client.Elements.XMPPMessage
            {
                Text = text,
                To = new SharpXMPP.XMPP.JID(_rester.JID)
            });
            _newMsg.Text = string.Empty;
        }
    }
}