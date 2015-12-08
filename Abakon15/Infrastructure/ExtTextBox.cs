using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Documents;
using System.Windows.Input;

namespace Abakon15.Infrastructure
{
    public static class ExtTextBox
    {
        public static void InsertText(this System.Windows.Controls.TextBox textbox, string sTextToInsert)
        {

            int iCaretIndex = textbox.CaretIndex;
            int iOriginalSelectionLength = textbox.SelectionLength;
            textbox.SelectedText = sTextToInsert;
            if (iOriginalSelectionLength > 0)
            {
                textbox.SelectionLength = 0;
            }
            textbox.CaretIndex = iCaretIndex + 1;
        }

        public static void InsertText(this System.Windows.Controls.RichTextBox richTextBox, string sTextToInsert)
        {
            if (StringLib.HasSomething(sTextToInsert))
            {


                richTextBox.BeginChange();
                if (richTextBox.Selection.Text != string.Empty)
                {
                    richTextBox.Selection.Text = string.Empty;
                }
                TextPointer tp = richTextBox.CaretPosition.GetPositionAtOffset(0, LogicalDirection.Forward);
                richTextBox.CaretPosition.InsertTextInRun(sTextToInsert);
                richTextBox.CaretPosition = tp;
                richTextBox.EndChange();
                Keyboard.Focus(richTextBox);

            }
        }
    }
}
