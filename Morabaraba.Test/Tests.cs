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
            string [] myboard = checkboard.getBoardlist();
            int check = 0;
            for (int i = 0; i < 24; i++)
            {
                if(myboard[i] == " ")
                {
                    check++;
                }
            }
            Assert.That(check == 24);

        }
    }
}
