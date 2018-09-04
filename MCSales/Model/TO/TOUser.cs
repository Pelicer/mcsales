using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSales.Model
{
    public class TOUser
    {
        int user_id;
        int permission_id;
        string user_name;
        string user_password;
        string permission_desc;

        public int User_id
        {
            get
            {
                return user_id;
            }

            set
            {
                user_id = value;
            }
        }

        public int Permission_id
        {
            get
            {
                return permission_id;
            }

            set
            {
                permission_id = value;
            }
        }

        public string User_name
        {
            get
            {
                return user_name;
            }

            set
            {
                user_name = value;
            }
        }

        public string User_password
        {
            get
            {
                return user_password;
            }

            set
            {
                user_password = value;
            }
        }

        public string Permission_desc
        {
            get
            {
                return permission_desc;
            }

            set
            {
                permission_desc = value;
            }
        }
    }
}
