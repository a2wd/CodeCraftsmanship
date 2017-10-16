namespace Week3.TicTacToe.Tests
{
    using System;
    using System.Linq;
    using NUnit.Framework;

    [TestFixture]
    public class BoardShould
    {
        [Test]
        public void ReturnABoardObject()
        {
            var result = new Board();

            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void InitialiseA3By3BoardWithEmptyCells()
        {
            var board = new Board();

            for (int cellIndex = 0; cellIndex < 9; cellIndex++)
            {
                var column = cellIndex % 3;
                var row = column / 3;

                var cellIsEmpty = board.IsCellEmpty(row, column);

                Assert.That(cellIsEmpty, Is.True);
            }
        }

        [Test]
        public void BeAbleToSetValueOfACell()
        {
            var board = new Board();

            board.SetCellToX(1, 2);

            Assert.That(board.IsCellEmpty(1,2), Is.False);
        }

        [Test]
        public void ThrowAnErrorWhenAnInvalidCellIsRead()
        {
            var board = new Board();

            Assert.Throws<ArgumentOutOfRangeException>(() => board.IsCellEmpty(5, 5));
        }
    }
}
