﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Morabaraba
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class BaseNotificationClass : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class Board : BaseNotificationClass
    {
        private Cow[] _cows;

        public Cow[] Cows
        {
            get { return _cows; }
            set
            {
                _cows = value;
                OnPropertyChanged(nameof(Cows));
            }
        }
        public Mill[] Mills { get; set; }

        private readonly Cow deadCow = new Cow();

        public Board()
        {
            newCows();

            Mills = CreateEmptyMills();
        }

        public void newCows()       //Used for restarting the game
        {
            Cows = new Cow[24];

            for (int i = 0; i < 24; i++)
                Cows[i] = new Cow(i, ' ', -1, -1);
        }

        #region Mill Functions

        // Create empty array of empty mills
        public Mill[] CreateEmptyMills()
        {
            return new Mill[] {
                new Mill(new int[] { 0, 1, 2 }),        // A1, A4, A7
                new Mill(new int[] { 3, 4, 5 } ),       // B2, B4, B6
                new Mill(new int[] { 6, 7, 8 }),        // C3, C4, C5
                new Mill(new int[] { 9, 10, 11 }),      // D1, D2, D3
                new Mill(new int[] { 12, 13, 14 }),     // D5, D6, D7
                new Mill(new int[] { 15, 16, 17 }),     // E3, E4, E5
                new Mill(new int[] { 18, 19, 20 }),     // F2, F4, F6
                new Mill(new int[] { 21, 22, 23 }),     // G1, G4, G7
                new Mill(new int[] { 0, 9, 21 }),       // A1, D1, G1
                new Mill(new int[] { 3, 10, 18 }),      // B2, D2, F2
                new Mill(new int[] { 6, 11, 15 }),      // C3, D3, E3
                new Mill(new int[] { 1, 4, 7 }),        // A4, B4, C4
                new Mill(new int[] { 16, 19, 22 }),     // E4, F4, G4
                new Mill(new int[] { 8, 12, 17 }),      // C5, D5, E5
                new Mill(new int[] { 5, 13, 20 }),      // B6, D6, F6
                new Mill(new int[] { 2, 14, 23 }),      // A7, D7, G7
                new Mill(new int[] { 0, 3, 6 }),        // A1, B2, C3
                new Mill(new int[] { 15, 18, 21 }),     // E3, F2, G1
                new Mill(new int[] { 2, 5, 8 }),        // C5, B6, A7
                new Mill(new int[] { 17, 20, 23 })      // E5, F6, G7
            };
        }

        public void updateMills(int playerID)
        {
            foreach (Mill mill in Mills)
            {
                if (mill.Id == playerID
                    && mill.isNew) { mill.isNew = false; }
            }
        }

        public bool areNewMills(int playerID)
        {
            foreach (Mill mill in Mills)
            {
                if (mill.Id == playerID && mill.isNew) { return true; }
            }
            return false;
        }

        public bool canPlace(int input, int playerID)
        {
            return !(Cows[input].Id == -1) || Cows[input].Id == switchPlayer(playerID);
        }

        public bool areInMill(int[] cows, int playerID)
        {
            return Cows[cows[0]].Id == playerID
                && Cows[cows[1]].Id == playerID
                && Cows[cows[2]].Id == playerID;
        }


        public void getCurrentMills(int playerID)
        {
            foreach (Mill mill in Mills)
            {
                if (areInMill(mill.Positions, playerID) && mill.Id != playerID)
                {
                    mill.isNew = true;
                    mill.Id = playerID;
                }
            }
        }

        public void removeBrokenMills(int playerID)
        {
            foreach (Mill mill in Mills)
            {
                if (!areInMill(mill.Positions, playerID) && mill.Id == playerID)
                {
                    mill.isNew = false;
                    mill.Id = -1;
                }
            }
        }

        #endregion

        #region Cow Functions

        // Get an empty cow at a given position (if empty at all)
        public Cow Empty(int i)
        {
            if (i < 0 || 23 < i)
                return null;

            if (Cows[i].Id == -1)
                return Cows[i];

            else return null;
        }

        public bool InMill(int position, int playerID)
        {
            foreach (Mill a in Mills)
            {
                if (a.Positions[0] == position && a.Id != playerID && a.Id != -1 ||
                    a.Positions[1] == position && a.Id != playerID && a.Id != -1 ||
                    a.Positions[2] == position && a.Id != playerID && a.Id != -1)
                { return true; }
            }
            return false;
        }

        // Returns true if there is a cow which is not in a mill
        public bool cowNotInMill(int playerId)
        {
            foreach (Cow a in Cows)
            {
                if (a.Id == playerId && !InMill(a.Position, playerId))
                    return true;
            }
            return false;
        }


        public bool OnlyMill(int position, int playerID)
        {
            int count = 0;
            playerID = switchPlayer(playerID);
            foreach (Mill a in Mills)
            {
                if (a.Id == playerID)
                    count++;
            }

            return count <= 1;
        }

        public bool canKill(int position, int playerID)
        {
            if (position < 0)
                return false;
            if (InMill(position, playerID) && cowNotInMill(playerID))
                return false;
            if (Cows[position].Id == playerID
                || Cows[position].Id == -1) { return false; }
            return true;
        }

        public void placeCow(int playerID, int input, int cowNumber)
        {
            Cow newCow = new Cow(input, getPlayerChar(playerID), cowNumber, playerID);
            Cows[input] = newCow;
        }

        public bool isFullBoard()
        {
            for (int i = 0; i < 24; i++)
            {
                if (Cows[i].Id == -1)
                    return false;
                else if (i == 23)
                    return true;
            }
            return false; // Should never be reached
        }

        #endregion

        #region Input Functions
        // Get Board coordinate from user input
        public int converToBoardPos(string input)
        {
            switch (input.ToLower())
            {
                case "a1": return 0;
                case "a4": return 1;
                case "a7": return 2;
                case "b2": return 3;
                case "b4": return 4;
                case "b6": return 5;
                case "c3": return 6;
                case "c4": return 7;
                case "c5": return 8;
                case "d1": return 9;
                case "d2": return 10;
                case "d3": return 11;
                case "d5": return 12;
                case "d6": return 13;
                case "d7": return 14;
                case "e3": return 15;
                case "e4": return 16;
                case "e5": return 17;
                case "f2": return 18;
                case "f4": return 19;
                case "f6": return 20;
                case "g1": return 21;
                case "g4": return 22;
                case "g7": return 23;
                default: return -1;
            }
        }

        // Positions a cow can move from at a position
        public bool isValidMove(int pos, int newPos)
        {
            switch (pos)
            {
                case 0:
                    if (newPos == 1 || newPos == 3 || newPos == 9) { return true; }
                    break;
                case 1:
                    if (newPos == 0 || newPos == 2 || newPos == 4) { return true; }
                    break;
                case 2:
                    if (newPos == 1 || newPos == 5 || newPos == 14) { return true; }
                    break;
                case 3:
                    if (newPos == 0 || newPos == 4 || newPos == 6 || newPos == 10) { return true; }
                    break;
                case 4:
                    if (newPos == 1 || newPos == 3 || newPos == 5 || newPos == 7) { return true; }
                    break;
                case 5:
                    if (newPos == 2 || newPos == 4 || newPos == 8 || newPos == 13) { return true; }
                    break;
                case 6:
                    if (newPos == 4 || newPos == 7 || newPos == 11) { return true; }
                    break;
                case 7:
                    if (newPos == 4 || newPos == 6 || newPos == 8) { return true; }
                    break;
                case 8:
                    if (newPos == 5 || newPos == 7 || newPos == 12) { return true; }
                    break;
                case 9:
                    if (newPos == 0 || newPos == 10 || newPos == 21) { return true; }
                    break;
                case 10:
                    if (newPos == 3 || newPos == 9 || newPos == 11 || newPos == 18) { return true; }
                    break;
                case 11:
                    if (newPos == 6 || newPos == 10 || newPos == 15) { return true; }
                    break;
                case 12:
                    if (newPos == 8 || newPos == 13 || newPos == 17) { return true; }
                    break;
                case 13:
                    if (newPos == 5 || newPos == 12 || newPos == 14 || newPos == 20) { return true; }
                    break;
                case 14:
                    if (newPos == 2 || newPos == 13 || newPos == 23) { return true; }
                    break;
                case 15:
                    if (newPos == 11 || newPos == 16 || newPos == 18) { return true; }
                    break;
                case 16:
                    if (newPos == 15 || newPos == 17 || newPos == 19) { return true; }
                    break;
                case 17:
                    if (newPos == 12 || newPos == 16 || newPos == 20) { return true; }
                    break;
                case 18:
                    if (newPos == 10 || newPos == 15 || newPos == 19 || newPos == 21) { return true; }
                    break;
                case 19:
                    if (newPos == 16 || newPos == 18 || newPos == 20 || newPos == 22) { return true; }
                    break;
                case 20:
                    if (newPos == 13 || newPos == 17 || newPos == 19 || newPos == 23) { return true; }
                    break;
                case 21:
                    if (newPos == 9 || newPos == 18 || newPos == 22) { return true; }
                    break;
                case 22:
                    if (newPos == 19 || newPos == 21 || newPos == 23) { return true; }
                    break;
                case 23:
                    if (newPos == 14 || newPos == 20 || newPos == 22) { return true; }
                    break;
                default:
                    return false;
            }
            return false;
        }

        #endregion

        #region player Functions
        public char getPlayerChar(int playerID)
        {
            if (playerID == 0) { return 'R'; }
            else return 'B';
        }
        public int switchPlayer(int playerID)
        {
            if (playerID == 0) { return 1; }
            else return 0;
        }

        public int numCowsLeft(int playerID)
        {
            int count = 0;
            foreach (Cow a in Cows)
            {
                if (a.Id == playerID)
                    count++;
            }
            return count;
        }
        #endregion


    }
}
