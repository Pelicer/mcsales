using MCSales.Model.TO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MCSales.Model.DAO
{
    class DAOStudents
    {
        MySqlConnection con = null;

        public bool CheckVacancys(int id)
        {
            bool i = false;

            TOClass _class = new TOClass();

            string vacancy_count = "select class_vacancys from tbl_class where class_id = " + id + ";";

            con = ConnectionFactory.Connection();

            MySqlCommand cmdVacancyCount = new MySqlCommand(vacancy_count, con);

            con.Open();

            MySqlDataReader dtReaderVacancyCount = cmdVacancyCount.ExecuteReader();

            if (dtReaderVacancyCount.Read())
            {
                _class.Class_vacancys = dtReaderVacancyCount.GetInt16("class_vacancys");
            }
            con.Close();

            if (_class.Class_vacancys >= 1)
            {
                i = true;
            }
            else
            {
                i = false;
            }
            return i;
        }

        public bool CheckCTR(string ctr)
        {
            bool i = false;

            TOClass _class = new TOClass();

            string check = "select * from tbl_student where student_ctr = '" + ctr + "';";

            con = ConnectionFactory.Connection();

            MySqlCommand cmdCheckCTR = new MySqlCommand(check, con);

            con.Open();

            MySqlDataReader dtReaderCheckCTR = cmdCheckCTR.ExecuteReader();

            if (dtReaderCheckCTR.Read())
            {
                i = false;
            }
            else
            {
                i = true;
            }
            con.Close();
            return i;
        }

        public bool Registration(TOStudent student, TOResponsable resp)
        {
            bool i = false;

            TOClass _class = new TOClass();

            try
            {
                if (resp != null)
                {
                    string insert_resp = @"insert into tbl_resp(resp_name, resp_rg, resp_cpf, resp_birthDate, resp_sex, 
                    resp_phone, resp_whatsApp, resp_cep, resp_state, resp_city, resp_block, resp_street,resp_number, resp_obs) values('"
                    + resp.Resp_name + "', '" + resp.Resp_rg + "', '" + resp.Resp_cpf + "', '" + resp.Resp_birthDate + "', '" + resp.Resp_sex + "', '"
                    + resp.Resp_phone + "', '" + resp.Resp_whatsApp + "', '" + resp.Resp_cep + "', '" + resp.Resp_state + "', '" + resp.Resp_city + "', '"
                    + resp.Resp_block + "', '" + resp.Resp_street + "', '" + resp.Resp_number + "', '" + resp.Resp_obs + "');";

                    con = ConnectionFactory.Connection();

                    MySqlCommand cmdInsertResp = new MySqlCommand(insert_resp, con);

                    con.Open();

                    cmdInsertResp.ExecuteNonQuery();

                    con.Close();

                    string select_resp = "select resp_id from tbl_resp where resp_rg = '" + resp.Resp_rg + "';";

                    MySqlCommand cmdSelect = new MySqlCommand(select_resp, con);

                    con.Open();

                    MySqlDataReader reader = cmdSelect.ExecuteReader();

                    if (reader.Read())
                    {
                        resp.Resp_id = reader.GetInt16("resp_id");
                    }

                    con.Close();

                    string sql = @"insert into tbl_student(student_name, student_ctr, student_status, student_subscriptionDate, 
                    student_rg, student_cpf, student_birthDate, student_sex, student_phone, student_whatsApp, 
                    student_cep, student_state, student_city, student_block, student_street, student_number, student_obs, 
                    class_id, resp_id) values('" + student.Student_name + "', '" + student.Student_ctr + "', 'Ativo', '" + student.Student_subscriptionDate
                   + "', '" + student.Student_rg + "', '" + student.Student_cpf + "', '" + student.Student_birthDate + "', '" + student.Student_sex + "', '"
                   + student.Student_phone + "', '" + student.Student_whatsApp + "', '" + student.Student_cep + "', '" + student.Student_state + "', '"
                   + student.Student_city + "', '" + student.Student_block + "', '" + student.Student_street + "', '" + student.Student_number + "', '"
                   + student.Student_obs + "', " + student.Class_id + ", " + resp.Resp_id + ");";

                    con = ConnectionFactory.Connection();

                    MySqlCommand cmd = new MySqlCommand(sql, con);

                    con.Open();

                    cmd.ExecuteNonQuery();

                    con.Close();

                    string select = "select * from tbl_student where student_ctr = '" + student.Student_ctr + "';";

                    con.Open();

                    MySqlCommand cmdSelectStudent = new MySqlCommand(select, con);

                    MySqlDataReader dtReaderSelect = cmdSelectStudent.ExecuteReader();

                    if (dtReaderSelect.Read())
                    {
                        i = true;

                        int v = 0;

                        string select_vacancys = "select class_vacancys from tbl_class where class_id = " + student.Class_id + ";";

                        MySqlConnection conSelect = ConnectionFactory.Connection();

                        conSelect.Open();

                        MySqlCommand cmdSelect_Vacancys = new MySqlCommand(select_vacancys, conSelect);

                        MySqlDataReader dtReaderVacancys = cmdSelect_Vacancys.ExecuteReader();

                        if (dtReaderVacancys.Read())
                        {
                            v = dtReaderVacancys.GetInt16("class_vacancys");
                        }

                        conSelect.Close();

                        string update = "update tbl_class set class_vacancys = " + (v - 1) + " where class_id = " + student.Class_id + ";";

                        conSelect.Open();

                        MySqlCommand cmdUpdate = new MySqlCommand(update, conSelect);

                        cmdUpdate.ExecuteNonQuery();

                        conSelect.Close();
                    }
                    else
                    {
                        i = false;
                    }
                }
                else
                {
                    string sql = @"insert into tbl_student(student_name, student_ctr, student_status, student_subscriptionDate, 
                    student_rg, student_cpf, student_birthDate, student_sex, student_phone, student_whatsApp, 
                    student_cep, student_state, student_city, student_block, student_street, student_number, student_obs, 
                    class_id, resp_id) values('" + student.Student_name + "', '" + student.Student_ctr + "', 'Ativo', '" + student.Student_subscriptionDate
                    + "', '" + student.Student_rg + "', '" + student.Student_cpf + "', '" + student.Student_birthDate + "', '" + student.Student_sex + "', '"
                    + student.Student_phone + "', '" + student.Student_whatsApp + "', '" + student.Student_cep + "', '" + student.Student_state + "', '"
                    + student.Student_city + "', '" + student.Student_block + "', '" + student.Student_street + "', '" + student.Student_number + "', '"
                    + student.Student_obs + "', " + student.Class_id + ", null);";

                    con = ConnectionFactory.Connection();

                    MySqlCommand cmd = new MySqlCommand(sql, con);

                    con.Open();

                    cmd.ExecuteNonQuery();

                    con.Close();

                    string select = "select * from tbl_student where student_ctr = '" + student.Student_ctr + "';";

                    con.Open();

                    MySqlCommand cmdSelect = new MySqlCommand(select, con);

                    MySqlDataReader dtReaderSelect = cmdSelect.ExecuteReader();

                    if (dtReaderSelect.Read())
                    {
                        i = true;

                        int v = 0;

                        string select_vacancys = "select class_vacancys from tbl_class where class_id = " + student.Class_id + ";";

                        MySqlConnection conSelect = ConnectionFactory.Connection();

                        conSelect.Open();

                        MySqlCommand cmdSelect_Vacancys = new MySqlCommand(select_vacancys, conSelect);

                        MySqlDataReader dtReaderVacancys = cmdSelect_Vacancys.ExecuteReader();

                        if (dtReaderVacancys.Read())
                        {
                            v = dtReaderVacancys.GetInt16("class_vacancys");
                        }

                        conSelect.Close();

                        string update = "update tbl_class set class_vacancys = " + (v - 1) + " where class_id = " + student.Class_id + ";";

                        conSelect.Open();

                        MySqlCommand cmdUpdate = new MySqlCommand(update, conSelect);

                        cmdUpdate.ExecuteNonQuery();

                        conSelect.Close();
                    }
                    else
                    {
                        i = false;
                    }
                }

            }
            catch (MySqlException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                con.Close();
            }
            return i;
        }

        public bool Update(TOStudent student, TOResponsable resp)
        {
            bool i = false;

            TOClass _class = new TOClass();

            try
            {
                if (resp != null)
                {

                    string sql = @"update tbl_student set student_name = '" + student.Student_name + "', student_ctr = '" + student.Student_ctr
                    + "', student_status = '" + student.Student_state + "', student_rg = '" + student.Student_rg + "', student_cpf = '" + student.Student_cpf + "', student_birthDate = '"
                    + student.Student_birthDate + "', student_sex = '" + student.Student_sex + "', student_phone = '" + student.Student_phone
                    + "', student_whatsApp = '" + student.Student_whatsApp + "', student_cep = '" + student.Student_cep + "', student_state = '"
                    + student.Student_state + "', student_city = '" + student.Student_city + "', student_block = '" + student.Student_block
                    + "', student_street = '" + student.Student_street + "', student_number = '" + student.Student_number + "', student_obs = '"
                    + student.Student_obs + "', class_id = " + student.Class_id + ", resp_id = " + student.Resp_id + " where student_id = " + student.Student_id + ";";

                    con = ConnectionFactory.Connection();

                    MySqlCommand cmd = new MySqlCommand(sql, con);

                    con.Open();

                    cmd.ExecuteNonQuery();

                    con.Close();

                    string select = "select * from tbl_student where student_ctr = '" + student.Student_ctr + "';";

                    con.Open();

                    MySqlCommand cmdSelectStudent = new MySqlCommand(select, con);

                    MySqlDataReader dtReaderSelect = cmdSelectStudent.ExecuteReader();

                    if (dtReaderSelect.Read())
                    {
                        i = true;
                    }
                    else
                    {
                        i = false;
                    }

                    con.Close();

                    string update_resp = @"update tbl_resp set resp_name = '" + resp.Resp_name + "', resp_rg = '" + resp.Resp_rg
                    + "', resp_cpf = '" + resp.Resp_cpf + "', resp_birthDate = '" + resp.Resp_birthDate + "', resp_sex = '" + resp.Resp_sex
                    + "', resp_phone = '" + resp.Resp_phone + "', resp_whatsApp = '" + resp.Resp_whatsApp + "',  resp_cep = '" + resp.Resp_cep
                    + "', resp_state = '" + resp.Resp_state + "', resp_city = '" + resp.Resp_city + "', resp_block = '" + resp.Resp_block
                    + "', resp_street = '" + resp.Resp_street + "', resp_number = '" + resp.Resp_number + "', resp_obs = '" + resp.Resp_obs + "' where resp_id = " + resp.Resp_id + ";";

                    con = ConnectionFactory.Connection();

                    MySqlCommand cmdUpdateResp = new MySqlCommand(update_resp, con);

                    con.Open();

                    cmdUpdateResp.ExecuteNonQuery();

                    
                }
                else
                {
                    string sql = @"update tbl_student set student_name = '" + student.Student_name + "', student_ctr = '" + student.Student_ctr
                    + "', student_status = '" + student.Student_state + "', student_subscriptionDate = '" + student.Student_subscriptionDate
                    + "', student_rg = '" + student.Student_rg + "', student_cpf = '" + student.Student_cpf + "', student_birthDate = '"
                    + student.Student_birthDate + "', student_sex = '" + student.Student_sex + "', student_phone = '" + student.Student_phone
                    + "', student_whatsApp = '" + student.Student_whatsApp + "', student_cep = '" + student.Student_cep + "', student_state = '"
                    + student.Student_state + "', student_city = '" + student.Student_city + "', student_block = '" + student.Student_block
                    + "', student_street = '" + student.Student_street + "', student_number = '" + student.Student_number + "', student_obs = '"
                    + student.Student_obs + "', class_id = " + student.Class_id + ", resp_id = null where student_id = " + student.Resp_id + ";";

                    con = ConnectionFactory.Connection();

                    MySqlCommand cmd = new MySqlCommand(sql, con);

                    con.Open();

                    cmd.ExecuteNonQuery();

                    con.Close();

                    string select = "select * from tbl_student where student_ctr = '" + student.Student_ctr + "';";

                    con.Open();

                    MySqlCommand cmdSelect = new MySqlCommand(select, con);

                    MySqlDataReader dtReaderSelect = cmdSelect.ExecuteReader();

                    if (dtReaderSelect.Read())
                    {
                        i = true;
                    }
                    else
                    {
                        i = false;
                    }
                }

            }
            catch (MySqlException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                con.Close();
            }
            return i;
        }

        public List<TOStudent> LoadStudents()
        {
            List<TOStudent> i = new List<TOStudent>();

            try
            {
                string sql = "select * from tbl_student;";

                con = ConnectionFactory.Connection();

                MySqlCommand cmd = new MySqlCommand(sql, con);

                con.Open();

                MySqlDataReader dtreader = cmd.ExecuteReader();

                while (dtreader.Read())//If there's any data.
                {
                    TOStudent x = new TOStudent();

                    x.Student_id = dtreader.GetInt16("student_id");
                    x.Student_name = dtreader.GetString("student_name");
                    x.Student_ctr = dtreader.GetString("student_ctr");
                    x.Student_status = dtreader.GetString("student_status");
                    x.Student_subscriptionDate = dtreader.GetString("student_subscriptionDate");

                    //verifying if class exists.
                    var _classID = dtreader["class_id"] as int?;
                    if (_classID.HasValue)
                    {
                        x.Class_id = dtreader.GetInt16("class_id");
                    }
                    else
                    {
                        x.Class_id = 0;
                    }

                    i.Add(x);
                }

                con.Close();

            }
            catch (MySqlException e)
            {
                throw new Exception(e.Message);
            }
            return i;
        }

        public List<TOStudent> LoadStudents(int id)
        {
            List<TOStudent> i = new List<TOStudent>();

            try
            {
                string sql = "select * from tbl_student where class_id = " + id + ";";

                con = ConnectionFactory.Connection();

                MySqlCommand cmd = new MySqlCommand(sql, con);

                con.Open();

                MySqlDataReader dtreader = cmd.ExecuteReader();

                while (dtreader.Read())//If there's any data.
                {
                    TOStudent x = new TOStudent();

                    x.Student_id = dtreader.GetInt16("student_id");
                    x.Student_name = dtreader.GetString("student_name");
                    x.Student_ctr = dtreader.GetString("student_ctr");
                    x.Student_status = dtreader.GetString("student_status");
                    x.Student_subscriptionDate = dtreader.GetString("student_subscriptionDate");

                    //verifying if class exists.
                    var _classID = dtreader["class_id"] as int?;
                    if (_classID.HasValue)
                    {
                        x.Class_id = dtreader.GetInt16("class_id");
                    }
                    else
                    {
                        x.Class_id = 0;
                    }

                    i.Add(x);
                }

                con.Close();

            }
            catch (MySqlException e)
            {
                throw new Exception(e.Message);
            }
            return i;
        }

        public TOStudent Selection(string ctr)
        {
            MySqlConnection con = null;

            TOStudent i = new TOStudent();

            try
            {
                string sql = "select * from tbl_student where student_ctr = '" + ctr + "';";

                con = ConnectionFactory.Connection();

                MySqlCommand cmd = new MySqlCommand(sql, con);

                con.Open();

                MySqlDataReader dtreader = cmd.ExecuteReader();

                if (dtreader.Read())//If there's any data.
                {
                    var _classID = dtreader["class_id"] as int?;
                    if (_classID.HasValue)
                    {
                        i.Class_id = dtreader.GetInt16("class_id");
                    }
                    else
                    {
                        i.Resp_id = 0;
                    }
                    i.Student_id = dtreader.GetInt16("student_id");
                    i.Student_birthDate = dtreader.GetString("student_birthDate");
                    i.Student_block = dtreader.GetString("student_block");
                    i.Student_cep = dtreader.GetString("student_cep");
                    i.Student_city = dtreader.GetString("student_city");
                    i.Student_cpf = dtreader.GetString("student_cpf").ToString();
                    i.Student_name = dtreader.GetString("student_name");
                    i.Student_number = dtreader.GetString("student_number");
                    i.Student_obs = dtreader.GetString("student_obs");
                    i.Student_phone = dtreader.GetString("student_phone");
                    i.Student_rg = dtreader.GetString("student_rg");
                    i.Student_sex = dtreader.GetString("student_sex");
                    i.Student_state = dtreader.GetString("student_state");
                    i.Student_street = dtreader.GetString("student_street");
                    i.Student_whatsApp = dtreader.GetString("student_whatsApp");
                    i.Student_ctr = dtreader.GetString("student_ctr");
                    i.Student_subscriptionDate = dtreader.GetString("student_subscriptionDate");

                    var _respID = dtreader["resp_id"] as int?;
                    if (_respID.HasValue)
                    {
                        i.Resp_id = dtreader.GetInt16("resp_id");
                    }else
                    {
                        i.Resp_id = 0;
                    }

                }
                else
                {
                }

            }
            catch (MySqlException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                con.Close();
            }
            return i;
        }

        public TOResponsable SelectResp(int id)
        {
            MySqlConnection con = null;

            TOResponsable i = new TOResponsable();

            try
            {
                string sql = "select * from tbl_resp where resp_id = " + id + ";";

                con = ConnectionFactory.Connection();

                MySqlCommand cmd = new MySqlCommand(sql, con);

                con.Open();

                MySqlDataReader dtreader = cmd.ExecuteReader();

                if (dtreader.Read())//If there's any data.
                {
                    i.Resp_birthDate = dtreader.GetString("resp_birthDate");
                    i.Resp_block = dtreader.GetString("resp_block");
                    i.Resp_cep = dtreader.GetString("resp_cep");
                    i.Resp_city = dtreader.GetString("resp_city");
                    i.Resp_cpf = dtreader.GetString("resp_cpf").ToString();
                    i.Resp_id = dtreader.GetInt16("resp_id");
                    i.Resp_name = dtreader.GetString("resp_name");
                    i.Resp_number = dtreader.GetString("resp_number");
                    i.Resp_obs = dtreader.GetString("resp_obs");
                    i.Resp_phone = dtreader.GetString("resp_phone");
                    i.Resp_rg = dtreader.GetString("resp_rg");
                    i.Resp_sex = dtreader.GetString("resp_sex");
                    i.Resp_state = dtreader.GetString("resp_state");
                    i.Resp_street = dtreader.GetString("resp_street");
                    i.Resp_whatsApp = dtreader.GetString("resp_whatsApp");

                }
                else
                {
                }

            }
            catch (MySqlException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                con.Close();
            }
            return i;
        }

        public bool DeleteStudent(string ctr)
        {
            bool i = false;
            TOStudent student = new TOStudent();

            try

            {
                string sql = "delete from tbl_student where student_ctr = '" + ctr + "';";
                string getClass_id = "select class_id from tbl_student where student_ctr = '" + ctr + "';";

                con = ConnectionFactory.Connection();

                con.Open();

                MySqlCommand cmd = new MySqlCommand(getClass_id, con);

                MySqlDataReader reader = cmd.ExecuteReader();

                reader.Read();

                //verifying if class exists.
                var _classID = reader["class_id"] as int?;
                if (_classID.HasValue)
                {
                    student.Class_id = reader.GetInt16("class_id");

                    con.Close();

                    con = ConnectionFactory.Connection();

                    con.Open();

                    MySqlCommand delete = new MySqlCommand(sql, con);

                    delete.ExecuteNonQuery();

                    con.Close();

                    string select = "select * from tbl_student where student_ctr = '" + ctr + "';";

                    con.Open();

                    MySqlCommand command = new MySqlCommand(select, con);

                    MySqlDataReader dtreader = command.ExecuteReader();

                    if (dtreader.Read())//If there's any data.
                    {
                        i = false;
                    }
                    else
                    {
                        i = true;
                    }

                    con.Close();

                    if (i == true)
                    {

                        int v = 0;

                        string getVacancys = "select class_vacancys from tbl_class where class_id = " + student.Class_id + ";";

                        con = ConnectionFactory.Connection();

                        con.Open();

                        MySqlCommand Vacancys = new MySqlCommand(getVacancys, con);

                        MySqlDataReader get = Vacancys.ExecuteReader();

                        if (get.Read())
                        {
                            v = get.GetInt16("class_vacancys");

                            int total = v + 1;

                            string newVacancy = "update tbl_class set class_vacancys = " + total + " where class_id = " + student.Class_id + ";";

                            MySqlConnection connection = ConnectionFactory.Connection();

                            connection.Open();
                            MySqlCommand _newVacancy = new MySqlCommand(newVacancy, connection);

                            _newVacancy.ExecuteNonQuery();

                            connection.Close();
                        }
                    }
                    con.Close();
                }
                else
                {
                    con = ConnectionFactory.Connection();

                    con.Open();

                    MySqlCommand delete = new MySqlCommand(sql, con);

                    delete.ExecuteNonQuery();

                    i = true;
                }
            }
            catch (MySqlException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                con.Close();
            }

            return i;
        }
    }
}

