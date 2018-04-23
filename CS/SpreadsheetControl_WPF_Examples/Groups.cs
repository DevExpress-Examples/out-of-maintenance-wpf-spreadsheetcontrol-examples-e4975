using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpreadsheetControl_WPF_Examples
{
    public partial class Groups : List<Group>
    {
        public static Groups InitData()
        {
            Groups examples = new Groups();

            #region GroupNodes
            examples.Add(new Group("Cells"));
            examples.Add(new Group("Rows and Columns"));
            #endregion

            #region ExampleNodes
            // Add nodes to the "Cells" group of examples.
            examples[0].Items.Add(new SpreadsheetExample("Highlight Selected Cell and Range", CellActions.SelectedCellAction));
            examples[0].Items.Add(new SpreadsheetExample("SetSelectedRanges Method", CellActions.SetSelectedRangesAction));


            // Add nodes to the "Rows and Columns" group of examples.
            examples[1].Items.Add(new SpreadsheetExample("Freeze Row", RowAndColumnActions.FreezeRowAction));
            examples[1].Items.Add(new SpreadsheetExample("Freeze Column", RowAndColumnActions.FreezeColumnAction));
            examples[1].Items.Add(new SpreadsheetExample("Freeze Panes", RowAndColumnActions.FreezePanesAction));
            examples[1].Items.Add(new SpreadsheetExample("Unfreeze Panes", RowAndColumnActions.UnfreezePanesAction));

            return examples;
            #endregion
        }
    }
}
