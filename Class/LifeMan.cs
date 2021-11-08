using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dewey_divertissement.Class
{
    class LifeMan
    {
        private static string lives = "♥♥♥";

        public static string getLives()
        {
            return lives;
        }

        public static bool removeLife()
        {
            try
            {
                lives = lives.Remove(0, 1);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public static void reset()
        {
            lives = "♥♥♥";
        }
    }
}
