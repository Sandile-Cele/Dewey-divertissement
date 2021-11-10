using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dewey_divertissement.Class
{
    class ColumnMan
    {
        public static Dictionary<int, string> columnList = new() {
            {000, "General works"},
            {100, "Philosophy and psychology"},
            {200, "Religion"},
            {300, "Social sciences"},
            {400, "Languages"},
            {500, "Sciences"},
            {600, "Technology"},
            {700, "Arts and recreation"},
            {800, "Literature"},
            {900, "History and geography"}
        };

        //Get fully randomized list
        public Dictionary<int, string> getRandomList()// getRandomListMaxCalls(bool maxIdentifyingAreas)
        {
            Dictionary<int, string> tempColumnList = new();

            Random random = new();
            
            int listMax = 7;

            //Random 7 numbers for calls
            List<int> random7a = getRandom7();

            //Randomize randomOrderCalls for the Identifying areas
            List<int> random7b = random7a.OrderBy(y => random.Next()).ToList();

            for (int i = 0; i < listMax; i++)
            {
                //Using randomOrderCalls get random keys, using randomOrderAreas get random values
                tempColumnList.Add(columnList.ElementAt(random7a[i]).Key, columnList.ElementAt(random7b[i]).Value);

            }

            return tempColumnList;          
        }



        public bool DoTheyMatch(int key, string value)
        {
            int keyA = columnList.FirstOrDefault(x => x.Value == value && x.Key == key).Key;

            if (keyA == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public int getKeyFromValue(string value)
        {
            int key = columnList.FirstOrDefault(x => x.Value == value).Key;

            return key;
        }

        //Generate 7 random(1 to 10) number then, put in list
        private List<int> getRandom7()
        {
            int randomNumbers = 7;

            Random random = new();

            List<int> tempRandom = new();

            while (tempRandom.Count < 7)
            {
                int temp = random.Next(9);

                if (!tempRandom.Contains(temp))
                {
                    tempRandom.Add(temp);
                }

            }

            return tempRandom;
        }
    }
}
