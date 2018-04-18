﻿using System;
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
        void updateMoveBoard(string player, string Pos);
        void updateBoardlist(string pos, string character);
        void printBoard(string[] myboard);
    }
  
    public interface IPlayer
    {
        //playerpositions
        //addmills
        //
        string getCurrentState();
        void AddPosition(string position);
        void updatingstate();
    }
    public interface IReferee
    {
        //
    }
}
