using Hleb.Classes;
using Hleb.Classes.Interfaces;
using Hleb.Classes.Model;
using Hleb.Classes.Repository;
using Hleb.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hleb
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IRepository _repo = Factory.Instance.GetRepository();

        public MainWindow()
        {
            //var check = new JsRepository();
            //var check = new Checker();
            InitializeComponent();
            

        }

        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            if(_repo.Authorize(textBoxLogin.Text, textBoxPassword.ToString()))
            {
                UserWindow mw = new UserWindow();
                mw.Show();
                Close();
            }
            else
                MessageBox.Show("try input again");

        }

        private void ButtonRegistration_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            RegistrationWindow rw = new RegistrationWindow();
            rw.RegistrationFinished += Registration_Finished;
            rw.Show();
        }

        private void Registration_Finished()
        {
            Show();
        }
    }
}
