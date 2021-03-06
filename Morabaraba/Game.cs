﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Morabaraba
{
    public class Game       //Game class is responsible for facilitating the implementation of the game.
    {
        
        public string currentplayerID { get; private set; }
        private int placeNumBlack;
        private int placeNumWhite;
        private int cowsthatExist;
        public List<List<string>> player1Moves { get; private set; }
        public List<List<string>> player2Moves { get; private set; }
        String comment;
        private IPlayer pWhite;
        private IPlayer pBlack;
        private IBoard Board;

        public Game(IPlayer pW, IPlayer pB, IBoard b)
        {
            currentplayerID = "black";//start with black
            placeNumBlack = 0;
            placeNumWhite = 0;
            cowsthatExist = 0;
            this.player1Moves= player1Moves;
            this.player2Moves = player2Moves;
            comment = "";
            Board = b;
            pBlack = pB;
            pWhite = pW;
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
        public string getComment()
        {
            return comment;
        }
     
        public string getCurrentPlayerID()
        {
            return currentplayerID;
        }

        public string changecurrentPlayerID(string player)
        {
            if(player== "black")
            {
                pBlack.swapcurrentPlayer();
                return currentplayerID = pBlack.WhoIsPlaying();
            }
            pWhite.swapcurrentPlayer();
            return currentplayerID = pWhite.WhoIsPlaying();
        }
        public void AddPosition(string Position)

        {
            if (BlankSpace(Position) == true)
            {
                if (currentplayerID == "black" && placeNumBlack < 12 )
                {

                    if (pBlack.getCurrentState() == "placing")
                    {
                        Board.updateMoveBoard(currentplayerID, Position);
                        placeNumBlack++;
                        pBlack.Addcow(Position);
                        pBlack.updatingstate();
                        cowsthatExist++;
                    }


                }


                if (currentplayerID == "white" && placeNumBlack < 12)
                {
                    if (pWhite.getCurrentState() == "placing")
                    {
                        Board.updateMoveBoard(currentplayerID, Position);
                        placeNumWhite++;
                        pWhite.Addcow(Position);
                        pWhite.updatingstate();
                        cowsthatExist++;
                    }
                }

            }
            else
            {
                comment = "position is not valid,it is either occupied or incorrect";
                Console.WriteLine(comment);
            }

        }

        public void removePosition(string position)
        {
            if (BlankSpace(position) == false)
            {
                cowsthatExist--;
            }
            else
            {
                comment = "There is no cow there";
                Console.WriteLine(comment);
            }
        }


        public List<string> ReturnPlayer1positions()
        {
            return pBlack.Positions();
        }

        public List<string> ReturnPlayer2positions()
        {
            return pWhite.Positions();
        }
        public bool BlankSpace(string position)
        {
            return (getPieceAtPosition(position) == " ");
           
               
           
        }
        public int getCows()
        {
            return cowsthatExist;
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
                if (pBlack.getCurrentState() == "moving"&&currentplayerID=="black")
                {
                    
                    Board.updateMoveOnToBoard(from);
                    Board.updateMoveBoard(currentplayerID, to);
                    List<string> player1 = new List<string> { };
                    player1.Add(from);player1.Add(to);
                    player1Moves.Add(player1);
                }
              
                
                if (pWhite.getCurrentState() == "moving"&& currentplayerID == "white")
                {
                   

                    Board.updateMoveOnToBoard(from);
                    Board.updateMoveBoard(currentplayerID, to);
                    List<string> player2 = new List<string> { };
                    player2.Add(from); player2.Add(to);
                    player2Moves.Add(player2);
                }
              
             }
            else
            {
                comment = "The position to is not blank";
            }
        }
        public List<string>acceptable(string position)
        {
            switch (position)
            {
                case "a1": return new List<string>{ "a4", "b2", "d1" };
                case "a4": return new List<string> { "a1", "a7", "b4" };
                case "a7": return new List<string> { "a4", "b6", "d7" };
                case "b2": return new List<string> { "a1", "c3", "B4", "D2" };
                case "b4": return new List<string> { "b2", "a4", "c4", "d6" };
                case "b6": return new List<string> { "a7", "b4", "c5", "d7" };
                case "c3": return new List<string> { "b2", "c4", "d3" };
                case "c4": return new List<string> { "c3", "b4", "c5" };
                case "c5": return new List<string> { "c4", "b6", "d5" };
                case "d1": return new List<string> { "a1", "d2", "g1" };
                case "d2": return new List<string> { "b2", "d1", "d3", "f2" };
                case "d3": return new List<string> { "c3", "d2", "e3" };
                case "d5": return new List<string> { "c5", "d6", "e5" };
                case "d6": return new List<string> { "d5", "b6", "d7", "f6" };
                case "d7": return new List<string> { "a7", "d6", "g7" };
                case "e3": return new List<string> { "d3", "e4", "f2" };
                case "e4": return new List<string> { "f4", "e3", "e5" };
                case "e5": return new List<string> { "d5", "e4", "f6" };
                case "f2": return new List<string> { "g1", "e3", "f4", "d2" };
                case "f4": return new List<string> { "e4", "f6", "g4", "f2" };
                case "f6": return new List<string> { "g7", "d6", "f4", "e5" };
                case "g1": return new List<string> { "g1", "e3", "f4", "d2" };
                case "g4": return new List<string> { "e4", "f6", "g4", "f2" };
                case "g7": return new List<string> { "g7", "d6", "f4", "e5" };
            }
            return null;
        }


    }

}
