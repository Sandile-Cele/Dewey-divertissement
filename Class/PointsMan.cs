using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dewey_divertissement
{
    class PointsMan
    {
        private static int points = 000;//Tracking the users points

        //Getting the current users points
        public static int getPoints()
        {
            return points;
        }

        //Add a point to the list
        public static void addPoints(int pointAdd)
        {
            points += pointAdd;
        }

        public static double getPointPercent()
        {
            return points;

        }



    }
}
