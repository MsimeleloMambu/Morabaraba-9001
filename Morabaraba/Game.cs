﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Morabaraba
{
    public class Game
    {
        //public string currentplayerID { get; set; }
        private string currentplayerID;
        private List<string> moves;
        private int placeNumBlack;
        private int placeNumWhite;
        private int cowsthatExist;
        private List<List<string>> player1Moves;
        private List<List<string>> player2Moves;
        //public int totalPlaced;
        //private bool isPlacing;

        private IPlayer pWhite;
        private IPlayer pBlack;
        private IBoard Board;

        public Game()
        {
            currentplayerID = "black";//start with black
            placeNumBlack = 0;
            placeNumWhite = 0;
            cowsthatExist = 0;
            List<List<string>> player1Moves;
            List<List<string>> player2Moves;
            pBlack = new Player("black");
            pWhite = new Player("white");
            Board = new Board();
            moves = getPossibleMoves();
        }

        private List<string> getPossibleMoves()
        {


            return new List<string> { "a1", "d1", "g1", "b2", "d2", "f2", "c3", "d3", "e3", "a4", "b4", "c4", "e4", "f4", "g4", "c5", "d5", "e5", "b6", "d6", "f6", "a7", "d7", "g7" };
        }
        private bool isValidPosition(string position)
        {
            return moves.Contains(position);
        }
        public int getplaceNumBlack()
        {
            return placeNumBlack;
        }
        public int getplaceNumWhite()
        {
            return placeNumWhite;
        }
        public List<List<string>> player1CheckMoves()
        {
            return player1Moves;
        }
        public List<List<string>> player2CheckMoves()
        {
            return player2Moves;
        }
        public void swapcurrentPlayer()
        {
            switch (currentplayerID)

            {
                case "black":
                    currentplayerID = "white";
                    return;
                case "white":
                    currentplayerID = "black";
                    return;
            }
        }
        public string getCurrentPlayerID()
        {
            return currentplayerID;
        }
        public void Placement(string Position)

        {
            if (BlankSpace(Position) == true)
            {
                if (currentplayerID == "black" && placeNumBlack < 13 )
                {

                    if (pBlack.getCurrentState() == "placing")
                    {
                        Board.updateMoveBoard(currentplayerID, Position);
                        placeNumBlack++;
                        pBlack.AddPosition(Position);
                        pBlack.updatingstate();
                        cowsthatExist++;
                    }


                }


                if (currentplayerID == "white" && placeNumBlack < 13)
                {
                    if (pWhite.getCurrentState() == "placing")
                    {
                        Board.updateMoveBoard(currentplayerID, Position);
                        placeNumWhite++;
                        pWhite.AddPosition(Position);
                        pWhite.updatingstate();
                        cowsthatExist++;
                    }
                }

            }

        }
        public bool BlankSpace(string position)
        {
            return (getPieceAtPosition(position) == " ");
           
               
           
        }
        public string getPieceAtPosition(string pos)
        {
            return getPieceAtPos(pos, Board);
        }
        public string getPieceAtPos(string position, IBoard Board)
        {
            string [] gboard = Board.getBoardlist();
            switch (position)
            {
                case "a1": return gboard[0];
                case "a4": return gboard[1];
                case "a7": return gboard[2];
                case "b2": return gboard[3];
                case "b4": return gboard[4];
                case "b6": return gboard[5];
                case "c3": return gboard[6];
                case "c4": return gboard[7];
                case "c5": return gboard[8];
                case "d1": return gboard[9];
                case "d2": return gboard[10];
                case "d3": return gboard[11];
                case "d5": return gboard[12];
                case "d6": return gboard[13];
                case "d7": return gboard[14];
                case "e3": return gboard[15];
                case "e4": return gboard[16];
                case "e5": return gboard[17];
                case "f2": return gboard[18];
                case "f4": return gboard[19];
                case "f6": return gboard[20];
                case "g1": return gboard[21];
                case "g4": return gboard[22];
                case "g7": return gboard[23];
                default: return "";
            }
        }
        public void Moving(string from,string to) //olmost like placing but have to check for available moves
        {
            if (BlankSpace(to))
            {
                if (pBlack.getCurrentState() == "moving")
                {
                    List<string> player1 = new List<string> { };
                    player1.Add(from);player1.Add(to);
                    player1Moves.Add(player1);
                }
              
                
                if (pWhite.getCurrentState() == "moving")
                {
                    List<string> player2 = new List<string> { };
                    player2.Add(from); player2.Add(to);
                    player2Moves.Add(player2);
                }
              
             }
        }
        }

}
