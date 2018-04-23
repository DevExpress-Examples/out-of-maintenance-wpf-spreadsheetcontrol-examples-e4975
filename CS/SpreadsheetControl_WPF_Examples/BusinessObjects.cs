﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DevExpress.Xpf.NavBar;
using DevExpress.Spreadsheet;
using DevExpress.Xpf.Spreadsheet;


namespace SpreadsheetControl_WPF_Examples
{
    public class Group
    {
        public string Header { get; set; }
        public List<SpreadsheetExample> Items { get; set; }

        public Group(string name)
        {
            Header = name;
            Items = new List<SpreadsheetExample>();
        }        
    }

    public class SpreadsheetExample
    {
        public string Header { get; set; }
        public SpreadsheetExample(string name, Action<SpreadsheetControl> action)
        {
            Header = name;
            Action = action;
        }
        public Action<SpreadsheetControl> Action { get; private set; }
    }
}
