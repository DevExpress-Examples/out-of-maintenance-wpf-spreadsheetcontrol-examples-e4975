Imports System.Collections.Generic

Namespace SpreadsheetControl_WPF_Examples

    Public Partial Class Groups
        Inherits List(Of Group)

        Public Shared Function InitData() As Groups
            Dim examples As Groups = New Groups()
#Region "GroupNodes"
            examples.Add(New Group("Cells"))
            examples.Add(New Group("Rows and Columns"))
#End Region
#Region "ExampleNodes"
            ' Add nodes to the "Cells" group of examples.
            examples(0).Items.Add(New SpreadsheetExample("Highlight Selected Cell and Range", SelectedCellAction))
            examples(0).Items.Add(New SpreadsheetExample("SetSelectedRanges Method", SetSelectedRangesAction))
            ' Add nodes to the "Rows and Columns" group of examples.
            examples(1).Items.Add(New SpreadsheetExample("Freeze Row", FreezeRowAction))
            examples(1).Items.Add(New SpreadsheetExample("Freeze Column", FreezeColumnAction))
            examples(1).Items.Add(New SpreadsheetExample("Freeze Panes", FreezePanesAction))
            examples(1).Items.Add(New SpreadsheetExample("Unfreeze Panes", UnfreezePanesAction))
            Return examples
#End Region
        End Function
    End Class
End Namespace
