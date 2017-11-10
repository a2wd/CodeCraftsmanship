namespace Week3.TicTacToe
{
    using System;

    public class Board
    {
        private readonly int[,] _cells;

        private int _lastMove;

        public Board()
        {
            _cells = new int[BoardDimensions.MaximumRowNumber, BoardDimensions.MaximumColumnNumber];
        }

        public bool IsCellEmpty(int row, int column)
        {
            if (RowAndColumnIndexIsNotValid(row, column))
            {
                throw new ArgumentOutOfRangeException();
            }

            return GetCellValueWith1IndexedRowAndColumnValues(row, column) == CellValues.Empty;
        }

        public void SetCellToX(int row, int column)
        {
            if (IsCellEmpty(row, column) && _lastMove != CellValues.X)
            {
                SetCellValueWith1IndexedRowAndColumnValues(row, column, CellValues.X);
                _lastMove = CellValues.X;

                return;
            }

            throw new InvalidOperationException();
        }
        
        private bool RowAndColumnIndexIsNotValid(int row, int column)
        {
            return row > BoardDimensions.MaximumRowNumber || row < BoardDimensions.MinimumRowNumber || column > BoardDimensions.MaximumColumnNumber || column < BoardDimensions.MinimumColumnNumber;
        }

        private void SetCellValueWith1IndexedRowAndColumnValues(int rowIndex, int columnIndex, int value)
        {
            _cells[rowIndex - 1, columnIndex - 1] = value;
        }

        private int GetCellValueWith1IndexedRowAndColumnValues(int rowIndex, int columnIndex)
        {
            return _cells[rowIndex - 1, columnIndex - 1];
        }

        public void SetCellToO(int row, int column)
        {
            if (IsCellEmpty(row,column))
            {
                SetCellValueWith1IndexedRowAndColumnValues(row, column, CellValues.O);
                return;
            }

            throw new InvalidOperationException();
        }

        public bool IsCellSetToO(int rowIndex, int columnIndex)
        {
            return GetCellValueWith1IndexedRowAndColumnValues(rowIndex, columnIndex) == CellValues.O;
        }

        public bool IsCellSetToX(int rowIndex, int columnIndex)
        {
            return GetCellValueWith1IndexedRowAndColumnValues(rowIndex, columnIndex) == CellValues.X;
        }
    }
}
