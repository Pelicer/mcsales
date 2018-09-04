using MCSales.Model;
using MCSales.Model.DAO;
using MCSales.Model.TO;
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
    public partial class REG_student : Window
    {
        TOStudent _student = new TOStudent();
        TOResponsable _resp = new TOResponsable();

        int op = 0;

        public REG_student()
        {
            InitializeComponent();
            op = 0;
        }

        public REG_student(int classID)
        {
            InitializeComponent();
            op = 0;

            //loads the table.
            DAOClass _class = new DAOClass();
            tblClass.CanUserAddRows = false;
            tblClass.IsReadOnly = true;
            tblClass.AutoGenerateColumns = false;
            List<TOClass> c = new List<TOClass>();
            c = _class.LoadClass(classID);

            _student.Class_id = classID;

            foreach (TOClass _c in c)
            {
                if (_c.Type == "Hardware")
                {
                    rdbtn_hard.IsChecked = true;
                }
                else if (_c.Type == "Informática")
                {
                    rdbtn_info.IsChecked = true;
                }
                else if (_c.Type == "Inglês")
                {
                    rdbtn_en.IsChecked = true;
                }
                else if (_c.Type == "Administração")
                {
                    rdbtn_adm.IsChecked = true;
                }
                else if (_c.Type == "Interativo")
                {
                    rdbtn_int.IsChecked = true;
                }
                else if (_c.Type == "Game")
                {
                    rdbtn_game.IsChecked = true;
                }
            }

            tblClass.ItemsSource = _class.LoadClass(classID);
        }

        public REG_student(TOStudent student)
        {
            InitializeComponent();

            op = 1;
            btnRegisterStudent.Content = "Editar";

            _student = student;
            txtName.Text = _student.Student_name;
            txtRG.Text = _student.Student_rg;
            txtCPF.Text = _student.Student_cpf;

            if(_student.Student_birthDate != String.Empty)
            {
                birthDate.SelectedDate = DateTime.Parse(_student.Student_birthDate);
            }else
            {

            }

            txtPhone.Text = _student.Student_phone;
            txtWhatsApp.Text = _student.Student_whatsApp;
            txtCEP.Text = _student.Student_cep;
            txtState.Text = _student.Student_state;
            txtCity.Text = _student.Student_city;
            txtBlock.Text = _student.Student_block;
            txtNumber.Text = _student.Student_number;
            txtAdd.Text = _student.Student_obs;
            txtCtr.Text = _student.Student_ctr;
            txtStreet.Text = _student.Student_street;

            if(_student.Student_sex == "Feminino")
            {
                cbxSex.SelectedIndex = 0;
            }else if(_student.Student_sex == "Masculino")
            {
                cbxSex.SelectedIndex = 1;
            }

            DateTime _birth = DateTime.Parse(_student.Student_birthDate);
            int age = (int)Math.Floor((DateTime.Now - _birth).TotalDays / 365.25D);

            if(age >= 18)
            {
                _resp = null;
            }else
            {
                DAOStudents dao = new DAOStudents();
                TOResponsable r = new TOResponsable();

                r = dao.SelectResp(_student.Resp_id);
                _resp = r;

                txtName_resp.Text = r.Resp_name;
                txtRG_resp.Text = r.Resp_rg;
                txtCPF_resp.Text = r.Resp_cpf;

                if (r.Resp_birthDate != String.Empty)
                {
                    birthDate_resp.SelectedDate = DateTime.Parse(r.Resp_birthDate);
                }
                else
                {

                }

                if (_resp.Resp_cep == _student.Student_cep && _resp.Resp_number == _student.Student_number
                    || _resp.Resp_street == _student.Student_street && _resp.Resp_number == _student.Student_number)
                {
                    checkBox_sameAdress.IsChecked = true;
                }
                else
                {
                    checkBox_sameAdress.IsChecked = false;
                }

                txtPhone_resp.Text = r.Resp_phone;
                txtWhatsApp_resp.Text = r.Resp_whatsApp;
                txtCEP_resp.Text = r.Resp_cep;
                txtState_resp.Text = r.Resp_state;
                txtCity_resp.Text = r.Resp_city;
                txtBlock_resp.Text = r.Resp_block;
                txtNumber_resp.Text = r.Resp_number;
                txtAdd_resp.Text = r.Resp_obs;
                txtStreet_resp.Text = r.Resp_street;

                if (r.Resp_sex == "Feminino")
                {
                    cbxSex_resp.SelectedIndex = 0;
                }
                else if (r.Resp_sex == "Masculino")
                {
                    cbxSex_resp.SelectedIndex = 1;
                }                
            }

            //loads the table.
            DAOClass _class = new DAOClass();
            tblClass.CanUserAddRows = false;
            tblClass.IsReadOnly = true;
            tblClass.AutoGenerateColumns = false;
            List<TOClass> c = new List<TOClass>();
            c = _class.LoadClass(_student.Class_id);

            foreach (TOClass _c in c)
            {
                if (_c.Type == "Hardware")
                {
                    rdbtn_hard.IsChecked = true;
                }
                else if (_c.Type == "Informática")
                {
                    rdbtn_info.IsChecked = true;
                }
                else if (_c.Type == "Inglês")
                {
                    rdbtn_en.IsChecked = true;
                }
                else if (_c.Type == "Administração")
                {
                    rdbtn_adm.IsChecked = true;
                }
                else if (_c.Type == "Interativo")
                {
                    rdbtn_int.IsChecked = true;
                }
                else if (_c.Type == "Game")
                {
                    rdbtn_game.IsChecked = true;
                }
            }

            tblClass.ItemsSource = _class.LoadClass(_student.Class_id);
            tabClass_Grid.IsEnabled = false;
            tabStudent_Grid.IsEnabled = false;
            tabParent_Grid.IsEnabled = false;
            txtCtr.IsEnabled = false;
        }


        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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
                Xceed.Wpf.Toolkit.MessageBox.Show("Por favor, selecione uma aula.", "Aviso!", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK);
            }

            return null;

        }

        public void LoadScreen()
        {
            DAOClass _class = new DAOClass();
            TOClass c = new TOClass();

            if(rdbtn_en.IsChecked == true)
            {
                c.Type = "Inglês";
                tblClass.ItemsSource = _class.LoadClasses(c.Type);
            }
            else if(rdbtn_adm.IsChecked == true)
            {
                c.Type = "Administração";
                tblClass.ItemsSource = _class.LoadClasses(c.Type);
            }else if(rdbtn_game.IsChecked == true)
            {
                c.Type = "Game";
                tblClass.ItemsSource = _class.LoadClasses(c.Type);
            }else if(rdbtn_hard.IsChecked == true)
            {
                c.Type = "Hardware";
                tblClass.ItemsSource = _class.LoadClasses(c.Type);
            }else if(rdbtn_info.IsChecked == true)
            {
                c.Type = "Informática";
                tblClass.ItemsSource = _class.LoadClasses(c.Type);
            }else if(rdbtn_int.IsChecked == true)
            {
                c.Type = "Interativo";
                tblClass.ItemsSource = _class.LoadClasses(c.Type);
            }
            else if(rdbtn_all.IsChecked == true)
            {
                tblClass.ItemsSource = _class.LoadClasses();
            }

            //loads the table.
            tblClass.CanUserAddRows = false;
            tblClass.IsReadOnly = true;
            tblClass.AutoGenerateColumns = false;
        }



        private void txtCEP_LostFocus(object sender, RoutedEventArgs e)
        {
            CEP cep = new CEP();

            if(cep.BuscarEndereco(txtCEP.Text.ToString(), 5) == "CEP não  encontrado"){
                Xceed.Wpf.Toolkit.MessageBox.Show("CEP inválido. Por favor, verifique.", "CEP inválido!", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                txtCEP.Text = "";
            }else
            {

            }

            txtState.Text = cep.BuscarEndereco(txtCEP.Text.ToString(), 0);
            txtCity.Text = cep.BuscarEndereco(txtCEP.Text.ToString(), 1);
            txtBlock.Text = cep.BuscarEndereco(txtCEP.Text.ToString(), 2);
            txtStreet.Text = cep.BuscarEndereco(txtCEP.Text.ToString(), 4);

        }

        private void checkBox_sameAdress_Checked(object sender, RoutedEventArgs e)
        {
            if(txtCEP.Text == "" || txtState.Text == "" || txtCity.Text == "" || txtBlock.Text == "" || txtStreet.Text == "" || txtNumber.Text == "")
            {
                Xceed.Wpf.Toolkit.MessageBox.Show("Todos os campos de endereço do aluno precisam estar preenchidos para ativar esta opção."
                , "Aviso!", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK);
            }else
            {
                txtCEP_resp.Text = txtCEP.Text;
                txtCity_resp.Text = txtCity.Text;
                txtBlock_resp.Text = txtBlock.Text;
                txtState_resp.Text = txtState.Text;
                txtNumber_resp.Text = txtNumber.Text;
                txtStreet_resp.Text = txtStreet.Text;

                txtCEP_resp.IsEnabled = false;
                txtCity_resp.IsEnabled = false;
                txtBlock_resp.IsEnabled = false;
                txtState_resp.IsEnabled = false;
                txtNumber_resp.IsEnabled = false;
                txtStreet_resp.IsEnabled = false;
            }
        }

        private void checkBox_sameAdress_Unchecked(object sender, RoutedEventArgs e)
        {
            txtCEP_resp.IsEnabled = true;
            txtCity_resp.IsEnabled = true;
            txtBlock_resp.IsEnabled = true;
            txtState_resp.IsEnabled = true;
            txtNumber_resp.IsEnabled = true;
            txtStreet_resp.IsEnabled = true;
        }

        private void btnRegisterStudent_Click(object sender, RoutedEventArgs e)
        {
            if(btnRegisterStudent.Content.ToString() == "Editar")
            {
                btnRegisterStudent.Content = "Atualizar";
                tabClass_Grid.IsEnabled = true;
                tabStudent_Grid.IsEnabled = true;
                tabParent_Grid.IsEnabled = true;
                txtCtr.IsEnabled = true;

            }else
            {
                if (op == 0)
                {
                    if (txtCtr.Text.ToString() == String.Empty || txtName.Text.ToString() == String.Empty || _student.Student_birthDate == String.Empty)
                    {
                        Xceed.Wpf.Toolkit.MessageBox.Show("Campos obrigatórios não podem estar vazios", "Aviso!", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK);
                    }
                    else if (_student.Class_id != 0)
                    {
                        _student.Student_name = txtName.Text;
                        _student.Student_rg = txtRG.Text;
                        _student.Student_cpf = txtCPF.Text;
                        _student.Student_birthDate = birthDate.SelectedDate.ToString();
                        _student.Student_phone = txtPhone.Text;
                        _student.Student_whatsApp = txtWhatsApp.Text;
                        _student.Student_cep = txtCEP.Text;
                        _student.Student_state = txtState.Text;
                        _student.Student_city = txtCity.Text;
                        _student.Student_block = txtBlock.Text;
                        _student.Student_number = txtNumber.Text;
                        _student.Student_obs = txtAdd.Text;
                        _student.Student_ctr = txtCtr.Text;
                        _student.Student_subscriptionDate = DateTime.Now.ToString();

                        if (checkBox_permission.IsChecked == false && txtName_resp.Text.ToString() == String.Empty || txtRG_resp.Text.ToString() == String.Empty)
                        {
                            Xceed.Wpf.Toolkit.MessageBox.Show("Os campos de nome e RG do responsável são obrigatórios.", "Aviso!", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK);
                            tabParent.Focus();
                        }
                        else if (checkBox_permission.IsChecked == true)
                        {
                            _resp = null;

                            DAOStudents dao = new DAOStudents();
                            if (dao.CheckVacancys(_student.Class_id))
                            {
                                if (dao.CheckCTR(_student.Student_ctr))
                                {
                                    if (dao.Registration(_student, _resp))
                                    {
                                        Xceed.Wpf.Toolkit.MessageBox.Show("Aluno cadastrado com sucesso!", "Sucesso!", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
                                        this.Close();
                                    }
                                    else
                                    {
                                        Xceed.Wpf.Toolkit.MessageBox.Show("Algo de errado aconteceu durante o cadastro.", "Erro!", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                                    }
                                }
                                else
                                {
                                    Xceed.Wpf.Toolkit.MessageBox.Show("Já existe um aluno com este CTR.", "Erro!", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                                }
                            }
                            else
                            {
                                Xceed.Wpf.Toolkit.MessageBox.Show("Não existem mais vagas nesta turma. Por favor, tente outra.", "Erro!", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                            }
                        }
                        else
                        {
                            _student.Student_name = txtName.Text;
                            _student.Student_rg = txtRG.Text;
                            _student.Student_cpf = txtCPF.Text;
                            _student.Student_birthDate = birthDate.SelectedDate.ToString();
                            _student.Student_phone = txtPhone.Text;
                            _student.Student_whatsApp = txtWhatsApp.Text;
                            _student.Student_cep = txtCEP.Text;
                            _student.Student_state = txtState.Text;
                            _student.Student_street = txtStreet.Text;
                            _student.Student_city = txtCity.Text;
                            _student.Student_block = txtBlock.Text;
                            _student.Student_number = txtNumber.Text;
                            _student.Student_obs = txtAdd.Text;
                            _student.Student_ctr = txtCtr.Text;

                            _resp.Resp_name = txtName_resp.Text;
                            _resp.Resp_rg = txtRG_resp.Text;
                            _resp.Resp_cpf = txtCPF_resp.Text;
                            _resp.Resp_birthDate = birthDate_resp.SelectedDate.ToString();
                            _resp.Resp_phone = txtPhone_resp.Text;
                            _resp.Resp_whatsApp = txtWhatsApp_resp.Text;
                            _resp.Resp_cep = txtCEP_resp.Text;
                            _resp.Resp_state = txtState_resp.Text;
                            _resp.Resp_city = txtCity_resp.Text;
                            _resp.Resp_street = txtStreet_resp.Text;
                            _resp.Resp_block = txtBlock_resp.Text;
                            _resp.Resp_number = txtNumber_resp.Text;
                            _resp.Resp_obs = txtAdd_resp.Text;

                            DAOStudents dao = new DAOStudents();
                            if (dao.CheckVacancys(_student.Class_id))
                            {
                                if (dao.CheckCTR(_student.Student_ctr))
                                {
                                    if (dao.Registration(_student, _resp))
                                    {
                                        Xceed.Wpf.Toolkit.MessageBox.Show("Aluno cadastrado com sucesso!", "Sucesso!", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
                                        this.Close();
                                    }
                                    else
                                    {
                                        Xceed.Wpf.Toolkit.MessageBox.Show("Algo de errado aconteceu durante o cadastro.", "Erro!", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                                    }
                                }
                                else
                                {
                                    Xceed.Wpf.Toolkit.MessageBox.Show("Já existe um aluno com este CTR.", "Erro!", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                                }
                            }
                            else
                            {
                                Xceed.Wpf.Toolkit.MessageBox.Show("Não existem mais vagas nesta turma. Por favor, tente outra.", "Erro!", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                            }
                        }
                    }
                    else
                    {
                        Xceed.Wpf.Toolkit.MessageBox.Show("Por favor, selecione uma aula para o aluno.", "Aviso!", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK);
                        tabClass.Focus();
                    }
                }
                else
                {


                    if (txtCtr.Text.ToString() == String.Empty || txtName.Text.ToString() == String.Empty || _student.Student_birthDate == String.Empty)
                    {
                        Xceed.Wpf.Toolkit.MessageBox.Show("Campos obrigatórios não podem estar vazios", "Aviso!", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK);
                    }
                    else if (_student.Class_id != 0)
                    {
                        _student.Student_name = txtName.Text;
                        _student.Student_rg = txtRG.Text;
                        _student.Student_cpf = txtCPF.Text;
                        _student.Student_birthDate = birthDate.SelectedDate.ToString();
                        _student.Student_phone = txtPhone.Text;
                        _student.Student_whatsApp = txtWhatsApp.Text;
                        _student.Student_cep = txtCEP.Text;
                        _student.Student_state = txtState.Text;
                        _student.Student_city = txtCity.Text;
                        _student.Student_block = txtBlock.Text;
                        _student.Student_number = txtNumber.Text;
                        _student.Student_obs = txtAdd.Text;
                        _student.Student_ctr = txtCtr.Text;

                        if (checkBox_permission.IsChecked == false && txtName_resp.Text.ToString() == String.Empty || txtRG_resp.Text.ToString() == String.Empty)
                        {
                            Xceed.Wpf.Toolkit.MessageBox.Show("Os campos de nome e RG do responsável são obrigatórios.", "Aviso!", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK);
                            tabParent.Focus();
                        }
                        else if (checkBox_permission.IsChecked == true)
                        {
                            _resp = null;

                            DAOStudents dao = new DAOStudents();
                            if (dao.CheckVacancys(_student.Class_id))
                            {
                                    if (dao.Update(_student, _resp))
                                    {
                                        Xceed.Wpf.Toolkit.MessageBox.Show("Aluno atualizado com sucesso!", "Sucesso!", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
                                        this.Close();
                                    }
                                    else
                                    {
                                        Xceed.Wpf.Toolkit.MessageBox.Show("Algo de errado aconteceu durante o cadastro.", "Erro!", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                                    }
                            }
                            else
                            {
                                Xceed.Wpf.Toolkit.MessageBox.Show("Não existem mais vagas nesta turma. Por favor, tente outra.", "Erro!", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                            }
                        }
                        else
                        {
                            _student.Student_name = txtName.Text;
                            _student.Student_rg = txtRG.Text;
                            _student.Student_cpf = txtCPF.Text;
                            _student.Student_birthDate = birthDate.SelectedDate.ToString();
                            _student.Student_phone = txtPhone.Text;
                            _student.Student_whatsApp = txtWhatsApp.Text;
                            _student.Student_cep = txtCEP.Text;
                            _student.Student_state = txtState.Text;
                            _student.Student_street = txtStreet.Text;
                            _student.Student_city = txtCity.Text;
                            _student.Student_block = txtBlock.Text;
                            _student.Student_number = txtNumber.Text;
                            _student.Student_obs = txtAdd.Text;
                            _student.Student_ctr = txtCtr.Text;
                            _student.Student_subscriptionDate = DateTime.Now.ToString();

                            _resp.Resp_name = txtName_resp.Text;
                            _resp.Resp_rg = txtRG_resp.Text;
                            _resp.Resp_cpf = txtCPF_resp.Text;
                            _resp.Resp_birthDate = birthDate_resp.SelectedDate.ToString();
                            _resp.Resp_phone = txtPhone_resp.Text;
                            _resp.Resp_whatsApp = txtWhatsApp_resp.Text;
                            _resp.Resp_cep = txtCEP_resp.Text;
                            _resp.Resp_state = txtState_resp.Text;
                            _resp.Resp_city = txtCity_resp.Text;
                            _resp.Resp_street = txtStreet_resp.Text;
                            _resp.Resp_block = txtBlock_resp.Text;
                            _resp.Resp_number = txtNumber_resp.Text;
                            _resp.Resp_obs = txtAdd_resp.Text;

                            DAOStudents dao = new DAOStudents();
                            if (dao.CheckVacancys(_student.Class_id))
                            {
                                    if (dao.Update(_student, _resp))
                                    {
                                        Xceed.Wpf.Toolkit.MessageBox.Show("Aluno atualizado com sucesso!", "Sucesso!", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
                                        this.Close();
                                    }
                                    else
                                    {
                                        Xceed.Wpf.Toolkit.MessageBox.Show("Algo de errado aconteceu durante o cadastro.", "Erro!", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                                    }
                            }
                            else
                            {
                                Xceed.Wpf.Toolkit.MessageBox.Show("Não existem mais vagas nesta turma. Por favor, tente outra.", "Erro!", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                            }
                        }
                    }
                }
            }

        }

        private void txtCEP_resp_LostFocus(object sender, RoutedEventArgs e)
        {
            CEP cep = new CEP();

            if (cep.BuscarEndereco(txtCEP_resp.Text.ToString(), 5) == "CEP não  encontrado")
            {
                Xceed.Wpf.Toolkit.MessageBox.Show("CEP inválido. Por favor, verifique.", "CEP inválido!", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                txtCEP.Text = "";
            }
            else
            {

            }

            txtState_resp.Text = cep.BuscarEndereco(txtCEP_resp.Text.ToString(), 0);
            txtCity_resp.Text = cep.BuscarEndereco(txtCEP_resp.Text.ToString(), 1);
            txtBlock_resp.Text = cep.BuscarEndereco(txtCEP_resp.Text.ToString(), 2);
            txtStreet_resp.Text = cep.BuscarEndereco(txtCEP_resp.Text.ToString(), 4);
        }

        private void rdbtn_checked(object sender, RoutedEventArgs e)
        {
            LoadScreen();
        }

        private void tblClass_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (TableValues(0) != null)
            {
                _student.Class_id = Int16.Parse(TableValues(0));
                Xceed.Wpf.Toolkit.MessageBox.Show("Aula selecionada com sucesso.", "Sucesso!", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);

            }
        }

        private void checkBox_permission_Unchecked(object sender, RoutedEventArgs e)
        {
            tabParent_Grid.IsEnabled = true;
        }

        private void Feminino_Selected(object sender, RoutedEventArgs e)
        {
            _student.Student_sex = "Feminino";
        }

        private void Masculino_Selected(object sender, RoutedEventArgs e)
        {
            _student.Student_sex = "Masculino";
        }

        private void Feminino_resp_Selected(object sender, RoutedEventArgs e)
        {
            _resp.Resp_sex = "Feminino";
        }

        private void Masculino_resp_Selected(object sender, RoutedEventArgs e)
        {
            _resp.Resp_sex = "Masculino";
        }

        private void birthDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            int age = 0;

            DateTime _birth = DateTime.Parse(birthDate.SelectedDate.ToString());
            age = (int)Math.Floor((DateTime.Now - _birth).TotalDays / 365.25D);

            _student.Student_birthDate = birthDate.SelectedDate.ToString();

            if (age < 18)
            {
                tabParent_Grid.IsEnabled = true;
            }
            else
            {
                tabParent_Grid.IsEnabled = false;
                checkBox_permission.IsChecked = true;

                txtName_resp.Text = txtName.Text;
                txtCPF_resp.Text = txtCPF.Text;
                txtRG_resp.Text = txtRG.Text;
                txtPhone_resp.Text = txtPhone.Text;
                txtWhatsApp_resp.Text = txtWhatsApp.Text;
                txtState_resp.Text = txtState.Text;
                txtAdd_resp.Text = txtAdd.Text;
                txtBlock_resp.Text = txtBlock.Text;
                txtCEP_resp.Text = txtCEP.Text;
                txtCity_resp.Text = txtCity.Text;
                txtNumber_resp.Text = txtNumber.Text;
                txtStreet_resp.Text = txtStreet.Text;
                birthDate_resp.SelectedDate = birthDate.SelectedDate;
                cbxSex_resp.SelectedIndex = cbxSex.SelectedIndex;
                checkBox_sameAdress.IsChecked = true;
                tabParent_Grid.IsEnabled = false;
            }

        }

        private void checkBox_permission_Checked(object sender, RoutedEventArgs e)
        {
            int age = 0;

            if (_student.Student_birthDate == String.Empty)
            {
                Xceed.Wpf.Toolkit.MessageBox.Show("Por favor, selecione a data de nascimento do aluno.", "Erro!", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK);
            }
            DateTime _birth = DateTime.Parse(birthDate.SelectedDate.ToString());
            age = (int)Math.Floor((DateTime.Now - _birth).TotalDays / 365.25D);

            _student.Student_birthDate = birthDate.SelectedDate.ToString();

            if (age < 18)
            {
                tabParent_Grid.IsEnabled = true;
            }
            else
            {
                tabParent_Grid.IsEnabled = false;
                checkBox_permission.IsChecked = true;

                txtName_resp.Text = txtName.Text;
                txtCPF_resp.Text = txtCPF.Text;
                txtRG_resp.Text = txtRG.Text;
                txtPhone_resp.Text = txtPhone.Text;
                txtWhatsApp_resp.Text = txtWhatsApp.Text;
                txtState_resp.Text = txtState.Text;
                txtAdd_resp.Text = txtAdd.Text;
                txtBlock_resp.Text = txtBlock.Text;
                txtCEP_resp.Text = txtCEP.Text;
                txtCity_resp.Text = txtCity.Text;
                txtNumber_resp.Text = txtNumber.Text;
                txtStreet_resp.Text = txtStreet.Text;
                birthDate_resp.SelectedDate = birthDate.SelectedDate;
                cbxSex_resp.SelectedIndex = cbxSex.SelectedIndex;
                checkBox_sameAdress.IsChecked = true;
                tabParent_Grid.IsEnabled = false;
            }
        }
    }
}
