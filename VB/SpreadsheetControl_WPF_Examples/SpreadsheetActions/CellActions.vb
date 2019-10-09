Imports System
Imports DevExpress.Spreadsheet
Imports System.Drawing
Imports DevExpress.Xpf.Spreadsheet
Imports System.Collections.Generic

Namespace SpreadsheetControl_WPF_Examples
	Public Module CellActions
		#Region "Actions"
		Public SelectedCellAction As Action(Of SpreadsheetControl) = AddressOf SelectedCell
		Public SetSelectedRangesAction As Action(Of SpreadsheetControl) = AddressOf SetSelectedRanges
		#End Region

		#Region "#SelectedCell"
		Private Sub SelectedCell(ByVal control As SpreadsheetControl)
			control.BeginUpdate()

			control.SelectedCell.FillColor = Color.LightGray
			Dim c As CellRange = control.SelectedCell
			c.FillColor = Color.Blue

			Dim currentSelection As CellRange = control.Selection
			Dim rangeFormatting As Formatting = currentSelection.BeginUpdateFormatting()
			rangeFormatting.Borders.SetOutsideBorders(DevExpress.Utils.DXColor.Green, BorderLineStyle.MediumDashDot)
			currentSelection.EndUpdateFormatting(rangeFormatting)

			control.EndUpdate()
		End Sub
		#End Region ' #SelectedCell

		#Region "#SetSelectedRanges"
		Private Sub SetSelectedRanges(ByVal control As SpreadsheetControl)
			control.BeginUpdate()
			Dim worksheet As Worksheet = control.ActiveWorksheet

			Dim r1 As CellRange = worksheet.Range("A1:B10")
			Dim r2 As CellRange = worksheet.Range("E12")
			Dim r3 As CellRange = worksheet.Range("D4:E7")
			Dim rlist As New List(Of CellRange)() From {r1, r2, r3}
			control.SetSelectedRanges(rlist)

			control.SelectedCell = worksheet.Cells("E5")

			control.EndUpdate()
		End Sub
		#End Region ' #SetSelectedRanges

	End Module
End Namespace
