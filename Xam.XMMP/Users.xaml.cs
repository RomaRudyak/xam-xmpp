using SharpXMPP.XMPP.Client.Roster.Elements;
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
	public partial class Users : ContentPage
	{
        private readonly SharpXMPP.XmppClient _xmppconnetction;

        public Users()
        {
            InitializeComponent();

        }

        public Users (SharpXMPP.XmppClient connection)
        {
            InitializeComponent();
            _xmppconnetction = connection;
            _users.ItemsSource = connection.RosterManager.Roster;
        }

        public void RosterSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }
            var rester = (RosterItem)e.SelectedItem;
            Navigation.PushModalAsync(new Chat(rester));
        }
    }
}