using MCSales.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.Wpf.Toolkit;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MCSales.Model.DAO;
using System.Data;

namespace MCSales.View.Registration
{

    public partial class REG_Class : Window
    {

        TOClass to_class = new TOClass();
        DAOUser dao_user = new DAOUser();
        int op = 0;

        public REG_Class()
        {
            InitializeComponent();
            lblDaysOfWeek.Content = "";
            cbxTeacher.ItemsSource = LoadTeachers();
        }

        public REG_Class(int id)
        {
            op = 1;

            InitializeComponent();
            cbxTeacher.ItemsSource = LoadTeachers();

            DAOClass d = new DAOClass();
            to_class = d.Selection(id);

            _numDuration.Text = to_class.Class_duration.ToString();
            _numClass.Text = to_class.Class_timePerWeek.ToString();
            _pickerStarts.Text = to_class.Class_hourStarts.ToString();
            _pickerEnds.Text = to_class.Class_hourEnds.ToString();


            //setting type comboBox.
            if (to_class.Type == "Inglês")
            {
               cbxType.SelectedIndex = 0;
            }
            else if (to_class.Type == "Interativo")
            {
                cbxType.SelectedIndex = 1;
            }else if(to_class.Type == "Hardware")
            {
                cbxType.SelectedIndex = 2;
            }
            else if(to_class.Type == "Games")
            {
                cbxType.SelectedIndex = 3;
            }
            else if(to_class.Type == "Informática")
            {
                cbxType.SelectedIndex = 4;
            }
            else if(to_class.Type == "Administração")
            {
                cbxType.SelectedIndex = 5;
            }

            //setting day comboBox.
            if(to_class.Class_day == "Segunda")
            {
                cbxDate.SelectedIndex = 0;
            }else if(to_class.Class_day == "Terça")
            {
                cbxDate.SelectedIndex = 1;
            }
            else if(to_class.Class_day == "Quarta")
            {
                cbxDate.SelectedIndex = 2;
            }
            else if(to_class.Class_day == "Quinta")
            {
                cbxDate.SelectedIndex = 3;
            }
            else if(to_class.Class_day == "Sexta")
            {
                cbxDate.SelectedIndex = 4;
            }
            else if(to_class.Class_day == "Sábado")
            {
                cbxDate.SelectedIndex = 5;
            }
            else if(to_class.Class_day == "Segunda e Quarta")
            {
                cbxDate.SelectedIndex = 6;
            }
            else if(to_class.Class_day == "Terça e Quinta")
            {
                cbxDate.SelectedIndex = 7;
            }

            lblDaysOfWeek.Content = cbxDate.SelectedValue;

            cbxTeacher.SelectedItem = to_class.Teacher_name;

            cbxDate.IsEnabled = false;
            cbxTeacher.IsEnabled = false;
            cbxType.IsEnabled = false;
            _numDuration.IsEnabled = false;
            _numClass.IsEnabled = false;
            _pickerStarts.IsEnabled = false;
            _pickerEnds.IsEnabled = false;

            btnRegisterClass.Content = "Editar";
            btnCancel.IsEnabled = false;
        }

        public string TableValues(int i, DataGrid dt)
        {
            try
            {
                DataGridCellInfo cellInfo = dt.SelectedCells[i];
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

        public List<string> LoadTeachers()
        {

            List<TOUser> i = new List<TOUser>(); List<string> stg = new List<string>();
            i = dao_user.LoadTeachers();

            foreach (TOUser u in i)
            {
                stg.Add(u.User_name); 
            }

            return stg;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void _numClass_LostFocus(object sender, RoutedEventArgs e)
        {          

            if (_numClass.Value >= 2)
            {
                _segunda.Visibility = Visibility.Collapsed;
                _terca.Visibility = Visibility.Collapsed;
                _quarta.Visibility = Visibility.Collapsed;
                _quinta.Visibility = Visibility.Collapsed;
                _sexta.Visibility = Visibility.Collapsed;
                _sabado.Visibility = Visibility.Collapsed;

                _segundaQuarta.Visibility = Visibility.Visible;
                _terçaQuinta.Visibility = Visibility.Visible;
            }
            else
            {
                _segunda.Visibility = Visibility.Visible;
                _terca.Visibility = Visibility.Visible;
                _quarta.Visibility = Visibility.Visible;
                _quinta.Visibility = Visibility.Visible;
                _sexta.Visibility = Visibility.Visible;
                _sabado.Visibility = Visibility.Visible;

                _segundaQuarta.Visibility = Visibility.Collapsed;
                _terçaQuinta.Visibility = Visibility.Collapsed;
            }
        }

        private void cbxTeacher_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {           
            List<TOUser> i = dao_user.LoadTeachers();

            foreach (TOUser u in i )
            {
                if(u.User_name == cbxTeacher.SelectedItem.ToString())
                {
                    to_class.User_id = u.User_id;
                }
            }
        }

        private void btnRegisterClass_Click(object sender, RoutedEventArgs e)
        {
            if(op == 1)
            {
                cbxDate.IsEnabled = true;
                cbxTeacher.IsEnabled = true;
                cbxType.IsEnabled = true;
                _numDuration.IsEnabled = true;
                _numClass.IsEnabled = true;
                _pickerStarts.IsEnabled = true;
                _pickerEnds.IsEnabled = true;
                btnRegisterClass.Content = "Atualizar";
                btnRegisterClass.IsEnabled = true;
                btnCancel.IsEnabled = true;
                op = 2;
            }else if(op == 2)
            {
                    if (_numDuration.Value == 2 && _numClass.Value == 2)
                    {
                        Xceed.Wpf.Toolkit.MessageBox.Show("O número máximo de aulas por semana para aulas de duas horas é 1 vez por semana.. Por favor, verifique."
                        , "Aviso!", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                    }
                    else if (_numDuration.Value == 1 && _numClass.Value == 1)
                    {
                        Xceed.Wpf.Toolkit.MessageBox.Show("O número mínimo de aulas por semana para aulas de uma hora é 2 vezes por semana. Por favor, verifique."
                        , "Aviso!", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                    }
                    else if (_numClass.Value == 2 && (to_class.Class_day == "Segunda" || to_class.Class_day == "Terça" || to_class.Class_day == "Quarta"
                      || to_class.Class_day == "Quinta" || to_class.Class_day == "Sexta" || to_class.Class_day == "Sábado"))
                    {
                        System.Windows.MessageBox.Show(to_class.Class_day);
                        System.Windows.MessageBox.Show(_numClass.Value.ToString());
                        Xceed.Wpf.Toolkit.MessageBox.Show("Você marcou dois dias de aula e selcionou apenas " + cbxDate.SelectedValue.ToString() + " . Por favor, verifique."
                        , "Aviso!", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                    }
                    else if (_numClass.Value == 1 && (to_class.Class_day == "Segunda e Quarta" || to_class.Class_day == "Terça e Quinta"))
                    {
                        Xceed.Wpf.Toolkit.MessageBox.Show("Você marcou dois dias de aula e selcionou apenas " + cbxDate.SelectedValue.ToString() + " . Por favor, verifique."
                        , "Aviso!", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                    }
                    else if (Convert.ToInt16(_numDuration.Value) == 2 && ClassDuration() < 2)
                    {
                        Xceed.Wpf.Toolkit.MessageBox.Show("Você marcou menos de duas horas de aula. Por favor, selecione um horário válido."
                        , "Aviso!", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                    }
                    else if (Convert.ToInt16(_numDuration.Value) == 1 && ClassDuration() > 1)
                    {
                        Xceed.Wpf.Toolkit.MessageBox.Show("Você marcou mais de uma hora de aula. Por favor, selecione um horário válido."
                        , "Aviso!", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                    }
                    else
                    {
                        to_class.Class_day = cbxDate.Text;
                        to_class.Class_duration = Convert.ToInt16(_numDuration.Value);
                        to_class.Class_timePerWeek = Convert.ToInt16(_numDuration.Value);

                        to_class.Class_hourStarts = _pickerStarts.Text;
                        to_class.Class_hourEnds = _pickerEnds.Text;
                        to_class.Class_vacancys = 10;

                        DAOClass _class = new DAOClass();
                        if (_class.Update(to_class))
                        {
                            Xceed.Wpf.Toolkit.MessageBox.Show("Aula atualizada com sucesso!"
                            , "Sucesso!", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
                            this.Close();
                        }
                        else
                        {
                        Xceed.Wpf.Toolkit.MessageBox.Show("Algo errado aconteceu durante a atualização."
                        , "Erro!", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                        }

                }
            }
            else if(op ==0)
            {
                if (_numDuration.Value == 2 && _numClass.Value == 2)
                {
                    Xceed.Wpf.Toolkit.MessageBox.Show("O número máximo de aulas por semana para aulas de duas horas é 1 vez por semana.. Por favor, verifique."
                    , "Aviso!", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                }
                else if (_numDuration.Value == 1 && _numClass.Value == 1)
                {
                    Xceed.Wpf.Toolkit.MessageBox.Show("O número mínimo de aulas por semana para aulas de uma hora é 2 vezes por semana. Por favor, verifique."
                    , "Aviso!", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                }
                else if (_numClass.Value == 2 && (to_class.Class_day == "Segunda" || to_class.Class_day == "Terça" || to_class.Class_day == "Quarta"
                  || to_class.Class_day == "Quinta" || to_class.Class_day == "Sexta" || to_class.Class_day == "Sábado"))
                {
                    System.Windows.MessageBox.Show(to_class.Class_day);
                    System.Windows.MessageBox.Show(_numClass.Value.ToString());
                    Xceed.Wpf.Toolkit.MessageBox.Show("Você marcou dois dias de aula e selcionou apenas " + cbxDate.SelectedValue.ToString() + " . Por favor, verifique."
                    , "Aviso!", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                }
                else if (_numClass.Value == 1 && (to_class.Class_day == "Segunda e Quarta" || to_class.Class_day == "Terça e Quinta"))
                {
                    Xceed.Wpf.Toolkit.MessageBox.Show("Você marcou dois dias de aula e selcionou apenas " + cbxDate.SelectedValue.ToString() + " . Por favor, verifique."
                    , "Aviso!", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                }
                else if (Convert.ToInt16(_numDuration.Value) == 2 && ClassDuration() < 2)
                {
                    Xceed.Wpf.Toolkit.MessageBox.Show("Você marcou menos de duas horas de aula. Por favor, selecione um horário válido."
                    , "Aviso!", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                }
                else if (Convert.ToInt16(_numDuration.Value) == 1 && ClassDuration() > 1)
                {
                    Xceed.Wpf.Toolkit.MessageBox.Show("Você marcou mais de uma hora de aula. Por favor, selecione um horário válido."
                    , "Aviso!", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                }
                else
                {
                        to_class.Class_day = cbxDate.Text;
                        to_class.Class_duration = Convert.ToInt16(_numDuration.Value);
                        to_class.Class_timePerWeek = Convert.ToInt16(_numDuration.Value);

                        to_class.Class_hourStarts = _pickerStarts.Text;
                        to_class.Class_hourEnds = _pickerEnds.Text;
                        to_class.Class_vacancys = 10;

                        DAOClass _class = new DAOClass();
                        if (_class.Registration(to_class))
                        {
                            Xceed.Wpf.Toolkit.MessageBox.Show("Aula cadastrada com sucesso!"
                            , "Sucesso!", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
                            this.Close();
                        }
                        else
                        {
                            Xceed.Wpf.Toolkit.MessageBox.Show("Algo errado aconteceu durante o cadastro."
                            , "Erro!", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                        }
                }
            }

            

        }

        public int ClassDuration()
        {

            var start = DateTime.Parse(_pickerStarts.Text);
            var end = DateTime.Parse(_pickerEnds.Text);

            var result = end - start;
            var resultInHours = result.TotalHours;

            return Int16.Parse(resultInHours.ToString());

        }

        private void cbxDate_DropDownClosed(object sender, EventArgs e)
        {
            lblDaysOfWeek.Content = (cbxDate.SelectedValue.ToString());
        }

        private void _segunda_Selected(object sender, RoutedEventArgs e)
        {
            to_class.Class_day = "Segunda";
        }

        private void _terca_Selected(object sender, RoutedEventArgs e)
        {
            to_class.Class_day = "Terça";
        }

        private void _quarta_Selected(object sender, RoutedEventArgs e)
        {
            to_class.Class_day = "Quarta";
        }

        private void _quinta_Selected(object sender, RoutedEventArgs e)
        {
            to_class.Class_day = "Quinta";
        }

        private void _sexta_Selected(object sender, RoutedEventArgs e)
        {
            to_class.Class_day = "Sexta";
        }

        private void _sabado_Selected(object sender, RoutedEventArgs e)
        {
            to_class.Class_day = "Sábado";
        }

        private void _segundaQuarta_Selected(object sender, RoutedEventArgs e)
        {
            to_class.Class_day = "Segunda e Quarta";
        }

        private void _terçaQuinta_Selected(object sender, RoutedEventArgs e)
        {
            to_class.Class_day = "Terça e Quinta";
        }

        private void _ingles_Selected(object sender, RoutedEventArgs e)
        {
            to_class.Type = "Inglês";
        }

        private void _interativo_Selected(object sender, RoutedEventArgs e)
        {
            to_class.Type = "Interativo";
        }

        private void _hardware_Selected(object sender, RoutedEventArgs e)
        {
            to_class.Type = "Hardware";
        }

        private void _games_Selected(object sender, RoutedEventArgs e)
        {
            to_class.Type = "Games";
        }

        private void _informatica_Selected(object sender, RoutedEventArgs e)
        {
            to_class.Type = "Informática";
        }

        private void _adm_Selected(object sender, RoutedEventArgs e)
        {
            to_class.Type = "Administração";
        }
    }
}
