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

    public partial class CRUD_class : Window
    {
        public CRUD_class()
        {
            InitializeComponent();
            LoadScreen();
        }

        public string TableValues(int i)
        {
            try
            {
                DataGridCellInfo cellInfo = tblClass.SelectedCells[i];
                DataGridBoundColumn column = cellInfo.Column as DataGridBoundColumn;
                FrameworkElement element = new FrameworkElement() { DataContext = cellInfo.Item };
                BindingOperations.SetBinding(element, TagProperty, column.Binding);

                return (element.Tag.ToString());
            }
            catch (ArgumentOutOfRangeException)
            {
                Xceed.Wpf.Toolkit.MessageBox.Show("Por favor, selecione um produto.", "Aviso!", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK);
            }

            return null;

        }

        public void LoadScreen()
        {
            DAOClass _class= new DAOClass();

            //loads the table.
            tblClass.CanUserAddRows = false;
            tblClass.IsReadOnly = true;
            tblClass.AutoGenerateColumns = false;
            tblClass.ItemsSource = _class.LoadClasses();
            lblCount.Content = tblClass.Items.Count;
        }

        private void btnRegisterClass_Click(object sender, RoutedEventArgs e)
        {
            REG_Class reg_class = new REG_Class();
            reg_class.ShowDialog();
            LoadScreen();
        }

        private void tblClass_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (TableValues(0) != null)
            {
                REG_Class reg_c = new REG_Class(Int16.Parse(TableValues(0)));
                reg_c.ShowDialog();
                LoadScreen();
            }
        }

        private void btnViewClass_Click(object sender, RoutedEventArgs e)
        {
            if (TableValues(0) != null)
            {
                REG_Class reg_c = new REG_Class(Int16.Parse(TableValues(0)));
                reg_c.ShowDialog();
                LoadScreen();
            }
        }

        private void btnEditClass_Click(object sender, RoutedEventArgs e)
        {
            if (TableValues(0) != null)
            {
                REG_Class reg_c = new REG_Class(Int16.Parse(TableValues(0)));
                reg_c.ShowDialog();
                LoadScreen();
            }
        }

        private void btnDeleteClass_Click(object sender, RoutedEventArgs e)
        {
            if(TableValues(0) != null)
            {

                MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show("Você tem certeza de que gostaria de excluir esta turma?",
               "Aviso!", MessageBoxButton.YesNoCancel);
                if (result == MessageBoxResult.Yes)
                {
                    DAOClass dao = new DAOClass();
                    if (dao.DeleteClass(Int16.Parse(TableValues(0))))
                    {
                        Xceed.Wpf.Toolkit.MessageBox.Show("Turma excluída com sucesso.", "Suceso!", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
                    }
                    else
                    {
                        Xceed.Wpf.Toolkit.MessageBox.Show("Algo errado aconteceu durante a exclusão. Tente novamente mais tarde.", "Erro!", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                    }
                }
                else
                {

                }

            }
            LoadScreen();
        }
    }
}
