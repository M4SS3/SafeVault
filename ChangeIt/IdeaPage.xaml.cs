using ChangeIt.DAL;
using ChangeIt.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
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
    public sealed partial class IdeaPage : Page
    {
        private fsocietyDbContext _context;
        private IdeaEditViewModel _viewModel;

        public IdeaPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _context = new fsocietyDbContext();

            IdeaListViewModel model = (IdeaListViewModel)e.Parameter;
            if (model==null)
            {
                model = new IdeaListViewModel();
            }

            if (model.Id !=0)
            {
                _viewModel = _context.Ideas.Select(x => new IdeaEditViewModel
                {
                    Id = x.Id,
                    Content = x.Content,
                    Country = x.Country,
                    City = x.City,
                  //  UpVotes = x.UpVotes,
                  //  DownVotes = x.DownVotes
                }).FirstOrDefault(x => x.Id == model.Id);
            }
            else
            {
                _viewModel = new IdeaEditViewModel();
            }

            textBox.Text = _viewModel.Content ?? "";
            textBox1.Text = _viewModel.Country ?? "";
            textBox2.Text = _viewModel.City ?? "";
            //textBox3.Text = _viewModel.UpVotes.ToString();
            //textBox4.Text = _viewModel.DownVotes.ToString();

            base.OnNavigatedTo(e);
        }

        private void button_Save_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.Content = textBox.Text;
            _viewModel.Country = textBox1.Text;
            _viewModel.City = textBox2.Text;

            if(_viewModel.Id == 0)
            {
                Idea idea = new Idea
                {
                    Content = _viewModel.Content,
                    Country = _viewModel.Country,
                    City = _viewModel.City
                };
                _context.Ideas.Add(idea);
               try
                {
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageDialog dialog = new MessageDialog(ex.Message);
                    return;
                } 
                Frame.GoBack();
            }
            else
            {
                Idea idea = _context.Ideas.FirstOrDefault(x => x.Id == _viewModel.Id);
                idea.Content = _viewModel.Content;
                idea.Country = _viewModel.Country;
                idea.City = _viewModel.City;
                try
                {
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageDialog dialog = new MessageDialog(ex.Message);
                    return;
                }
                Frame.GoBack();
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }
    }
}
