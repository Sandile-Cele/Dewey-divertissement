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
    }
}
