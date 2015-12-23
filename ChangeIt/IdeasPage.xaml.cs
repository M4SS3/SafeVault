using ChangeIt.DAL;
using ChangeIt.Models;
using System;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ChangeIt
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class IdeasPage : Page
    {
        private fsocietyDbContext _context;
        private IEnumerable<IdeaListViewModel> _ideas;

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _context = new fsocietyDbContext();
            _ideas = _context.Ideas.Select(x => new IdeaListViewModel
            {
                Id = x.Id,
                Content = x.Content,
                Country = x.Country,
                City=x.City
            }).ToList();

            IdeaslistView.ItemsSource = _ideas;

            base.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            _context.Dispose();
            base.OnNavigatedFrom(e);
        }
        public IdeasPage()
        {
            this.InitializeComponent();
        }

        private void IdeaslistView_ItemClick(object sender, ItemClickEventArgs e)
        {
            IdeaListViewModel viewModel = (IdeaListViewModel)e.ClickedItem;
            Frame.Navigate(typeof(IdeaPage), viewModel);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(IdeaPage));
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
    }
}
