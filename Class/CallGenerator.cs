using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dewey_divertissement
{
    class CallGenerator
    {
        //The random class will be used to create 3 random numbers and 3 random letters
        private static readonly Random random = new Random();

        public static CallNumber getRandomCall()
        {
            return new CallNumber(getThreeNums(), getThreeNums(), getThreeLetters());
        }

        //create 3 random letters
        private static string getThreeLetters()
        {
            var builder = new StringBuilder(3);

            for (var i = 0; i < 3; i++)//Looping 3 time because i need 3 random letters 
            {
                var @char = (char)random.Next('A', 'Z'+ 1);
                builder.Append(@char);
            }

            return builder.ToString();

        }

        //Generating a 3 random numbers
        private static int getThreeNums()
        {
            int temp3 = random.Next(999);
            return temp3;
        }


    }
}
