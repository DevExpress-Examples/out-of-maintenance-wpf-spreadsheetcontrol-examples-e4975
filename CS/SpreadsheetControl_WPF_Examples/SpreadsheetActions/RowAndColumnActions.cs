using System;
using DevExpress.Spreadsheet;
using System.Drawing;
using DevExpress.Xpf.Spreadsheet;

namespace SpreadsheetControl_WPF_Examples
{
    public static class RowAndColumnActions {
        #region Actions
        public static Action<SpreadsheetControl> FreezeRowAction = FreezeRow;
        public static Action<SpreadsheetControl> FreezeColumnAction = FreezeColumn;
        public static Action<SpreadsheetControl> FreezePanesAction = FreezePanes;
        public static Action<SpreadsheetControl> UnfreezePanesAction = UnfreezePanes;
        #endregion

        #region #FreezeRow
        static void FreezeRow(SpreadsheetControl control) {
            control.BeginUpdate();
            try {
                //Access the active worksheet.
                Worksheet worksheet = control.Document.Worksheets.ActiveWorksheet;

                // Access the cell range that is currently visible.
                CellRange visibleRange = control.VisibleRange;
                //Range visibleRange = control.Document.Range.FromLTRB(10, 15, 15, 20);

                // Freeze the top visible row.
                worksheet.FreezeRows(0, visibleRange); 
            }
            finally {
                control.EndUpdate();
            }
        }
        #endregion #FreezeRow

        #region #FreezeColumn
        static void FreezeColumn(SpreadsheetControl control)
        {
            control.BeginUpdate();
            try
            {
                //Access the active worksheet.
                Worksheet worksheet = control.Document.Worksheets.ActiveWorksheet;

                // Access the cell range that is currently visible.
                CellRange visibleRange = control.VisibleRange;


                // Freeze the top visible row.
                worksheet.FreezeColumns(0, visibleRange);
            }
            finally
            {
                control.EndUpdate();
            }
        }
        #endregion #FreezeColumn

        #region #FreezePanes
        static void FreezePanes(SpreadsheetControl control)
        {
            //Access the active worksheet.
            Worksheet worksheet = control.Document.Worksheets.ActiveWorksheet;

            // Access the cell range that is currently visible.
            CellRange visibleRange = control.VisibleRange;

            // Access the active cell. 
            Cell activeCell = control.ActiveCell;

            int rowOffset = activeCell.RowIndex - visibleRange.TopRowIndex - 1;
            int columnOffset = activeCell.ColumnIndex - visibleRange.LeftColumnIndex - 1;

            // If the active cell is outside the visible range of cells, no rows and columns are frozen.
            if (!visibleRange.IsIntersecting(activeCell))
            {
                return;
            }

            if (activeCell.ColumnIndex == visibleRange.LeftColumnIndex)
            {
                // If the active cell matches the top left visible cell, no rows and columns are frozen.
                if (activeCell.RowIndex == visibleRange.TopRowIndex) { return; }
                else
                    // Freeze visible rows above the active cell if it is located in the leftmost visible column.
                    worksheet.FreezeRows(rowOffset, visibleRange);
            }

            else if (activeCell.RowIndex == visibleRange.TopRowIndex)
            {
                // Freeze visible columns to the left of the active cell if it is located in the topmost visible row.
                worksheet.FreezeColumns(columnOffset, visibleRange);
            }

            else
            {
                // Freeze both rows and columns above and to the left of the active cell.
                worksheet.FreezePanes(rowOffset, columnOffset, visibleRange);
            }
        }
        #endregion #FreezePanes

        #region #UnfreezePanes
        static void UnfreezePanes(SpreadsheetControl control)
        {
            control.BeginUpdate();
            try
            {
                //Access the active worksheet.
                Worksheet worksheet = control.Document.Worksheets.ActiveWorksheet;

                // Access the cell range that is currently visible.
                CellRange visibleRange = control.VisibleRange;

                // Freeze the top visible row.
                worksheet.FreezeRows(0, visibleRange);
            }
            finally
            {
                control.EndUpdate();
            }
        }
        #endregion #UnfreezePanes

    }
}
