using DevExpress.Spreadsheet;
using DevExpress.Xpf.NavBar;
using DevExpress.Xpf.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SpreadsheetControl_WPF_Examples
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //IWorkbook workbook;

        public MainWindow()
        {
            InitializeComponent();
            //// Access a workbook.
            //workbook = spreadsheetControl1.Document;

            DataContext = Groups.InitData();

        }

        private void NavigationPaneView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            NavBarItem item = ((NavBarViewBase)sender).GetNavBarItem(e);
            if (item != null)
            {
                SpreadsheetExample example = item.Content as SpreadsheetExample;
                if (example != null)
                {
                    Action<SpreadsheetControl> action = example.Action;
                    action(spreadsheetControl1);
                }
            }
        }
        // ------------------- Load and Save a Document -------------------
        private void LoadDocumentFromFile()
        {
            #region #LoadDocumentFromFile
            // Load a document from a file.
            spreadsheetControl1.LoadDocument("Documents\\Document.xlsx", DocumentFormat.OpenXml);
            #endregion #LoadDocumentFromFile
        }

        private void SaveDocumentToFile()
        {
            #region #SaveDocumentToFile
            // Save the modified document to a file.
            spreadsheetControl1.SaveDocument("Documents\\SavedDocument.xlsx", DocumentFormat.OpenXml);
            #endregion #SaveDocumentToFile
        }

    }
}
