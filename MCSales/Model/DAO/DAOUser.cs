using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSales.Model.DAO
{
    class DAOUser
    {
        MySqlConnection con = null;

        public TOUser Login(string name, string password)
        {

            TOUser i = new TOUser();

            try
            {
                string sql = "select * from tbl_user where user_name = '" + name + "' and  user_password = '" + password + "';";

                con = ConnectionFactory.Connection();

                MySqlCommand cmd = new MySqlCommand(sql, con);

                con.Open();

                MySqlDataReader dtreader = cmd.ExecuteReader();

                if (dtreader.Read())//If there's any data.
                {
                    i.User_id = dtreader.GetInt16("user_id");
                    i.User_name = dtreader.GetString("user_name");
                    i.User_password = dtreader.GetString("user_password");
                    i.Permission_id = dtreader.GetInt16("permission_id");
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

        public List<TOUser> LoadUsers()
        {

            List<TOUser> i = new List<TOUser>();

            try
            {
                string sql = "select * from tbl_user;";

                con = ConnectionFactory.Connection();

                MySqlCommand cmd = new MySqlCommand(sql, con);

                con.Open();

                MySqlDataReader dtreader = cmd.ExecuteReader();

                    while (dtreader.Read())//If there's any data.
                    {
                        TOUser x = new TOUser();

                        x.User_id = dtreader.GetInt16("user_id");
                        x.User_name = dtreader.GetString("user_name");
                        x.User_password = dtreader.GetString("user_password");
                        x.Permission_id = dtreader.GetInt16("permission_id");

                    if(x.Permission_id == 1)
                    {
                        x.Permission_desc = "Administrador";
                    }else if(x.Permission_id == 2)
                    {
                        x.Permission_desc = "Administração";
                    }else if(x.Permission_id == 3)
                    {
                        x.Permission_desc = "Vendas";
                    }else
                    {
                        x.Permission_desc = "Professor";
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

        public List<TOUser> LoadTeachers()
        {

            List<TOUser> i = new List<TOUser>();

            try
            {
                string sql = "select * from tbl_user where permission_id = 4;";

                con = ConnectionFactory.Connection();

                MySqlCommand cmd = new MySqlCommand(sql, con);

                con.Open();

                MySqlDataReader dtreader = cmd.ExecuteReader();

                while (dtreader.Read())//If there's any data.
                {
                    TOUser x = new TOUser();

                    x.User_id = dtreader.GetInt16("user_id");
                    x.User_name = dtreader.GetString("user_name");
                    x.User_password = dtreader.GetString("user_password");
                    x.Permission_id = dtreader.GetInt16("permission_id");

                    if (x.Permission_id == 1)
                    {
                        x.Permission_desc = "Administrador";
                    }
                    else if (x.Permission_id == 2)
                    {
                        x.Permission_desc = "Administração";
                    }
                    else if (x.Permission_id == 3)
                    {
                        x.Permission_desc = "Vendas";
                    }
                    else
                    {
                        x.Permission_desc = "Professor";
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

        public bool DeleteUser(TOUser user)
        {

            List<int> i = new List<int>();
            bool resp = false;

            //code to delete a teacher.
            if (user.Permission_id == 4)
            {
                string sql = "select class_id from tbl_class where user_id = " + user.User_id + ";";

                con = ConnectionFactory.Connection();

                con.Open();

                MySqlCommand cmd = new MySqlCommand(sql, con);

                MySqlDataReader dtReader = cmd.ExecuteReader();

                while (dtReader.Read())
                {
                    i.Add(dtReader.GetInt16("class_id"));
                }

                con.Close();

                foreach (int id in i)
                {

                    string update_student = "update tbl_student set class_id = null, student_status = 'Lista de Espera' where class_id = " + id + ";";

                    con = ConnectionFactory.Connection();

                    con.Open();

                    MySqlCommand cmdUpdateStudent = new MySqlCommand(update_student, con);

                    cmdUpdateStudent.ExecuteNonQuery();

                    con.Close();
                }

                foreach (int _class in i)
                {


                    string delete_class = "delete from tbl_class where class_id = " + _class + ";";

                    con = ConnectionFactory.Connection();

                    con.Open();

                    MySqlCommand cmdDeleteClass = new MySqlCommand(delete_class, con);

                    cmdDeleteClass.ExecuteNonQuery();

                    con.Close();

                }

                string delete_user = "delete from tbl_user where user_id = " + user.User_id + ";";

                con = ConnectionFactory.Connection();

                con.Open();

                MySqlCommand cmdDeleteUser = new MySqlCommand(delete_user, con);

                cmdDeleteUser.ExecuteNonQuery();

                string ver = "select * from tbl_user where user_id = " + user.User_id + ";";

                con = ConnectionFactory.Connection();

                con.Open();

                MySqlCommand cmdVer = new MySqlCommand(delete_user, con);

                MySqlDataReader dtReaderVer = cmdDeleteUser.ExecuteReader();

                if (dtReaderVer.Read()){
                    resp = false;
                }
                else
                {
                    resp = true;
                }
            }

            //code to delete an ordinary user.
            else
            {

                string delete_user = "delete from tbl_user where user_id = " + user.User_id + ";";

                con = ConnectionFactory.Connection();

                con.Open();

                MySqlCommand cmdDeleteUser = new MySqlCommand(delete_user, con);

                cmdDeleteUser.ExecuteNonQuery();

                string ver = "select * from tbl_user where user_id = " + user.User_id + ";";

                con = ConnectionFactory.Connection();

                con.Open();

                MySqlCommand cmdVer = new MySqlCommand(delete_user, con);

                MySqlDataReader dtReaderVer = cmdDeleteUser.ExecuteReader();

                if (dtReaderVer.Read()){
                    resp = false;
                }
                else
                {
                    resp = true;
                }
            }
            return resp;
        }    

        public bool Registration(TOUser user)
        {
            MySqlConnection con = null;

            bool i = false;

            try
            {
                string sql = "insert into tbl_user(user_name, user_password, permission_id) values('" + user.User_name + "', '" + user.User_password + "', " + user.Permission_id + ");";

                con = ConnectionFactory.Connection();

                MySqlCommand cmd = new MySqlCommand(sql, con);

                con.Open();

                cmd.ExecuteNonQuery();

                con.Close();

                string select = "select * from tbl_user where user_name = '" + user.User_name + "';";

                con.Open();

                MySqlCommand command = new MySqlCommand(select, con);

                MySqlDataReader dtreader = command.ExecuteReader();

                if (dtreader.Read())//If there's any data.
                {
                    //registration sucessful
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
        
        public bool Update(TOUser user)
        {
            MySqlConnection con = null;

            bool i = false;

            try
            {
                string sql = @"update tbl_user set user_name = '" + user.User_name + "', user_password = '" + user.User_password + "', permission_id = " + user.Permission_id +
                    " where user_id = " + user.User_id + ";";

                con = ConnectionFactory.Connection();

                MySqlCommand cmd = new MySqlCommand(sql, con);

                con.Open();

                cmd.ExecuteNonQuery();

                string select = "select * from tbl_user where user_name = '" + user.User_name + "';";

                MySqlCommand command = new MySqlCommand(select, con);

                MySqlDataReader dtreader = command.ExecuteReader();

                if (dtreader.Read())//If there's any data.
                {
                    i = true;
                }
                else
                {
                    i = false;
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

        public TOUser Selection(int id)
        {
            MySqlConnection con = null;

            TOUser i = new TOUser();

            try
            {
                string sql = "select * from tbl_user where user_id = " + id + ";";

                con = ConnectionFactory.Connection();

                MySqlCommand cmd = new MySqlCommand(sql, con);

                con.Open();

                MySqlDataReader dtreader = cmd.ExecuteReader();

                if (dtreader.Read())//If there's any data.
                {
                    i.User_id = dtreader.GetInt16("user_id");
                    i.User_name = dtreader.GetString("user_name");
                    i.User_password = dtreader.GetString("user_password");
                    i.Permission_id = dtreader.GetInt16("permission_id");

                    if(i.Permission_id == 1)
                    {
                        i.Permission_desc = "Administrador";
                    }else if(i.Permission_id == 2)
                    {
                        i.Permission_desc = "Administração";
                    }else if(i.Permission_id == 3)
                    {
                        i.Permission_desc = "Vendas";
                    }
                    else
                    {
                        i.Permission_desc = "Professor";
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

    }
}
