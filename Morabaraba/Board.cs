using System;
using System.Collections.Generic;
using System.Text;

namespace Morabaraba
{
    public class Board : IBoard

    {
        private string [] Boardlist;
        public Board()
        {
            Boardlist = emptyBoard();
        }

        private string [] emptyBoard()
        {
            string [] emptylist=new string [24];
            for(int i = 0; i < 24; i++)
            {
                emptylist[i] = " ";
            }

            return emptylist;
        }

       public void printBoard (List<string> myboard)//make a 2D array as cooardinate system for reference
        {
            Console.WriteLine("||_____________ MORABARABA_______________||");
            Console.WriteLine("||{0}---------------{1}---------------{2}||", myboard[0], myboard[1], myboard[2]);
            Console.WriteLine("|| \\                |                // ||");
            Console.WriteLine("||  \\               |               //  ||");
            Console.WriteLine("||   {0}------------{1}------------{2}   ||", myboard[3], myboard[4], myboard[5]);
            Console.WriteLine("||   |\\             |             //|   ||");
            Console.WriteLine("||   | \\            |            // |   ||");
            Console.WriteLine("||   |  {0}---------{1}---------{2}  |   ||", myboard[6], myboard[7], myboard[8]);
            Console.WriteLine("||   |   |           |           |   |   ||");
            Console.WriteLine("||   |   |           |           |   |   ||");
            Console.WriteLine("{0}-{1}-{2}---------------------{3}-{4}-{5}", myboard[9], myboard[10], myboard[11], myboard[12], myboard[13], myboard[14]);
            Console.WriteLine("||   |   |           |           |   |   ||");
            Console.WriteLine("||   |   |           |           |   |   ||");
            Console.WriteLine("||   |  {0}---------{1}---------{2}  |   ||", myboard[15], myboard[16], myboard[17]);
            Console.WriteLine("||   |  //           |           \\  |   ||");
            Console.WriteLine("||   | //            |            \\ |   ||");
            Console.WriteLine("||   {0}------------{1}------------{2}   ||", myboard[18], myboard[19], myboard[20]);
            Console.WriteLine("||   //              |              \\   ||");
            Console.WriteLine("||  //               |               \\  ||");
            Console.WriteLine("||{0}---------------{1}---------------{2}||", myboard[21], myboard[22], myboard[23]);
            Console.WriteLine("||_______________________________________||");
            
        }
        //get the Boardlist
        public string[] getBoardlist()
        {
            return Boardlist;
        }
    }
}
