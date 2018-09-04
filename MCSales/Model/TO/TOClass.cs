using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSales.Model
{
    class TOClass
    {

        int class_id;
        int user_id;
        int class_timePerWeek;
        int class_duration;
        int class_vacancys;
        string class_day;
        string class_hourStarts;
        string class_hourEnds;
        string class_TotalHours;
        string teacher;
        string teacher_name;
        string type;

        public int Class_id
        {
            get
            {
                return class_id;
            }

            set
            {
                class_id = value;
            }
        }

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

        public int Class_timePerWeek
        {
            get
            {
                return class_timePerWeek;
            }

            set
            {
                class_timePerWeek = value;
            }
        }

        public int Class_duration
        {
            get
            {
                return class_duration;
            }

            set
            {
                class_duration = value;
            }
        }

        public string Class_day
        {
            get
            {
                return class_day;
            }

            set
            {
                class_day = value;
            }
        }

        public int Class_vacancys
        {
            get
            {
                return class_vacancys;
            }

            set
            {
                class_vacancys = value;
            }
        }

        public string Class_hourStarts
        {
            get
            {
                return class_hourStarts;
            }

            set
            {
                class_hourStarts = value;
            }
        }

        public string Class_hourEnds
        {
            get
            {
                return class_hourEnds;
            }

            set
            {
                class_hourEnds = value;
            }
        }

        public string Class_TotalHours
        {
            get
            {
                return class_TotalHours;
            }

            set
            {
                class_TotalHours = value;
            }
        }

        public string Teacher
        {
            get
            {
                return teacher;
            }

            set
            {
                teacher = value;
            }
        }

        public string Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
            }
        }

        public string Teacher_name
        {
            get
            {
                return teacher_name;
            }

            set
            {
                teacher_name = value;
            }
        }
    }
}
