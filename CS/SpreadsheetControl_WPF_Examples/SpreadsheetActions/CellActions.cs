using System;
using DevExpress.Spreadsheet;
using System.Drawing;
using DevExpress.Xpf.Spreadsheet;
using System.Collections.Generic;

namespace SpreadsheetControl_WPF_Examples
{
    public static class CellActions
    {
        #region Actions
        public static Action<SpreadsheetControl> SelectedCellAction = SelectedCell;
        public static Action<SpreadsheetControl> SetSelectedRangesAction = SetSelectedRanges;
        #endregion

        #region #SelectedCell
        static void SelectedCell(SpreadsheetControl control)
        {
            control.BeginUpdate();

            control.SelectedCell.FillColor = Color.LightGray;
            Range c = control.SelectedCell;
            c.FillColor = Color.Blue;

            Range currentSelection = control.Selection;
            Formatting rangeFormatting = currentSelection.BeginUpdateFormatting();
            rangeFormatting.Borders.SetOutsideBorders(DevExpress.Utils.DXColor.Green, BorderLineStyle.MediumDashDot);
            currentSelection.EndUpdateFormatting(rangeFormatting);

            control.EndUpdate();
        }
        #endregion #SelectedCell

        #region #SetSelectedRanges
        static void SetSelectedRanges(SpreadsheetControl control)
        {
            control.BeginUpdate();
            Worksheet worksheet = control.ActiveWorksheet;

            Range r1 = worksheet.Range["A1:B10"];
            Range r2 = worksheet.Range["E12"];
            Range r3 = worksheet.Range["D4:E7"];
            List<Range> rlist = new List<Range>() { r1, r2, r3 };
            control.SetSelectedRanges(rlist);

            control.SelectedCell = worksheet.Cells["E5"];

            control.EndUpdate();
        }
        #endregion #SetSelectedRanges

    }
}
