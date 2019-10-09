Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace SpreadsheetControl_WPF_Examples
	Partial Public Class Groups
		Inherits List(Of Group)

		Public Shared Function InitData() As Groups
			Dim examples As New Groups()

'			#Region "GroupNodes"
			examples.Add(New Group("Cells"))
			examples.Add(New Group("Rows and Columns"))
'			#End Region

'			#Region "ExampleNodes"
			' Add nodes to the "Cells" group of examples.
			examples(0).Items.Add(New SpreadsheetExample("Highlight Selected Cell and Range", CellActions.SelectedCellAction))
			examples(0).Items.Add(New SpreadsheetExample("SetSelectedRanges Method", CellActions.SetSelectedRangesAction))


			' Add nodes to the "Rows and Columns" group of examples.
			examples(1).Items.Add(New SpreadsheetExample("Freeze Row", RowAndColumnActions.FreezeRowAction))
			examples(1).Items.Add(New SpreadsheetExample("Freeze Column", RowAndColumnActions.FreezeColumnAction))
			examples(1).Items.Add(New SpreadsheetExample("Freeze Panes", RowAndColumnActions.FreezePanesAction))
			examples(1).Items.Add(New SpreadsheetExample("Unfreeze Panes", RowAndColumnActions.UnfreezePanesAction))

			Return examples
'			#End Region
		End Function
	End Class
End Namespace
