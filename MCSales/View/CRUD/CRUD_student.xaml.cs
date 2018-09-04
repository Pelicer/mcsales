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
    public partial class CRUD_student : Window
    {
        public CRUD_student()
        {
            InitializeComponent();
            LoadScreen();
        }

        private void btnRegisterStudent_Click(object sender, RoutedEventArgs e)
        {
            REG_student reg_stu = new REG_student();
            reg_stu.ShowDialog();
            LoadScreen();
        }

        public string TableValues(int i)
        {
            try
            {
                DataGridCellInfo cellInfo = tblStudents.SelectedCells[i];
                DataGridBoundColumn column = cellInfo.Column as DataGridBoundColumn;
                FrameworkElement element = new FrameworkElement() { DataContext = cellInfo.Item };
                BindingOperations.SetBinding(element, TagProperty, column.Binding);

                return (element.Tag.ToString());
            }
            catch (ArgumentOutOfRangeException)
            {
                Xceed.Wpf.Toolkit.MessageBox.Show("Por favor, selecione um aluno.", "Aviso!", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK);
            }

            return null;

        }

        public void LoadScreen()
        {
            DAOStudents dao = new DAOStudents();

            //loads the table.
            tblStudents.CanUserAddRows = false;
            tblStudents.IsReadOnly = true;
            tblStudents.AutoGenerateColumns = false;
            tblStudents.ItemsSource = dao.LoadStudents();
            lblCount.Content = tblStudents.Items.Count;
        }

        private void btnDeleteStudent_Click(object sender, RoutedEventArgs e)
        {
            if (TableValues(0) != null)
            {
                MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show("Você tem certeza de que gostaria de excluir este aluno?",
               "Aviso!", MessageBoxButton.YesNoCancel, MessageBoxImage.Information);
                if (result == MessageBoxResult.Yes)
                {
                    DAOStudents dao = new DAOStudents();
                    if (dao.DeleteStudent(TableValues(0)))
                    {
                        Xceed.Wpf.Toolkit.MessageBox.Show("Aluno excluído com sucesso.", "Sucesso!", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
                    }
                    else
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

        private void btnEditStudent_Click(object sender, RoutedEventArgs e)
        {
            if (TableValues(0) != null)
            {
                DAOStudents dao = new DAOStudents();
                TOStudent i = new TOStudent();
                i = dao.Selection(TableValues(0));

                REG_student reg_s = new REG_student(i);
                reg_s.ShowDialog();

                LoadScreen();
            }
        }

        private void btnViewStudent_Click(object sender, RoutedEventArgs e)
        {
            if (TableValues(0) != null)
            {
                DAOStudents dao = new DAOStudents();
                TOStudent i = new TOStudent();
                i = dao.Selection(TableValues(0));

                REG_student reg_s = new REG_student(i);
                reg_s.ShowDialog();

                LoadScreen();
            }
        }

        private void tblStudents_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (TableValues(0) != null)
            {
                DAOStudents dao = new DAOStudents();
                TOStudent i = new TOStudent();
                i = dao.Selection(TableValues(0));

                REG_student reg_s = new REG_student(i);
                reg_s.ShowDialog();

                LoadScreen();
            }
        }
    }
}
