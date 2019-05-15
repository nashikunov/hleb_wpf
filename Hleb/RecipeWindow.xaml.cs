using Hleb.Classes.DTO;
using Hleb.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Navigation;
using System.Net.Http;
using Hleb.Classes;
using Hleb.Classes.Interfaces;

namespace Hleb
{
    /// <summary>
    /// Логика взаимодействия для RecipeWindow.xaml
    /// </summary>
    public partial class RecipeWindow : Window
    {
        APIrequest _request = new API();
        WebBrowser wb = new WebBrowser();

        ListOfRecepies rc = new ListOfRecepies();

        IRepository _repo = Factory.Instance.GetRepository();

        public RecipeWindow(string id)
        {
            InitializeComponent();
            rc = _request.GetRecipe(id);

            using (var client = new HttpClient())
            {              
                BitmapImage img = new BitmapImage();
                img.BeginInit();
                img.UriSource = new Uri(rc.Recipe.ImageURI, UriKind.RelativeOrAbsolute);
                img.CacheOption = BitmapCacheOption.OnLoad;
                img.EndInit();              
                Img.Source = img;              
            }
            
            
            foreach (var ingr in rc.Recipe.Ingredients)
            {                              
                TextBlock tb = new TextBlock();
                tb.FontSize = 20;
                tb.TextWrapping = TextWrapping.Wrap;
                Stack.Children.Add(tb);
                tb.Text = ingr;
                

            }
            
            Hyper.NavigateUri = rc.Recipe.DetailsURL;
            nametxt.Text = rc.Recipe.Name;

            rate.Text += Math.Round(rc.Recipe.Rating);

        }

        private void Clic_fav(object sender, RoutedEventArgs e)
        {
            if (_repo.AddFavourite(rc.Recipe.Id, _repo.AuthorizedUser.Id, Description.Text))
                MessageBox.Show("Added");
            else
                MessageBox.Show("something wrong with added");
        }

        private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }
    }
}
