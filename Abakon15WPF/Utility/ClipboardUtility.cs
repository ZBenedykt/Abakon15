using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Abakon15WPF.Utility
{


    public static class ClipboardUtility
    {
        public static string[][] ClipboardTable()
        {

            //char[] rowSplitter = { '\n', '\r' };  // Cr and Lf.
            //char columnSplitter = '\t';         // Tab.

            string[][] clipboardData =
                        ((string)Clipboard.GetData(DataFormats.Text)).Split('\n')
                        .Select(row =>
                            row.Split('\t')
                            .Select(cell =>
                                cell.Length > 0 && cell[cell.Length - 1] == '\r' ?
                                cell.Substring(0, cell.Length - 1) : cell).ToArray())
                        .Where(a => a.Any(b => b.Length > 0)).ToArray();


            return clipboardData;
        }

    }
}
