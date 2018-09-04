using MCSales.Model;
using MCSales.Model.DAO;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace MCSales.View.Registration
{
    public partial class REG_user : Window
    {

        TOUser user = new TOUser();
        int op = 0; //operação de cadastro.


        public REG_user(TOUser i)
        {
            InitializeComponent();

            user = i;

            if (i == null)
            {
            }
            else
            {
                op = 1;

                this.Title = "Editar Usuário";
                
                txtUser.IsEnabled = false;
                psbPassword.IsEnabled = false;
                comboBox.IsEnabled = false;

                TOUser user = new TOUser(); user = i;
                txtUser.Text = user.User_name;
                psbPassword.Password = user.User_password;
                comboBox.SelectedIndex = user.Permission_id;

                //set to edit.
                btnRegisterUser.Content = "Editar";
            }

        }

        private void btnRegisterUser_Click(object sender, RoutedEventArgs e)
        {
            if(btnRegisterUser.Content.ToString() == "Editar")
            {
                txtUser.IsEnabled = true;
                psbPassword.IsEnabled = true;
                comboBox.IsEnabled = true;
                btnRegisterUser.Content = "Cadastrar";

            }else
            {
                if(op != 0)
                {
                    DAOUser dao = new DAOUser();


                    //setting values to user.
                    user.User_name = txtUser.Text;
                    user.User_password = psbPassword.Password;

                    if (comboBox.SelectedItem == Administrador) { user.Permission_id = 1; }
                    else if (comboBox.SelectedItem == Administração) { user.Permission_id = 2; }
                    else if (comboBox.SelectedItem == Vendas) { user.Permission_id = 3; }
                    else { user.Permission_id = 4; }


                    if (dao.Update(user))
                    {
                        Xceed.Wpf.Toolkit.MessageBox.Show("Usuário editado com sucesso!", "Sucesso!", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
                        this.Close();
                    }
                    else
                    {
                        Xceed.Wpf.Toolkit.MessageBox.Show("Algo errado aconteceu durante a edição.", "Erro!", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                        this.Close();
                    }
                }
                else
                {
                    DAOUser dao = new DAOUser();
                    TOUser user = new TOUser();

                    //setting values to user.
                    user.User_name = txtUser.Text;
                    user.User_password = psbPassword.Password;

                    if (comboBox.SelectedItem == Administrador) { user.Permission_id = 1; }
                    else if (comboBox.SelectedItem == Administração) { user.Permission_id = 2; }
                    else if (comboBox.SelectedItem == Vendas) { user.Permission_id = 3; }
                    else { user.Permission_id = 4; }


                    if (dao.Registration(user))
                    {
                        Xceed.Wpf.Toolkit.MessageBox.Show("Usuário cadastrado com sucesso!", "Sucesso!", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
                        this.Close();
                    }
                    else
                    {
                        Xceed.Wpf.Toolkit.MessageBox.Show("Algo errado aconteceu durante o cadastro.", "Erro!", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                        this.Close();
                    }

                }
            }
            
        }

    }
}
