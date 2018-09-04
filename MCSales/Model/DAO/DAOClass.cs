using MCSales.Model.TO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Xceed.Wpf.Toolkit;

namespace MCSales.Model.DAO
{
    class DAOClass
    {
        MySqlConnection con = null;

        public bool Registration(TOClass _class)
        {
            bool i = false;

            try
            {

                string sql = @"insert into tbl_class(class_day, class_timesPerWeek,class_hourStarts, class_hourEnds, class_duration, class_vacancys, class_type, user_id) values('" 
                + _class.Class_day+ "', " + _class.Class_timePerWeek + ", '"  + _class.Class_hourStarts + "', '" + _class.Class_hourEnds + "', " + _class.Class_duration + ", " 
                + _class.Class_vacancys + ", '" + _class.Type + "', " +  _class.User_id + ");";

                con = ConnectionFactory.Connection();

                MySqlCommand cmd = new MySqlCommand(sql, con);

                con.Open();
                
                cmd.ExecuteNonQuery();

                con.Close();

                i = true;
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

        public bool Update(TOClass c)
        {
            bool i = false;
            try
            {
                string sql = "update tbl_class set class_day = '" + c.Class_day + "', class_timesPerWeek = " + c.Class_timePerWeek + ", class_hourStarts = '" + c.Class_hourStarts + "', class_hourEnds = '" + c.Class_hourEnds + "', class_duration = " + c.Class_duration + ", class_type = '" + c.Type + "', user_id = " + c.User_id + " where class_id = " + c.Class_id + ";";

                con = ConnectionFactory.Connection();

                con.Open();

                MySqlCommand cmdUpdate = new MySqlCommand(sql, con);

                cmdUpdate.ExecuteNonQuery();

                i = true;

                con.Close();
            }
            catch (MySqlException e)
            {
                throw new Exception(e.Message);
            }
            return i;
        }

        public TOClass Selection(int id)
        {

            TOClass i = new TOClass();

            try
            {
                string sql = "select * from tbl_class where class_id = " + id + ";";

                con = ConnectionFactory.Connection();

                MySqlCommand cmd = new MySqlCommand(sql, con);

                con.Open();

                MySqlDataReader dtreader = cmd.ExecuteReader();

                while (dtreader.Read())//If there's any data.
                {
                    i.Class_id = dtreader.GetInt16("class_id");
                    i.Class_day = dtreader.GetString("class_day");
                    i.Class_timePerWeek = dtreader.GetInt16("class_timesPerWeek");
                    i.Class_hourStarts = dtreader.GetString("class_hourStarts");
                    i.Class_hourEnds = dtreader.GetString("class_hourEnds");
                    i.Class_vacancys = dtreader.GetInt16("class_vacancys");
                    i.Class_duration = dtreader.GetInt16("class_duration");
                    i.User_id = dtreader.GetInt16("user_id");
                    i.Class_TotalHours = ("Das " + (dtreader.GetString("class_hourStarts")) + " às " + (dtreader.GetString("class_hourEnds")));
                    i.Type = dtreader.GetString("class_type");
                }

                con.Close();

            }
            catch (MySqlException e)
            {
                throw new Exception(e.Message);
            }
            return i;
        }

        public bool DeleteClass(int id)
        {
            List<int> i = new List<int>();

            bool b = false;

            string sql = "select student_id from tbl_student where class_id = " + id + ";";

            con = ConnectionFactory.Connection();

            con.Open();

            MySqlCommand cmd = new MySqlCommand(sql, con);

            MySqlDataReader dtReader = cmd.ExecuteReader();

            while (dtReader.Read())
            {
                i.Add(dtReader.GetInt16("student_id"));
            }

            con.Close();

            foreach (int student in i)
            {

                string update_student = "update tbl_student set class_id = null, student_status = 'Lista de Espera' where student_id = " + student + ";";

                con = ConnectionFactory.Connection();

                con.Open();

                MySqlCommand cmdUpdateStudent = new MySqlCommand(update_student, con);

                cmdUpdateStudent.ExecuteNonQuery();

                con.Close();
            }

                string delete_class = "delete from tbl_class where class_id = " + id + ";";

                con = ConnectionFactory.Connection();

                con.Open();

                MySqlCommand cmdDeleteClass = new MySqlCommand(delete_class, con);

                cmdDeleteClass.ExecuteNonQuery();

            b = true;

                return b;

        }

        public List<TOClass> LoadClasses()
        {

            List<TOClass> i = new List<TOClass>();

            try
            {
                string sql = "select * from tbl_class;";

                con = ConnectionFactory.Connection();

                MySqlCommand cmd = new MySqlCommand(sql, con);

                con.Open();

                MySqlDataReader dtreader = cmd.ExecuteReader();

                while (dtreader.Read())//If there's any data.
                {
                    TOClass x = new TOClass();

                    x.Class_id = dtreader.GetInt16("class_id");
                    x.Class_day = dtreader.GetString("class_day");
                    x.Class_timePerWeek = dtreader.GetInt16("class_timesPerWeek");
                    x.Class_hourStarts = dtreader.GetString("class_hourStarts");
                    x.Class_hourEnds = dtreader.GetString("class_hourEnds");
                    x.Class_vacancys = dtreader.GetInt16("class_vacancys");
                    x.Class_duration = dtreader.GetInt16("class_duration");
                    x.User_id = dtreader.GetInt16("user_id");
                    x.Class_TotalHours = ("Das " + (dtreader.GetString("class_hourStarts")) + " às " + (dtreader.GetString("class_hourEnds")));
                    x.Type = dtreader.GetString("class_type");

                    MySqlConnection connection = new MySqlConnection();
                    connection = ConnectionFactory.Connection();

                    string getTeacherName = "select user_name from tbl_user where user_id = " + x.User_id + ";";

                    connection.Open();

                    MySqlCommand cmdGet = new MySqlCommand(getTeacherName, connection);

                    MySqlDataReader dtReaderGet = cmdGet.ExecuteReader();

                    if (dtReaderGet.Read())
                    {
                        x.Teacher_name = dtReaderGet.GetString("user_name");
                    }

                    connection.Close();

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

        public List<TOClass> LoadClasses(string type)
        {

            List<TOClass> i = new List<TOClass>();

            try
            {
                string sql = "select * from tbl_class where class_type = '" + type + "';";

                con = ConnectionFactory.Connection();

                MySqlCommand cmd = new MySqlCommand(sql, con);

                con.Open();

                MySqlDataReader dtreader = cmd.ExecuteReader();

                while (dtreader.Read())//If there's any data.
                {
                    TOClass x = new TOClass();

                    x.Class_id = dtreader.GetInt16("class_id");
                    x.Class_day = dtreader.GetString("class_day");
                    x.Class_timePerWeek = dtreader.GetInt16("class_timesPerWeek");
                    x.Class_hourStarts = dtreader.GetString("class_hourStarts");
                    x.Class_hourEnds = dtreader.GetString("class_hourEnds");
                    x.Class_vacancys = dtreader.GetInt16("class_vacancys");
                    x.Class_duration = dtreader.GetInt16("class_duration");
                    x.User_id = dtreader.GetInt16("user_id");
                    x.Class_TotalHours = ("Das " + (dtreader.GetString("class_hourStarts")) + " às " + (dtreader.GetString("class_hourEnds")));
                    x.Type = dtreader.GetString("class_type");

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

        public List<TOClass> LoadClass(int id)
        {

            List<TOClass> i = new List<TOClass>();

            try
            {
                string sql = "select * from tbl_class where class_id = " + id + ";";

                con = ConnectionFactory.Connection();

                MySqlCommand cmd = new MySqlCommand(sql, con);

                con.Open();

                MySqlDataReader dtreader = cmd.ExecuteReader();

                while (dtreader.Read())//If there's any data.
                {
                    TOClass x = new TOClass();

                    x.Class_id = dtreader.GetInt16("class_id");
                    x.Class_day = dtreader.GetString("class_day");
                    x.Class_timePerWeek = dtreader.GetInt16("class_timesPerWeek");
                    x.Class_hourStarts = dtreader.GetString("class_hourStarts");
                    x.Class_hourEnds = dtreader.GetString("class_hourEnds");
                    x.Class_vacancys = dtreader.GetInt16("class_vacancys");
                    x.Class_duration = dtreader.GetInt16("class_duration");
                    x.User_id = dtreader.GetInt16("user_id");
                    x.Class_TotalHours = ("Das " + (dtreader.GetString("class_hourStarts")) + " às " + (dtreader.GetString("class_hourEnds")));
                    x.Type = dtreader.GetString("class_type");

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

        public TOClass LoadQuickMenu(string day)
        {

            List<TOClass> i = new List<TOClass>();
            TOClass x = new TOClass();
            int highestRate = 0;

            try
            {
                string sql = "select class_vacancys from tbl_class where class_day = '" + day + "';";

                con = ConnectionFactory.Connection();

                MySqlCommand cmd = new MySqlCommand(sql, con);

                con.Open();

                MySqlDataReader dtreader = cmd.ExecuteReader();

                while (dtreader.Read())
                {
                    TOClass _class = new TOClass();
                    _class.Class_vacancys = dtreader.GetInt16("class_vacancys");

                    i.Add(_class);
                }

                try
                {
                    highestRate = i.Max(r => r.Class_vacancys);
                }
                catch (Exception)
                {
                    Xceed.Wpf.Toolkit.MessageBox.Show("Erro ao retornar resultados. Por favor, cheque as vagas manualmente.", "MC Sales", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
                }

                con.Close();

                string selectClass = "select * from tbl_class where class_vacancys = " + highestRate + " and class_day = '" + day + "';"; ;

                con.Open();

                MySqlCommand cmdSelectClass = new MySqlCommand(selectClass, con);

                MySqlDataReader dtReaderSelectClass = cmdSelectClass.ExecuteReader();

                if (dtReaderSelectClass.Read())
                {
                    x.Class_id = dtReaderSelectClass.GetInt16("class_id");
                    x.Class_day = dtReaderSelectClass.GetString("class_day");
                    x.Class_timePerWeek = dtReaderSelectClass.GetInt16("class_timesPerWeek");
                    x.Class_hourStarts = dtReaderSelectClass.GetString("class_hourStarts");
                    x.Class_hourEnds = dtReaderSelectClass.GetString("class_hourEnds");
                    x.Class_vacancys = dtReaderSelectClass.GetInt16("class_vacancys");
                    x.Class_duration = dtReaderSelectClass.GetInt16("class_duration");
                    x.User_id = dtReaderSelectClass.GetInt16("user_id");
                    x.Class_TotalHours = ("Das " + (dtReaderSelectClass.GetString("class_hourStarts")) + " às " + (dtReaderSelectClass.GetString("class_hourEnds")));
                    x.Type = dtReaderSelectClass.GetString("class_type");
                }

            }
            catch (MySqlException e)
            {
                throw new Exception(e.Message);
            }
            return x;
        }

        public int VacancyCount(string day)
        {
            int i = 0;

            string sql = "select class_vacancys from tbl_class where class_day like '%" + day + "%';";

            con = ConnectionFactory.Connection();

            con.Open();

            MySqlCommand cmd = new MySqlCommand(sql, con);

            MySqlDataReader dtreader = cmd.ExecuteReader();

            while (dtreader.Read())
            {
                i += dtreader.GetInt16("class_vacancys");
            }
            con.Close();
            return i;
        }



    }
}
