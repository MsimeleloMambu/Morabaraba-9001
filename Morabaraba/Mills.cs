using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Morabaraba
{
    public class Mills
    {
        public List<string> MillList { get; private set; }



        public bool isNew { get; set; }
        public int Id { get; set; }

        public int[] Positions { get; set; }

        public Mill(int[] Positions, int Id = -1)
        {
            this.Positions = Positions;
            isNew = false;
            this.Id = Id;
            
        }

        //Create empty array of empty mills
        public Mill[] CreateEmptyMills()
        {
            return new Mill[]
            {
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

        public void UpdateMills(int playerID)
        {
            foreach (Mill mill in Mills)
            {
                if (mill.Id == playerID
                    && mill.isNew) { mill.isNew = false; }
            }
        }

        public bool AreNewMills(int playerID)
        {
            foreach (Mill mill in Mills)
            {
                if (mill.Id == playerID && mill.isNew) { return true; }
            }
            return false;
        }

        public bool AreInMill(int[] cows, int playerID)
        {
            return Cows[cows[0]].Id == playerID
                && Cows[cows[1]].Id == playerID
                && Cows[cows[2]].Id == playerID;
        }

        public void GetCurrentMills(int playerID)
        {
            foreach (Mill mill in Mills)
            {
                if (AreInMill(mill.Positions, playerID) && mill.Id != playerID)
                {
                    mill.isNew = true;
                    mill.Id = playerID;
                }
            }
        }
    }
}
