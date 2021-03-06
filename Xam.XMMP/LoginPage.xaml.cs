﻿using Acr.UserDialogs;
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
        public LoginPage()
        {
            InitializeComponent();
        }


        public async void Login_Click(object sender, EventArgs args)
        {
            var login = _login.Text;
            var pass = _pass.Text;

            IsBusy = true;
            var client = new XmppClient(new SharpXMPP.XMPP.JID(login), pass);
            await client.Connect();
            IsBusy = false;
            await Navigation.PushModalAsync(new Users(client));
        }
    }
}