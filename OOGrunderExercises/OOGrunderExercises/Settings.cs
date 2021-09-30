using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOGrunderExercises
{
    class Settings
    {
        //private bool _darkMode;
        //private bool _verticalLayout;
        //private bool _powerUser;

        //public Settings(bool darkMode, bool verticalLayout, bool powerUser)
        //{
        //    _darkMode = darkMode;
        //    _verticalLayout = verticalLayout;
        //    _powerUser = powerUser;
        //}

        public bool DarkMode
        {
            get;
            init;
        }
        public bool VerticalLayout
        {
            get;
            init;
        }
        public bool PowerUser
        {
            get;
            init;
        }
    }
}
