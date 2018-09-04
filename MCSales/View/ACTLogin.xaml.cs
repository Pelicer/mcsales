using System;
using System.Collections.Generic;
using System.Linq;
using Xceed.Wpf.Toolkit;
using System.Text;
using System.Windows;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MCSales.Model;
using MCSales.Model.DAO;

namespace MCSales.View
{
    public partial class ACTLogin : Window
    {
        TOUser user = new TOUser();

        public ACTLogin()
        {
            InitializeComponent();
            txtUser.Focus();
        }

        private void txtUser_GotFocus(object sender, RoutedEventArgs e)
        {
            txtUser.Mask = "";
            txtUser.Text = "";
        }

        private void txtUser_LostFocus(object sender, RoutedEventArgs e)
        {
            if(txtUser.Text == "")
            {
                txtUser.Mask = "Usuário";
            }else
            {
                user.User_name = txtUser.Text;
            }
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            DAOUser dao = new DAOUser();
            TOUser ver = new TOUser();
            ver = dao.Login(user.User_name, user.User_password);
            if(ver.User_id != 0)
            {
                ACTIndex index = new ACTIndex(ver);
                index.Show();
                this.Close();
            }else
            {
                Xceed.Wpf.Toolkit.MessageBox.Show("Crecendicais incorretas ou não cadastradas.", "Erro!", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void psbPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            user.User_password = psbPassword.Password;
        }

        private void psbPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                DAOUser dao = new DAOUser();
                TOUser ver = new TOUser();
                ver = dao.Login(user.User_name, user.User_password);
                if (ver.User_id != 0)
                {
                    ACTIndex index = new ACTIndex(ver);
                    index.Show();
                    this.Close();
                }
                else
                {
                    Xceed.Wpf.Toolkit.MessageBox.Show("Crecendicais incorretas ou não cadastradas.", "Erro!", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                }
            }
        }
    }
}
