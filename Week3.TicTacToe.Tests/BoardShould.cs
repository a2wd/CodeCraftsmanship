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

            for (int columnIndex = 1; columnIndex <= 3; columnIndex++)
            {
                for (int rowIndex = 1; rowIndex <= 3; rowIndex++)
                {
                    var cellIsEmpty = board.IsCellEmpty(rowIndex, columnIndex);

                    Assert.That(cellIsEmpty, Is.True);
                }
            }
        }

        [Test]
        public void BeAbleToSetValueOfACell()
        {
            var board = new Board();

            board.SetCellToX(1, 2);

            Assert.That(board.IsCellEmpty(1,2), Is.False);
        }

        [TestCase(-2, -4)]
        [TestCase(5, 5)]
        public void ThrowAnErrorWhenAnInvalidCellIsRead(int rowIndex, int columnIndex)
        {
            var board = new Board();

            Assert.Throws<ArgumentOutOfRangeException>(() => board.IsCellEmpty(rowIndex, columnIndex));
        }

        [Test]
        public void CorrectlyRememberTheValueWhichIsZeroSetInACell()
        {
            var board = new Board();

            board.SetCellToO(1, 1);

            Assert.That(board.IsCellSetToO(1, 1), Is.True);
        }

        [Test]
        public void CorrectlyRememberTheValueSetInACell()
        {
            var board =  new Board();
            board.SetCellToX(2, 3);

            Assert.That(board.IsCellSetToX(2, 3),Is.True);
        }

        [Test]
        public void NotAllowTheValueOfACellToBeSetTwice()
        {
            var board = new Board();

            board.SetCellToX(1, 1);

            Assert.Throws<InvalidOperationException>(() => board.SetCellToO(1, 1));
        }

        [Test]
        public void NotAllowConsecutiveTurnsByPlayerX()
        {
            var board = new Board();
            
            board.SetCellToX(1,1);

            Assert.Throws<InvalidOperationException>(() => board.SetCellToX(1, 2));
        }
    }
}
