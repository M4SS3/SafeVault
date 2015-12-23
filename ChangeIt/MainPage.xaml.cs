using System;
using System.Windows;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Popups;
using System.Xml.Serialization;
using System.Text;
using Windows.Storage;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ChangeIt
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        public Library Library = new Library();


        private void button_Register_Click(object sender, RoutedEventArgs e)
        {
            string un = Library.LoadSetting("Username");
            if (un == null)
            {
                try
                {
                    Library.SaveSetting("Username", Username.Text);
                    Library.SaveSetting("Password", Password1.Password);
                    Username.Text = string.Empty;
                    Password1.Password = string.Empty;
                    var dialog = new MessageDialog("Registered successfully");
                    dialog.ShowAsync();
                }
                catch (Exception ex)
                {
                    var dialog = new MessageDialog("Error", ex.Message);
                    dialog.ShowAsync();
                }
            }
            else
            {
                var dialog = new MessageDialog("User account already registered. Please log in using the username displayed above.", un);
                dialog.ShowAsync();
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            
            Frame.Navigate(typeof(IdeasPage));
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            string un = Library.LoadSetting("Username");
            string pw = Library.LoadSetting("Password");
            string un2 = usrLogin.Text;
            string pw2 = pwLogin1.Password;
            if (un==un2 && pw==pw2)
            {
                Frame.Navigate(typeof(IdeasPage));
            }
            else
            {
                var dialog = new MessageDialog("Incorrect username / password.");
                dialog.ShowAsync();
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Username.Text = string.Empty;
            Password1.Password = string.Empty;
        }

        private void pwLogin_PasswordChanged(object sender, RoutedEventArgs e)
        {

        }

        private void button1_Click_1(object sender, RoutedEventArgs e)
        {
            usrLogin.Text = string.Empty;
            pwLogin1.Password = string.Empty;
        }
    }
}
