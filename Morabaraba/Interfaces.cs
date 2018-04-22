using System;
using System.Collections.Generic;
using System.Text;

namespace Morabaraba
{
    public interface IBoard
    {
        //updateboard
        //printboard
        //
        string [] getBoardlist();
        void updateMoveOnToBoard(string Pos);
        void updateMoveBoard(string player, string Pos);
        void updateBoardlist(string pos, string character);
        void printBoard(string[] myboard);
        bool isitvalid(string position);
    }
  
    public interface IPlayer
    {
        //playerpositions
        //addmills
        //
        string getCurrentState();
        void updatingstate();
        int cowsThere();
        string WhoIsPlaying();
        List<string> Positions();
        void swapcurrentPlayer();
        void Addcow(string position);

    }

    public interface IReferee
    {
        //
    }
}
