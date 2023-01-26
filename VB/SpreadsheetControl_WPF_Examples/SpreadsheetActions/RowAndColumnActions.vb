Imports System
Imports DevExpress.Spreadsheet
Imports System.Drawing
Imports DevExpress.Xpf.Spreadsheet

Namespace SpreadsheetControl_WPF_Examples

    Public Module RowAndColumnActions

#Region "Actions"
        Public FreezeRowAction As Action(Of SpreadsheetControl) = AddressOf FreezeRow

        Public FreezeColumnAction As Action(Of SpreadsheetControl) = AddressOf FreezeColumn

        Public FreezePanesAction As Action(Of SpreadsheetControl) = AddressOf FreezePanes

        Public UnfreezePanesAction As Action(Of SpreadsheetControl) = AddressOf UnfreezePanes

#End Region
#Region "#FreezeRow"
        Private Sub FreezeRow(ByVal control As SpreadsheetControl)
            control.BeginUpdate()
            Try
                'Access the active worksheet.
                Dim worksheet As Worksheet = control.Document.Worksheets.ActiveWorksheet
                ' Access the cell range that is currently visible.
                Dim visibleRange As CellRange = control.VisibleRange
                'Range visibleRange = control.Document.Range.FromLTRB(10, 15, 15, 20);
                ' Freeze the top visible row.
                worksheet.FreezeRows(0, visibleRange)
            Finally
                control.EndUpdate()
            End Try
        End Sub

#End Region  ' #FreezeRow
#Region "#FreezeColumn"
        Private Sub FreezeColumn(ByVal control As SpreadsheetControl)
            control.BeginUpdate()
            Try
                'Access the active worksheet.
                Dim worksheet As Worksheet = control.Document.Worksheets.ActiveWorksheet
                ' Access the cell range that is currently visible.
                Dim visibleRange As CellRange = control.VisibleRange
                ' Freeze the top visible row.
                worksheet.FreezeColumns(0, visibleRange)
            Finally
                control.EndUpdate()
            End Try
        End Sub

#End Region  ' #FreezeColumn
#Region "#FreezePanes"
        Private Sub FreezePanes(ByVal control As SpreadsheetControl)
            'Access the active worksheet.
            Dim worksheet As Worksheet = control.Document.Worksheets.ActiveWorksheet
            ' Access the cell range that is currently visible.
            Dim visibleRange As CellRange = control.VisibleRange
            ' Access the active cell. 
            Dim activeCell As Cell = control.ActiveCell
            Dim rowOffset As Integer = activeCell.RowIndex - visibleRange.TopRowIndex - 1
            Dim columnOffset As Integer = activeCell.ColumnIndex - visibleRange.LeftColumnIndex - 1
            ' If the active cell is outside the visible range of cells, no rows and columns are frozen.
            If Not visibleRange.IsIntersecting(activeCell) Then
                Return
            End If

            If activeCell.ColumnIndex = visibleRange.LeftColumnIndex Then
                ' If the active cell matches the top left visible cell, no rows and columns are frozen.
                If activeCell.RowIndex = visibleRange.TopRowIndex Then
                    Return
                Else
                    ' Freeze visible rows above the active cell if it is located in the leftmost visible column.
                    worksheet.FreezeRows(rowOffset, visibleRange)
                End If
            ElseIf activeCell.RowIndex = visibleRange.TopRowIndex Then
                ' Freeze visible columns to the left of the active cell if it is located in the topmost visible row.
                worksheet.FreezeColumns(columnOffset, visibleRange)
            Else
                ' Freeze both rows and columns above and to the left of the active cell.
                worksheet.FreezePanes(rowOffset, columnOffset, visibleRange)
            End If
        End Sub

#End Region  ' #FreezePanes
#Region "#UnfreezePanes"
        Private Sub UnfreezePanes(ByVal control As SpreadsheetControl)
            control.BeginUpdate()
            Try
                'Access the active worksheet.
                Dim worksheet As Worksheet = control.Document.Worksheets.ActiveWorksheet
                ' Access the cell range that is currently visible.
                Dim visibleRange As CellRange = control.VisibleRange
                ' Freeze the top visible row.
                worksheet.FreezeRows(0, visibleRange)
            Finally
                control.EndUpdate()
            End Try
        End Sub
#End Region  ' #UnfreezePanes
    End Module
End Namespace
