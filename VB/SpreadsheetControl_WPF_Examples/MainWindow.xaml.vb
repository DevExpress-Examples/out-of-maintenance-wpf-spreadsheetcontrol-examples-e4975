Imports DevExpress.Spreadsheet
Imports DevExpress.Xpf.NavBar
Imports DevExpress.Xpf.Spreadsheet
Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Input

Namespace SpreadsheetControl_WPF_Examples

    ''' <summary>
    ''' Interaction logic for MainWindow.xaml
    ''' </summary>
    Public Partial Class MainWindow
        Inherits Window

        'IWorkbook workbook;
        Public Sub New()
            Me.InitializeComponent()
            ''' Access a workbook.
            'workbook = spreadsheetControl1.Document;
            DataContext = Groups.InitData()
        End Sub

        Private Sub NavigationPaneView_MouseDoubleClick(ByVal sender As Object, ByVal e As MouseButtonEventArgs)
            Dim item As NavBarItem = CType(sender, NavBarViewBase).GetNavBarItem(e)
            If item IsNot Nothing Then
                Dim example As SpreadsheetExample = TryCast(item.Content, SpreadsheetExample)
                If example IsNot Nothing Then
                    Dim action As Action(Of SpreadsheetControl) = example.Action
                    action(Me.spreadsheetControl1)
                End If
            End If
        End Sub

        ' ------------------- Load and Save a Document -------------------
        Private Sub LoadDocumentFromFile()
#Region "#LoadDocumentFromFile"
            ' Load a document from a file.
            Me.spreadsheetControl1.LoadDocument("Documents\Document.xlsx", DocumentFormat.OpenXml)
#End Region  ' #LoadDocumentFromFile
        End Sub

        Private Sub SaveDocumentToFile()
#Region "#SaveDocumentToFile"
            ' Save the modified document to a file.
            Me.spreadsheetControl1.SaveDocument("Documents\SavedDocument.xlsx", DocumentFormat.OpenXml)
#End Region  ' #SaveDocumentToFile
        End Sub
    End Class
End Namespace
