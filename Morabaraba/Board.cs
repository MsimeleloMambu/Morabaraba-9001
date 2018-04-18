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

       public void printBoard (string [] myboard)//make a 2D array as cooardinate system for reference
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

        public void updateBoardlist(string pos,string character)
        {
            //"A1", "D1", "G1", "B2", "D2", "F2", "C3", "D3", "E3", "A4", "B4", "C4", "E4", "F4", "G4", "C5", "D5", "E5", "B6", "D6", "F6", "A7", "D7", "G7"
            switch (pos)
            {
                case "a1": Boardlist[0] = character; break;
                case "a4": Boardlist[1] = character; break;
                case "a7": Boardlist[2] = character; break;
                case "b2": Boardlist[3] = character; break;
                case "b4": Boardlist[4] = character; break;
                case "b6": Boardlist[5] = character; break;
                case "c3": Boardlist[6] = character; break;
                case "c4": Boardlist[7] = character; break;
                case "c5": Boardlist[8] = character; break;
                case "d1": Boardlist[9] = character; break;
                case "d2": Boardlist[10] = character; break;
                case "d3": Boardlist[11] = character; break;
                case "d5": Boardlist[12] = character; break;
                case "d6": Boardlist[13] = character; break;
                case "d7": Boardlist[14] = character; break;
                case "e3": Boardlist[15] = character; break;
                case "e4": Boardlist[16] = character; break;
                case "e5": Boardlist[17] = character; break;
                case "f2": Boardlist[18] = character; break;
                case "f4": Boardlist[19] = character; break;
                case "f6": Boardlist[20] = character; break;
                case "g1": Boardlist[21] = character; break;
                case "g4": Boardlist[22] = character; break;
                case "g7":
                    Boardlist[23] = character; break;

            }//string [] Boardlist =new string[24] { "a1", "d1", "g1", "b2", "d2", "f2", "c3", "d3", "e3", "a4", "b4", "c4", "e4", "f4", "g4", "c5", "d5", "e5", "b6", "d6", "f6", "a7", "d7", "g7" };
            //printBoard(Boardlist);
        }
        public void updateMoveBoard(string player, string Pos)
        {
            string symbol = " ";
            if (player == "black") symbol = "b";



            else
            
                symbol = "w";
            
            updateBoardlist(Pos, symbol);
        }
        public void updateMoveOnToBoard( string Pos)
        {
            updateBoardlist(Pos, " ");
        }
            
        //get the Boardlist
        public string [] getBoardlist()
        {
            return Boardlist;
        }
    }
}
