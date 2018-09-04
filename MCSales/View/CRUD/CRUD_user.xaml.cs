using MCSales.Model;
using MCSales.Model.DAO;
using MCSales.View.Registration;
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

namespace MCSales.View.CRUD
{
    public partial class CRUD_user : Window
    {
        public CRUD_user()
        {
            InitializeComponent();
            LoadScreen();
        }

        public string TableValues(int i)
        {
            try
            {
                DataGridCellInfo cellInfo = tblUser.SelectedCells[i];
                DataGridBoundColumn column = cellInfo.Column as DataGridBoundColumn;
                FrameworkElement element = new FrameworkElement() { DataContext = cellInfo.Item };
                BindingOperations.SetBinding(element, TagProperty, column.Binding);

                return (element.Tag.ToString());
            }
            catch (ArgumentOutOfRangeException)
            {
                Xceed.Wpf.Toolkit.MessageBox.Show("Por favor, selecione um usuário.", "Aviso!", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK);
            }

            return null;

        }

        public void LoadScreen()
        {
            DAOUser dao = new DAOUser();

            //loads the table.
            tblUser.CanUserAddRows = false;
            tblUser.IsReadOnly = true;
            tblUser.AutoGenerateColumns = false;
            tblUser.ItemsSource = dao.LoadUsers();
            lblCount.Content = tblUser.Items.Count;
        }

        private void btnRegisterUser_Click(object sender, RoutedEventArgs e)
        {
            REG_user reg_u = new REG_user(null);
            reg_u.ShowDialog();
            LoadScreen();
        }

        private void btnDeleteUser_Click(object sender, RoutedEventArgs e)
        {
            if (TableValues(0) != null)
            {
                MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show("Você tem certeza de que gostaria de excluir este usuário? AVISO! Se o usuário for um professor todas suas turmas serão excluídas.",
               "Aviso!", MessageBoxButton.YesNoCancel);
                if (result == MessageBoxResult.Yes)
                {
                    DAOUser dao = new DAOUser();
                    TOUser u = new TOUser();
                    u = dao.Selection(Int16.Parse(TableValues(0)));
                    if (dao.DeleteUser(u))
                    {
                        Xceed.Wpf.Toolkit.MessageBox.Show("Usuário excluído com sucesso.", "Sucesso!", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
                    }else
                    {
                        Xceed.Wpf.Toolkit.MessageBox.Show("Algo errado aconteceu durante a exclusão.", "Erro!", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                    }
                }
                else
                {
                    //Do nothing.
                }
            }
            else
            {
            }
            LoadScreen();
        }

        private void btnEditUser_Click(object sender, RoutedEventArgs e)
        {
            if (TableValues(0) != null)
            {
                DAOUser dao = new DAOUser();
                TOUser i = new TOUser();
                i = dao.Selection(Int16.Parse(TableValues(0)));

                REG_user reg_u = new REG_user(i);
                reg_u.ShowDialog();

                LoadScreen();
            }
        }

        private void btnViewUser_Click(object sender, RoutedEventArgs e)
        {
            if (TableValues(0) != null)
            {
                DAOUser dao = new DAOUser();
                TOUser i = new TOUser();
                i = dao.Selection(Int16.Parse(TableValues(0)));

                REG_user reg_u = new REG_user(i);
                reg_u.ShowDialog();

                LoadScreen();
            }
        }

        private void tblUser_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (TableValues(0) != null)
            {
                DAOUser dao = new DAOUser();
                TOUser i = new TOUser();
                i = dao.Selection(Int16.Parse(TableValues(0)));

                REG_user reg_u = new REG_user(i);
                reg_u.ShowDialog();

                LoadScreen();
            }
        }
    }
}
