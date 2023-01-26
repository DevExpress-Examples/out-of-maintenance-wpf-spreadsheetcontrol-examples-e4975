Imports System
Imports System.Collections.Generic
Imports System.Windows.Controls
Imports DevExpress.Xpf.Spreadsheet

Namespace SpreadsheetControl_WPF_Examples

    Public Class Group

        Public Property Header As String

        Public Property Items As List(Of SpreadsheetExample)

        Public Sub New(ByVal name As String)
            Header = name
            Items = New List(Of SpreadsheetExample)()
        End Sub
    End Class

    Public Class SpreadsheetExample

        Private _Action As Action(Of DevExpress.Xpf.Spreadsheet.SpreadsheetControl)

        Public Property Header As String

        Public Sub New(ByVal name As String, ByVal action As Action(Of SpreadsheetControl))
            Header = name
            Me.Action = action
        End Sub

        Public Property Action As Action(Of SpreadsheetControl)
            Get
                Return _Action
            End Get

            Private Set(ByVal value As Action(Of SpreadsheetControl))
                _Action = value
            End Set
        End Property
    End Class
End Namespace
