Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.Spreadsheet
Imports System.Drawing
Imports DevExpress.Xpf.Spreadsheet
Imports System.Collections.Generic

Namespace SpreadsheetControl_WPF_Examples
    Public NotInheritable Class CellActions
#Region "Actions"
        Public Shared SelectedCellAction As Action(Of SpreadsheetControl) = AddressOf SelectedCell
        Public Shared SetSelectedRangesAction As Action(Of SpreadsheetControl) = AddressOf SetSelectedRanges
#End Region

#Region "#SelectedCell"
        Private Shared Sub SelectedCell(ByVal control As SpreadsheetControl)
            control.BeginUpdate()
            Try
                control.SelectedCell.FillColor = Color.LightGray
                Dim c As Range = control.SelectedCell
                c.FillColor = Color.Blue

                Dim currentSelection As Range = control.Selection
                Dim rangeFormatting As Formatting = currentSelection.BeginUpdateFormatting()
                rangeFormatting.Borders.SetOutsideBorders(DevExpress.Utils.DXColor.Green, BorderLineStyle.MediumDashDot)
                currentSelection.EndUpdateFormatting(rangeFormatting)
            Finally
                control.EndUpdate()
            End Try
        End Sub
#End Region ' #SelectedCell

#Region "#SetSelectedRanges"
        Private Shared Sub SetSelectedRanges(ByVal control As SpreadsheetControl)
            control.BeginUpdate()
            Try
                Dim worksheet As Worksheet = control.Document.Worksheets.ActiveWorksheet
                Dim r1 As Range = worksheet.Range("A1:B10")
                Dim r2 As Range = worksheet.Range("E12")
                Dim r3 As Range = worksheet.Range("D4:E7")
                Dim rlist As New List(Of Range)() From {r1, r2, r3}
                control.SetSelectedRanges(rlist)

                control.SelectedCell = worksheet.Cells("E5")
            Finally
                control.EndUpdate()
            End Try
        End Sub
#End Region ' #SetSelectedRanges

    End Class
End Namespace
