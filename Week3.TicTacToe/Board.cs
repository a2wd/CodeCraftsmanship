namespace Week3.TicTacToe
{
    using System;

    public class Board
    {
        private int ValueWhenEmpty = 0;

        private int ValueOfX = 1;

        private int[,] Cells;

        public Board()
        {
            Cells = new int[3,3];
        }

        public bool IsCellEmpty(int row, int column)
        {
            if (row > 3 || column > 3)
            {
                throw new ArgumentOutOfRangeException();
            }

            return Cells[row, column] == ValueWhenEmpty;
        }

        public void SetCellToX(int row, int column)
        {
            Cells[row, column] = ValueOfX;
        }
    }
}
