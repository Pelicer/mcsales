using MCSales.Model;
using MCSales.Model.DAO;
using MCSales.View.CRUD;
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

namespace MCSales.View
{
    public partial class ACTIndex : Window
    {
        TOUser user = new TOUser();
        TOClass _class = new TOClass();


        public ACTIndex(TOUser i)
        {
            user = i;

            InitializeComponent();

            lblWellcome.Content = "Bem-vindo, " + user.User_name + "!";
            if (user.Permission_id == 1)
            {
            }else if(user.Permission_id == 2)
            {
                btnCRUD_user.Visibility = Visibility.Hidden;
            }else if(user.Permission_id == 3)
            {
                btnCRUD_user.Visibility = Visibility.Hidden;
                btnCRUD_class.Visibility = Visibility.Hidden;
            }
            LoadIndex();
        }

        public void LoadIndex()
        {
            DAOClass dao = new DAOClass();
            if (dao.VacancyCount("segunda") == 0)
            {
                lblMondayVacancys.Content = "Não há vagas.";
                lblMondayVacancys.Foreground = new SolidColorBrush(Colors.LightGray);
            }
            else
            {
                lblMondayVacancys.Content = dao.VacancyCount("segunda");
                lblMondayVacancys.Foreground = new SolidColorBrush(Colors.Red);
            }

            if (dao.VacancyCount("terça") == 0)
            {
                lblTuesdayVacancys.Content = "Não há vagas.";
                lblTuesdayVacancys.Foreground = new SolidColorBrush(Colors.LightGray);
            }
            else
            {
                lblTuesdayVacancys.Content = dao.VacancyCount("terça");
                lblTuesdayVacancys.Foreground = new SolidColorBrush(Colors.Red);
            }

            if (dao.VacancyCount("quarta") == 0)
            {
                lblWednesdayVacancys.Content = "Não há vagas";
                lblWednesdayVacancys.Foreground = new SolidColorBrush(Colors.LightGray);
            }
            else
            {
                lblWednesdayVacancys.Content = dao.VacancyCount("quarta");
                lblWednesdayVacancys.Foreground = new SolidColorBrush(Colors.Red);
            }

            if (dao.VacancyCount("quinta") == 0)
            {
                lblThursdayVacancys.Content = "Não há vagas.";
                lblThursdayVacancys.Foreground = new SolidColorBrush(Colors.LightGray);
            }
            else
            {
                lblThursdayVacancys.Content = dao.VacancyCount("quinta");
                lblThursdayVacancys.Foreground = new SolidColorBrush(Colors.Red);
            }

            if (dao.VacancyCount("sexta") == 0)
            {
                lblFridayVacancys.Content = "Não há vagas.";
                lblFridayVacancys.Foreground = new SolidColorBrush(Colors.LightGray);
            }
            else
            {
                lblFridayVacancys.Content = dao.VacancyCount("sexta");
                lblFridayVacancys.Foreground = new SolidColorBrush(Colors.Red);
            }

            if (dao.VacancyCount("sábado") == 0)
            {
                lblSaturdayVacancys.Content = "Não há vagas";
                lblSaturdayVacancys.Foreground = new SolidColorBrush(Colors.LightGray);
            }
            else
            {
                lblSaturdayVacancys.Content = dao.VacancyCount("sábado");
                lblSaturdayVacancys.Foreground = new SolidColorBrush(Colors.Red);
            }

        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            ACTLogin login = new ACTLogin();
            login.Show();
            this.Close();
        }

        private void btnCRUD_class_Click(object sender, RoutedEventArgs e)
        {
            CRUD_class crud_class = new CRUD_class();
            crud_class.ShowDialog();
            LoadIndex();
        }

        private void btnCRUD_student_Click(object sender, RoutedEventArgs e)
        {
            CRUD_student crud_student = new CRUD_student();
            crud_student.ShowDialog();
            LoadIndex();
        }

        private void btnCRUD_user_Click(object sender, RoutedEventArgs e)
        {
            CRUD_user crud_user = new CRUD_user();
            crud_user.ShowDialog();
            LoadIndex();
        }

        public void LoadTable(int id)
        {
            DAOStudents dao = new DAOStudents();

            //loads the table.
            tblStudents.CanUserAddRows = false;
            tblStudents.IsReadOnly = true;
            tblStudents.AutoGenerateColumns = false;
            tblStudents.ItemsSource = dao.LoadStudents(id);
            lblCount.Content = tblStudents.Items.Count;

            if(_class.Class_vacancys == 0)
            {
                tblStudents.ItemsSource = null;
                lblCount_Vacancy.Content = "0";
                lblCount.Content = "10";
                lblNoVancacys.Visibility = Visibility.Visible;
            }else
            {
                int i = tblStudents.Items.Count;
                lblCount_Vacancy.Content = _class.Class_vacancys;
                lblNoVancacys.Visibility = Visibility.Hidden;
            }
        }

        public void UnloadTable()
        {
            lblCount.Content = "0";
            lblCount_Vacancy.Content = "0";
            lblTeacher_Name.Content = "";
            lblClass_Time.Content = "";

            lblDay.Content = "";
            lblDay.Visibility = Visibility.Hidden;
            btnResetTable.Visibility = Visibility.Hidden;
            btnViewCurrentClass.Visibility = Visibility.Hidden;
            lblNoVancacys.Visibility = Visibility.Hidden;

            //loads the table.
            tblStudents.CanUserAddRows = false;
            tblStudents.IsReadOnly = true;
            tblStudents.AutoGenerateColumns = false;
            tblStudents.ItemsSource = null;
        }

        private void btnMondayVacancys_Click(object sender, RoutedEventArgs e)
        {
            DAOClass dao = new DAOClass();
            if(dao.VacancyCount("segunda") == 0)
            {
                Xceed.Wpf.Toolkit.MessageBox.Show("Não há vagas disponíveis.", "MC Sales", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
                tblStudents.ItemsSource = null;
                lblCount_Vacancy.Content = "0";
                lblCount.Content = "10";
                lblNoVancacys.Visibility = Visibility.Visible;
            }
            else
            {
                //class info.
                _class = dao.LoadQuickMenu("segunda");
                lblClass_Time.Content = _class.Class_TotalHours;

                //teacher info.
                TOUser u = new TOUser();
                DAOUser daoU = new DAOUser();
                u = daoU.Selection(_class.User_id);
                lblTeacher_Name.Content = u.User_name;

                btnViewCurrentClass.Visibility = Visibility.Visible;
                btnResetTable.Visibility = Visibility.Visible;

                LoadTable(_class.Class_id);

                lblDay.Visibility = Visibility.Visible;
                lblDay.Content = "Segunda-Feira";
            }
        }

        private void btnTuesdayVacancys_Click(object sender, RoutedEventArgs e)
        {
            DAOClass dao = new DAOClass();
            if (dao.VacancyCount("terça") == 0)
            {
                Xceed.Wpf.Toolkit.MessageBox.Show("Não há vagas disponíveis.", "MC Sales", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
                tblStudents.ItemsSource = null;
                lblCount_Vacancy.Content = "0";
                lblCount.Content = "10";
                lblNoVancacys.Visibility = Visibility.Visible;
            }
            else
            {
                //class info.
                _class = dao.LoadQuickMenu("terça");
                lblClass_Time.Content = _class.Class_TotalHours;

                //teacher info.
                TOUser u = new TOUser();
                DAOUser daoU = new DAOUser();
                u = daoU.Selection(_class.User_id);
                lblTeacher_Name.Content = u.User_name;

                btnViewCurrentClass.Visibility = Visibility.Visible;
                btnResetTable.Visibility = Visibility.Visible;

                LoadTable(_class.Class_id);

                lblDay.Visibility = Visibility.Visible;
                lblDay.Content = "Terça-Feira";
            }
        }

        private void btnWednesdayVavancys_Click(object sender, RoutedEventArgs e)
        {
            DAOClass dao = new DAOClass();
            if (dao.VacancyCount("quarta") == 0)
            {
                Xceed.Wpf.Toolkit.MessageBox.Show("Não há vagas disponíveis.", "MC Sales", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
                tblStudents.ItemsSource = null;
                lblCount_Vacancy.Content = "0";
                lblCount.Content = "10";
                lblNoVancacys.Visibility = Visibility.Visible;
            }
            else
            {
                //class info.
                _class = dao.LoadQuickMenu("quarta");
                lblClass_Time.Content = _class.Class_TotalHours;

                //teacher info.
                TOUser u = new TOUser();
                DAOUser daoU = new DAOUser();
                u = daoU.Selection(_class.User_id);
                lblTeacher_Name.Content = u.User_name;

                btnViewCurrentClass.Visibility = Visibility.Visible;
                btnResetTable.Visibility = Visibility.Visible;

                LoadTable(_class.Class_id);

                lblDay.Visibility = Visibility.Visible;
                lblDay.Content = "Quarta-Feira";
            }
        }

        private void btnThursdayVacancys_Click(object sender, RoutedEventArgs e)
        {
            DAOClass dao = new DAOClass();
            if (dao.VacancyCount("quinta") == 0)
            {
                Xceed.Wpf.Toolkit.MessageBox.Show("Não há vagas disponíveis.", "MC Sales", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
                tblStudents.ItemsSource = null;
                lblCount_Vacancy.Content = "0";
                lblCount.Content = "10";
                lblNoVancacys.Visibility = Visibility.Visible;
            }
            else
            {
                //class info.
                _class = dao.LoadQuickMenu("quinta");
                lblClass_Time.Content = _class.Class_TotalHours;

                //teacher info.
                TOUser u = new TOUser();
                DAOUser daoU = new DAOUser();
                u = daoU.Selection(_class.User_id);
                lblTeacher_Name.Content = u.User_name;

                btnViewCurrentClass.Visibility = Visibility.Visible;
                btnResetTable.Visibility = Visibility.Visible;

                LoadTable(_class.Class_id);

                lblDay.Visibility = Visibility.Visible;
                lblDay.Content = "Quinta-Feira";
            }
        }

        private void btnFridayVacancys_Click(object sender, RoutedEventArgs e)
        {
            DAOClass dao = new DAOClass();
            if (dao.VacancyCount("sexta") == 0)
            {
                Xceed.Wpf.Toolkit.MessageBox.Show("Não há vagas disponíveis.", "MC Sales", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
                tblStudents.ItemsSource = null;
                lblCount_Vacancy.Content = "0";
                lblCount.Content = "10";
                lblNoVancacys.Visibility = Visibility.Visible;
            }
            else
            {
                //class info.
                _class = dao.LoadQuickMenu("sexta");
                lblClass_Time.Content = _class.Class_TotalHours;

                //teacher info.
                TOUser u = new TOUser();
                DAOUser daoU = new DAOUser();
                u = daoU.Selection(_class.User_id);
                lblTeacher_Name.Content = u.User_name;

                btnViewCurrentClass.Visibility = Visibility.Visible;
                btnResetTable.Visibility = Visibility.Visible;

                LoadTable(_class.Class_id);

                lblDay.Visibility = Visibility.Visible;
                lblDay.Content = "Sexta-Feira";
            }
        }

        private void btnSaturdayVacancys_Click(object sender, RoutedEventArgs e)
        {
            DAOClass dao = new DAOClass();
            if (dao.VacancyCount("sábado") == 0)
            {
                Xceed.Wpf.Toolkit.MessageBox.Show("Não há vagas disponíveis.", "MC Sales", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
                tblStudents.ItemsSource = null;
                lblCount_Vacancy.Content = "0";
                lblCount.Content = "10";
                lblNoVancacys.Visibility = Visibility.Visible;
            }
            else
            {
                //class info.
                _class = dao.LoadQuickMenu("sábado");
                lblClass_Time.Content = _class.Class_TotalHours;

                //teacher info.
                TOUser u = new TOUser();
                DAOUser daoU = new DAOUser();
                u = daoU.Selection(_class.User_id);
                lblTeacher_Name.Content = u.User_name;

                btnViewCurrentClass.Visibility = Visibility.Visible;
                btnResetTable.Visibility = Visibility.Visible;

                LoadTable(_class.Class_id);

                lblDay.Visibility = Visibility.Visible;
                lblDay.Content = "Sábado";
            }
        }

        private void btnViewCurrentClass_Click(object sender, RoutedEventArgs e)
        {
            REG_student _reg = new REG_student(_class.Class_id);
            _reg.ShowDialog();
            LoadIndex();
        }

        private void btnResetTable_Click(object sender, RoutedEventArgs e)
        {
            UnloadTable();
        }
    }
}
