using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dewey_divertissement
{
    //This class has a list of books
    class CallList
    {
        public static List<CallNumber> callList = new();//This is a global list of type Book

        //This will get a created call number from the CallGenerator class.
        public static void generateCalls()
        {
            if (callList.Count > 1)
            {
                callList.Clear();
            }

            for (int i = 0; i < 10; i++)
            {
                callList.Add(CallGenerator.getRandomCall());
            }

        }

        //Sort this list then return as string
        public static List<string> getSortedString()
        {
            List<string> tempList = new();//Temp list because i need to convert from Book.object to string

            foreach (var item in callList)
            {
                tempList.Add(item.ToString());
            }

            tempList.Sort();//sorting list

            return tempList;//return sorted list
        }

    }
}
