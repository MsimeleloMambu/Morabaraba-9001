using System;
using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;

namespace Morabaraba.Test
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void testIsBoardEmpty()
        {
            // Arrange-Act-Assert
            IBoard checkboard = new Board();
            string[] myboard = checkboard.getBoardlist();
            int check = 0;
            for (int i = 0; i < 24; i++)
            {
                if (myboard[i] == " ")
                {
                    check++;
                }
            }
            Assert.That(check == 24);

        }
        [Test]
        public void testBlackgetsFirstChance()
        {
            IPlayer p1 = new Player("black");
            IPlayer p2 = new Player("White");
            IBoard board = new Board();
            Game game = new Game(p2, p1, board);
            string who = game.getCurrentPlayerID();
            Assert.AreSame("black", who);
        }
        [Test]
        public void CowsPlacedOnEmptySpaces()
        {
            IPlayer p1 = new Player("black");
            IPlayer p2 = new Player("White");
            IBoard board = new Board();
            Game game = new Game(p2,p1,board);
            game.AddPosition("a1");
            p1.swapcurrentPlayer();
            game.AddPosition("a1");

            Assert.That(game.getComment()=="position is not valid,it is either occupied or incorrect");

        }
        [Test]
        public void Amaxof12Placementsperplayerareallowed()
        {

            IPlayer p1 = new Player("black");
            IPlayer p2 = new Player("White");
            IBoard board = new Board();
            Game game = new Game(p2, p1, board);
            game.AddPosition("d5");

            game.AddPosition("d6");

            game.AddPosition("d7");

            game.AddPosition("e3");

            game.AddPosition("e4");

            game.AddPosition("e5");

            game.AddPosition("f2");

            game.AddPosition("f4");

            game.AddPosition("f6");

            game.AddPosition("g1");

            game.AddPosition("g4");
            game.AddPosition("g7");

            game.AddPosition("d3");
            game.AddPosition("a4"); //nomatter howmany you add  it will still be 12

            Assert.AreEqual(game.getplaceNumBlack(), 12);

        }
        [Test]
        public void NomovementduringPlacement()
        {

            IPlayer p1 = new Player("black");
            IPlayer p2 = new Player("White");
            IBoard board = new Board();
            Game game = new Game(p2, p1, board);
            game.AddPosition("d5");

            game.AddPosition("d6");

            game.AddPosition("d7");

            game.AddPosition("e3");

            game.AddPosition("e4");

            game.AddPosition("e5");

            game.AddPosition("f2");

            game.AddPosition("f4");

            game.AddPosition("f6");

            game.AddPosition("g1");

            game.AddPosition("g4");


            game.Moving("a1", "g7");
            List<List<string>> a = game.player1CheckMoves();
            

            Assert.AreSame(a,null);//meaning its empty

        }
        [Test]
        public void CowscanMoveToConnectedSpace()
        {
            IPlayer p1 = new Player("black");
            IPlayer p2 = new Player("White");
            IBoard board = new Board();
            Game game = new Game(p2, p1, board);

            game.Moving("a1", "b2");
            game.Moving("e3", "e5");
           

            List<string> connectedtoa1 = new List<string> { "a4", "b2", "d1" };
            List<string> connectedtoe3 = new List<string> { "d3", "e4", "f2" };

            Assert.AreEqual(connectedtoa1, game.acceptable("a1"));
            Assert.AreEqual(connectedtoe3, game.acceptable("e3"));
           
        }
        [Test]
        public void CowscanOnlyMoveToAnEmptySpace()
        {
            IPlayer p1 = new Player("black");
            IPlayer p2 = new Player("White");
            IBoard board = new Board();
            Game game = new Game(p2, p1, board);
            game.AddPosition("a1");
            game.Moving("a7", "a1");
            Assert.That(game.getComment() == "The position to is not blank");

        }
        [Test]
       public void MovinfdoesnoticreaseordecreasetheNUmOFCows()
        {
            IPlayer p1 = new Player("black");
            IPlayer p2 = new Player("White");
            IBoard board = new Board();
            Game game = new Game(p2, p1, board);

            game.AddPosition("a1");

            game.AddPosition("a4");

            game.AddPosition("a7");

            game.AddPosition("b2");

            game.AddPosition("b4");

            game.AddPosition("b6");

            game.AddPosition("c3");

            game.AddPosition("c4");

            game.AddPosition("c5");

            game.AddPosition("d1");
            game.AddPosition("d7");
            game.AddPosition("d2");

            

            game.Moving("a1", "b2");
            game.Moving("d3", "d2");
           
            
            Assert.AreEqual(game.getCows(), 12);
           

        }
       [Test]
       public void CowsCanMoveToAnyEmptySpaceIfOnlyThreeCowsofThatColourRemain()
        {



        }

        [Test]
        public void MillisFormedbyThreeCowsIfOnlyTheSameColour()
        {
            IPlayer p1 = new Player("black");
            IPlayer p2 = new Player("White");
            IBoard board = new Board();
            Game game = new Game(p2, p1, board);
            int [] testingmill = new int[] { 0, 1, 2 };
            
            //Assert.That(areInMill(testingmill,p1)==true);


        }
        [Test]
        public void MillisNotFormedWhenCowsAreDifferentColours () //bool reference mill class
        {


        }

        [Test]
        public void MillisNotFormedDuetoLackofFormation()  //bool reference mill class
        {


        }

        [Test]
        public void PossibleShootingAfterMillCompletion()   //bool reference mill class
        {


        }

        [Test]
        public void PlayerCannotShootTheirOwnCows()   //bool reference referee class
        {


        }
    }
}
