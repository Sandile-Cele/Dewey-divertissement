using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dewey_divertissement.Class
{
    class LifeMan
    {
        //Managing lives
        private static string lives = "♥♥♥♥";

        //Return lives left
        public static string getLives()
        {
            return lives;
        }

        //If user made a bad selection, remove a life
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
            lives = "♥♥♥♥";
        }
    }
}
