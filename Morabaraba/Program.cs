using System;
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
            Board beginningboard = new Board();
            string[] coordinates = new string[] { "a1", "a4","a7","b2","b4","b6","c3","c4","c5","d1","d2","d3","d5","d6","d7","e3","e4", "e5","f2","f4","f6","g1","g4","g7" };
            beginningboard.printBoard(coordinates);
            Console.WriteLine("Hello, ready to play Morabaraba then just press enter");
            Console.ReadLine();
            IBoard board = new Board();
            IPlayer pWhite = new Player("white");
            IPlayer pBlack = new Player("black");
            Game startinggame = new Game(pWhite, pBlack, board);
            int cows = 0;
            while (cows < 13)
            {
                Console.WriteLine("{0}, please enter a valid cow position move",startinggame.getCurrentPlayerID());
                string position = Console.ReadLine();
                if (board.isitvalid(position))  //checks the read in input
                {
                    startinggame.AddPosition(position);
                    startinggame.changecurrentPlayerID(startinggame.getCurrentPlayerID());
                    cows++;
                }
                List<string> playerblackmoves = startinggame.ReturnPlayer1positions();
                List<string> playerwhitemoves = startinggame.ReturnPlayer2positions();
            }

            //place where restarting new game occurs
        }
    }
}


//    public class Board : BaseNotificationClass
//    {
//        private Cow[] _cows;

//        public Cow[] Cows
//        {
//            get { return _cows; }
//            set
//            {
//                _cows = value;
//                OnPropertyChanged(nameof(Cows));
//            }
//        }
//        public Mill[] Mills { get; set; }

//        private readonly Cow deadCow = new Cow();

//        public Board()
//        {
//            newCows();

//            Mills = CreateEmptyMills();
//        }

//        public void newCows()       //Used for restarting the game
//        {
//            Cows = new Cow[24];

//            for (int i = 0; i < 24; i++)
//                Cows[i] = new Cow(i, ' ', -1, -1);
//        }

//        #region Mill Functions

//        // Create empty array of empty mills
//    
//        }

//        public void updateMills(int playerID)
//        {
//            foreach (Mill mill in Mills)
//            {
//                if (mill.Id == playerID
//                    && mill.isNew) { mill.isNew = false; }
//            }
//        }

//        public bool areNewMills(int playerID)
//        {
//            foreach (Mill mill in Mills)
//            {
//                if (mill.Id == playerID && mill.isNew) { return true; }
//            }
//            return false;
//        }

//        public bool canPlace(int input, int playerID)
//        {
//            return !(Cows[input].Id == -1) || Cows[input].Id == switchPlayer(playerID);
//        }

//        public bool areInMill(int[] cows, int playerID)
//        {
//            return Cows[cows[0]].Id == playerID
//                && Cows[cows[1]].Id == playerID
//                && Cows[cows[2]].Id == playerID;
//        }


//        public void getCurrentMills(int playerID)
//        {
//            foreach (Mill mill in Mills)
//            {
//                if (areInMill(mill.Positions, playerID) && mill.Id != playerID)
//                {
//                    mill.isNew = true;
//                    mill.Id = playerID;
//                }
//            }
//        }

//        public void removeBrokenMills(int playerID)
//        {
//            foreach (Mill mill in Mills)
//            {
//                if (!areInMill(mill.Positions, playerID) && mill.Id == playerID)
//                {
//                    mill.isNew = false;
//                    mill.Id = -1;
//                }
//            }
//        }

//        #endregion

//        #region Cow Functions

//        // Get an empty cow at a given position (if empty at all)
//        public Cow Empty(int i)
//        {
//            if (i < 0 || 23 < i)
//                return null;

//            if (Cows[i].Id == -1)
//                return Cows[i];

//            else return null;
//        }

//        public bool InMill(int position, int playerID)
//        {
//            foreach (Mill a in Mills)
//            {
//                if (a.Positions[0] == position && a.Id != playerID && a.Id != -1 ||
//                    a.Positions[1] == position && a.Id != playerID && a.Id != -1 ||
//                    a.Positions[2] == position && a.Id != playerID && a.Id != -1)
//                { return true; }
//            }
//            return false;
//        }

//        // Returns true if there is a cow which is not in a mill
//        public bool cowNotInMill(int playerId)
//        {
//            foreach (Cow a in Cows)
//            {
//                if (a.Id == playerId && !InMill(a.Position, playerId))
//                    return true;
//            }
//            return false;
//        }


//        public bool OnlyMill(int position, int playerID)
//        {
//            int count = 0;
//            playerID = switchPlayer(playerID);
//            foreach (Mill a in Mills)
//            {
//                if (a.Id == playerID)
//                    count++;
//            }

//            return count <= 1;
//        }

//        public bool canKill(int position, int playerID)
//        {
//            if (position < 0)
//                return false;
//            if (InMill(position, playerID) && cowNotInMill(playerID))
//                return false;
//            if (Cows[position].Id == playerID
//                || Cows[position].Id == -1) { return false; }
//            return true;
//        }

//        public void placeCow(int playerID, int input, int cowNumber)
//        {
//            Cow newCow = new Cow(input, getPlayerChar(playerID), cowNumber, playerID);
//            Cows[input] = newCow;
//        }

//        public bool isFullBoard()
//        {
//            for (int i = 0; i < 24; i++)
//            {
//                if (Cows[i].Id == -1)
//                    return false;
//                else if (i == 23)
//                    return true;
//            }
//            return false; // Should never be reached
//        }

//        #endregion

//        #region Input Functions
//        // Get Board coordinate from user input
//        public string converToBoardPos(string input)
//        {
//            switch (input.ToLower())
//            {
//                case "a1": return 0;
//                case "a4": return 1;
//                case "a7": return 2;
//                case "b2": return 3;
//                case "b4": return 4;
//                case "b6": return 5;
//                case "c3": return 6;
//                case "c4": return 7;
//                case "c5": return 8;
//                case "d1": return 9;
//                case "d2": return 10;
//                case "d3": return 11;
//                case "d5": return 12;
//                case "d6": return 13;
//                case "d7": return 14;
//                case "e3": return 15;
//                case "e4": return 16;
//                case "e5": return 17;
//                case "f2": return 18;
//                case "f4": return 19;
//                case "f6": return 20;
//                case "g1": return 21;
//                case "g4": return 22;
//                case "g7": return 23;
//                default: return -1;
//            }
//        }

//        // Positions a cow can move from at a position
//        public bool isValidMove(int pos, int newPos)
//        {
//            switch (pos)
//            {
//                case 0:
//                    if (newPos == 1 || newPos == 3 || newPos == 9) { return true; }
//                    break;
//                case 1:
//                    if (newPos == 0 || newPos == 2 || newPos == 4) { return true; }
//                    break;
//                case 2:
//                    if (newPos == 1 || newPos == 5 || newPos == 14) { return true; }
//                    break;
//                case 3:
//                    if (newPos == 0 || newPos == 4 || newPos == 6 || newPos == 10) { return true; }
//                    break;
//                case 4:
//                    if (newPos == 1 || newPos == 3 || newPos == 5 || newPos == 7) { return true; }
//                    break;
//                case 5:
//                    if (newPos == 2 || newPos == 4 || newPos == 8 || newPos == 13) { return true; }
//                    break;
//                case 6:
//                    if (newPos == 4 || newPos == 7 || newPos == 11) { return true; }
//                    break;
//                case 7:
//                    if (newPos == 4 || newPos == 6 || newPos == 8) { return true; }
//                    break;
//                case 8:
//                    if (newPos == 5 || newPos == 7 || newPos == 12) { return true; }
//                    break;
//                case 9:
//                    if (newPos == 0 || newPos == 10 || newPos == 21) { return true; }
//                    break;
//                case 10:
//                    if (newPos == 3 || newPos == 9 || newPos == 11 || newPos == 18) { return true; }
//                    break;
//                case 11:
//                    if (newPos == 6 || newPos == 10 || newPos == 15) { return true; }
//                    break;
//                case 12:
//                    if (newPos == 8 || newPos == 13 || newPos == 17) { return true; }
//                    break;
//                case 13:
//                    if (newPos == 5 || newPos == 12 || newPos == 14 || newPos == 20) { return true; }
//                    break;
//                case 14:
//                    if (newPos == 2 || newPos == 13 || newPos == 23) { return true; }
//                    break;
//                case 15:
//                    if (newPos == 11 || newPos == 16 || newPos == 18) { return true; }
//                    break;
//                case 16:
//                    if (newPos == 15 || newPos == 17 || newPos == 19) { return true; }
//                    break;
//                case 17:
//                    if (newPos == 12 || newPos == 16 || newPos == 20) { return true; }
//                    break;
//                case 18:
//                    if (newPos == 10 || newPos == 15 || newPos == 19 || newPos == 21) { return true; }
//                    break;
//                case 19:
//                    if (newPos == 16 || newPos == 18 || newPos == 20 || newPos == 22) { return true; }
//                    break;
//                case 20:
//                    if (newPos == 13 || newPos == 17 || newPos == 19 || newPos == 23) { return true; }
//                    break;
//                case 21:
//                    if (newPos == 9 || newPos == 18 || newPos == 22) { return true; }
//                    break;
//                case 22:
//                    if (newPos == 19 || newPos == 21 || newPos == 23) { return true; }
//                    break;
//                case 23:
//                    if (newPos == 14 || newPos == 20 || newPos == 22) { return true; }
//                    break;
//                default:
//                    return false;
//            }
//            return false;
//        }

//        #endregion

//        #region player Functions
//        public char getPlayerChar(int playerID)
//        {
//            if (playerID == 0) { return 'R'; }
//            else return 'B';
//        }
//        public int switchPlayer(int playerID)
//        {
//            if (playerID == 0) { return 1; }
//            else return 0;
//        }

//        public int numCowsLeft(int playerID)
//        {
//            int count = 0;
//            foreach (Cow a in Cows)
//            {
//                if (a.Id == playerID)
//                    count++;
//            }
//            return count;
//        }
//        #endregion


//    }


//    public class GameSession : BaseNotificationClass
//    {
//        private State currentState;
//        private string _gameMessage;
//        private string buttonContent;
//        private int playerID;
//        private int placeNum;
//        private int movePos;
//        private string player1Cows;
//        private string player2Cows;
//        private bool isPlacing;

//        public string currentInput { get; set; }
//        public Board board { get; set; }
//        public string GameMessage
//        {
//            get { return _gameMessage; }
//            set
//            {
//                _gameMessage = value;
//                OnPropertyChanged(nameof(GameMessage));
//            }
//        }
//        public string ButtonContent
//        {
//            get { return buttonContent; }
//            set
//            {
//                buttonContent = value;
//                OnPropertyChanged(nameof(ButtonContent));
//            }
//        }
//        public string Player1Cows
//        {
//            get { return player1Cows; }
//            set
//            {
//                player1Cows = value;
//                OnPropertyChanged(nameof(Player1Cows));
//            }
//        }
//        public string Player2Cows
//        {
//            get { return player2Cows; }
//            set
//            {
//                player2Cows = value;
//                OnPropertyChanged(nameof(Player2Cows));
//            }
//        }
//        public bool IsPlacing
//        {
//            get { return isPlacing; }
//            set
//            {
//                isPlacing = value;
//                OnPropertyChanged(nameof(isPlacing));
//            }
//        }

//        public GameSession()
//        {
//            board = new Board();
//            board.CreateEmptyMills();
//            currentState = State.Placing;
//            placeNum = 0;
//            playerID = 0;
//            movePos = -1;
//            GameMessage = "Player 1 : Placing";
//            ButtonContent = "Place Cow";
//            Player1Cows = "12";
//            Player2Cows = "12";
//            IsPlacing = true;

//        }

//        private enum State
//        {
//            Placing,
//            Killing,
//            Moving1,
//            Moving2,
//            End
//        }

//        #region Phase 1 (Placing and Killing Cows

//        // Place cows on board (Phase 1)

//        private void placeCow()
//        {

//            if (placeNum < 24)
//            {
//                int input = board.converToBoardPos(currentInput);
//                if (input == -1)
//                {
//                    GameMessage = "Incorrect input!";
//                    return;
//                }
//                if (board.canPlace(input, playerID))
//                {
//                    GameMessage = "Cannot place there!";
//                    return;
//                }

//                else
//                {
//                    board.updateMills(playerID);

//                    board.placeCow(playerID, input, placeNum);
//                    board.removeBrokenMills(playerID);

//                    OnPropertyChanged(nameof(board));

//                    board.getCurrentMills(playerID);

//                    updatePlayerCows(playerID);

//                    if (board.areNewMills(playerID))
//                    {
//                        currentState = State.Killing;
//                        GameMessage = $"Player {playerID + 1} : Killing";
//                        return;
//                    }

//                    playerID = board.switchPlayer(playerID);

//                    if (placeNum == 23)
//                    {
//                        currentState = State.Moving1;
//                        GameMessage = $"Player {playerID + 1}: Moving";
//                        hidePlacingBar();
//                        return;
//                    }

//                    GameMessage = $"Player {playerID + 1} : Placing";
//                    placeNum++;
//                }
//            }
//        }

//        #endregion

//        #region Phase 2 (Move Cows)

//        private void killCow()
//        {
//            int input = board.converToBoardPos(currentInput);

//            if (!board.canKill(input, playerID))
//            {
//                GameMessage = "Can't kill that one!";
//            }

//            else
//            {
//                board.Cows[input] = new Cow(input, ' ', -1, -1); // Put empty cow at crime scene                

//                OnPropertyChanged(nameof(board));

//                if (placeNum < 23)
//                {
//                    currentState = State.Placing;
//                    playerID = board.switchPlayer(playerID);
//                    GameMessage = $"Player {playerID + 1}: Placing";
//                    placeNum++;
//                }
//                else
//                {
//                    currentState = State.Moving1;
//                    playerID = board.switchPlayer(playerID);
//                    GameMessage = $"Player {playerID + 1}: Moving";
//                }

//                // Check win condition
//                if (ownedCows(playerID) <= 2 && currentState == State.Moving1)
//                {
//                    currentState = State.End;
//                    playerID = board.switchPlayer(playerID);
//                    GameMessage = $"Player {playerID + 1} wins!";
//                }
//            }
//        }

//        //For Board.cs: Get number of cows owned by player

//        private int ownedCows(int playerID)
//        {
//            if (playerID < -1 || playerID > 1)
//                return -1;

//            else
//            {
//                int count = 0;
//                for (int i = 0; i < board.Cows.Length; i++)
//                {
//                    if (board.Cows[i].Id == playerID)
//                        count++;
//                }

//                return count;
//            }
//        }

//        private void moveCow()
//        {
//            if (currentState == State.Moving1)
//            {
//                movePos = board.converToBoardPos(currentInput);

//                if (movePos == -1 || board.Cows[movePos].Id != playerID)
//                {
//                    GameMessage = "Invalid choice!";
//                    return;
//                }
//                else
//                {
//                    GameMessage = "Now select where you want to move";
//                    currentState = State.Moving2;
//                }
//            }
//            else
//            {
//                int newPos = board.converToBoardPos(currentInput);

//                if (newPos == -1 || board.Cows[newPos].Id != -1)
//                {
//                    GameMessage = "Invalid move!";
//                    return;
//                }

//                if (!board.isValidMove(movePos, newPos) && ownedCows(playerID) > 3) // Check if it is a valid move and if it is in flying mode
//                {
//                    GameMessage = "Invalid move!";
//                    return;
//                }

//                board.updateMills(playerID);

//                board.placeCow(playerID, newPos, board.Cows[movePos].CowNumber); // Place cow at new position
//                board.Cows[movePos] = new Cow(movePos, ' ', -1, -1); // Put empty cow at original place

//                board.removeBrokenMills(playerID);

//                OnPropertyChanged(nameof(board));

//                board.getCurrentMills(playerID);

//                if (board.areNewMills(playerID))
//                {
//                    currentState = State.Killing;
//                    GameMessage = $"Player {playerID + 1} : Killing";
//                    return;
//                }

//                playerID = board.switchPlayer(playerID);
//                GameMessage = $"Player {playerID + 1} : Moving";
//                currentState = State.Moving1;

//            }

//        }

//        #endregion

//        #region Gui update functions

//        private void updateButtonContent()
//        {
//            switch (currentState)
//            {
//                case State.Placing:
//                    ButtonContent = "Place Cow";
//                    break;

//                case State.Killing:
//                    ButtonContent = "Kill Cow";
//                    break;

//                case State.Moving1:
//                    ButtonContent = "Choose Cow";
//                    break;
//                case State.Moving2:
//                    ButtonContent = "Place Cow";
//                    break;

//                case State.End:
//                    ButtonContent = "GAME OVER";
//                    break;
//            }
//        }
//        private void updatePlayerCows(int playerID)
//        {
//            if (playerID == 0)
//            {
//                Player1Cows = Convert.ToString((Convert.ToInt32(player1Cows) - 1));
//            }
//            else Player2Cows = Convert.ToString((Convert.ToInt32(player2Cows) - 1));
//        }

//        private void hidePlacingBar()
//        {
//            IsPlacing = false;
//        }

//        #endregion

//        // Preform action depending on state of program
//        public void performAction()
//        {
//            switch (currentState)
//            {
//                case State.Placing:
//                    placeCow();
//                    updateButtonContent();
//                    break;

//                case State.Killing:
//                    killCow();
//                    updateButtonContent();
//                    break;

//                case State.Moving1:
//                case State.Moving2:
//                    moveCow();
//                    updateButtonContent();
//                    break;

//                case State.End:
//                    //Do nothing
//                    updateButtonContent();
//                    break;
//            }
//        }
//    }

//    public class Mill
//    {
//        public bool isNew { get; set; }
//        public int Id { get; set; }

//        public int[] Positions { get; set; }

//        public Mill(int[] Positions, int Id = -1)
//        {
//            this.Positions = Positions;
//            isNew = false;
//            this.Id = Id;
//        }
//    }

//}
