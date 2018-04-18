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
            Game game = new Game();
            string who = game.getCurrentPlayerID();
            Assert.AreSame("black", who);
        }
        [Test]
        public void CowsPlacedOnEmptySpaces()
        {
            Game game = new Game();
            game.Placement("a1");



            Assert.False(game.BlankSpace("a1"));

        }
        [Test]
        public void Amaxof12Placementsperplayerareallowed()
        {
            //Sakhele

            Game game = new Game();

            game.Placement("d5");

            game.Placement("d6");

            game.Placement("d7");

            game.Placement("e3");

            game.Placement("e4");

            game.Placement("e5");

            game.Placement("f2");

            game.Placement("f4");

            game.Placement("f6");

            game.Placement("g1");

            game.Placement("g4");
            game.Placement("g7");

            game.Placement("d3");
            game.Placement("a4"); //nomatter howmany you add  it will still be 12

            Assert.AreEqual(game.getplaceNumBlack(), 12);

        }
        [Test]
        public void NomovementduringPlacement()
        {

            Game game = new Game();

            game.Placement("d5");

            game.Placement("d6");

            game.Placement("d7");

            game.Placement("e3");

            game.Placement("e4");

            game.Placement("e5");

            game.Placement("f2");

            game.Placement("f4");

            game.Placement("f6");

            game.Placement("g1");

            game.Placement("g4");



            game.swapcurrentPlayer();

            game.Placement("a1");

            game.Placement("a4");

            game.Placement("a7");

            game.Placement("b2");

            game.Placement("b4");

            game.Placement("b6");

            game.Placement("c3");

            game.Placement("c4");

            game.Placement("c5");

            game.Placement("d1");

            game.Placement("d2");

            game.Moving("a1", "g7");
            List<List<string>> a = game.player1CheckMoves();
            

            Assert.AreSame(a,null);//meaning its empty

        }
       
        
    }
}
