using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dewey_divertissement
{
    class CallNumber
    {
        int firstNum, secondNum;
        string author;

        public CallNumber(int firstNum, int secondNum, string author)
        {
            this.firstNum = firstNum;
            this.secondNum = secondNum;
            this.author = author;
        }

        public int FirstNum { get => firstNum; set => firstNum = value; }
        public int SecondNum { get => secondNum; set => secondNum = value; }
        public string Author { get => author; set => author = value; }

        public override string ToString()
        {
            return FirstNum + ", " + SecondNum + " " + author;
        }
    }
}
