using System;
using System.Collections.Generic;
using System.Text;

namespace Morabaraba
{
    public class Player : IPlayer
    {
        private List<string> positions;
        private List<List<string>> milllist;
        private string whoseplaying;
        private int cows;
        private string currentstate;

        public Player(string whoseplaying)//takes the symbol of the player 
        {
            this.whoseplaying = whoseplaying;
            cows = 12;
            currentstate = "placing"; //initially
            positions = new List<string>();
            milllist = new List<List<string>>();


        }
        public void Addcow(string pos)
        {

             positions.Add(pos);
        }
        public void removePosition(string pos)
        {
            positions.Remove(pos);
        }
        public void AddMill(List <string> mill)
        {

            milllist.Add(mill);
        }
        public void removeMill(List<string> mill)
        {
            milllist.Remove(mill);
        }
        public void killingCow (string pos)
        {
            removePosition(pos);
            cows--;
        }
        public void updatingstate()
        {
            if (positions.Count == cows)
            {
                currentstate = "moving";
            }
            if (cows == 3)
            {
                currentstate = "flying";
            }
        }
        public void swapcurrentPlayer()
        {
            switch (whoseplaying)

            {
                case "black":
                    whoseplaying = "white";
                    return;
                case "white":
                    whoseplaying = "black";
                    return;
            }
        }
        public int cowsThere()
        {
            return cows;
        }
        public string WhoIsPlaying()
        {
            return whoseplaying;
        }
        public List<string> Positions ()
        {
            return positions;
        }
        public string getCurrentState()
        {
            return currentstate;
        }
    }
}
