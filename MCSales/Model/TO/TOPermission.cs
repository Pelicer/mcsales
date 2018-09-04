using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSales.Model
{
    class TOPermission
    {

        int permission_id;
        int permission_desc;

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

        public int Permission_desc
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
