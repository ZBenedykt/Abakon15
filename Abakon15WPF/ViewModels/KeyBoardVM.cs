using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using Microsoft.Office.Interop.Word;
using Abakon15WPF.Interfaces;
using Abakon15WPF.Infrastructure;
using AbakonDataModel;

namespace Abakon15WPF.ViewModels
{
    class KeyBoardVM : ViewModelBase
    {
        public List<_KeyBoardKey> keys = new List<_KeyBoardKey>(_KeyBoardKey.Load());

        private IVirtualKeyboardInjectable _targetWindow;
        public IVirtualKeyboardInjectable TargetWindow
        {
            get { return _targetWindow; }
            set { _targetWindow = value; }
        }

        public void Inject(string sWhat)
        {
            if (TargetWindow != null)
            {
                TextBox txtTarget = TargetWindow.ControlToInjectInto as TextBox;
                if (txtTarget != null)
                {
                    if (txtTarget.IsEnabled && !txtTarget.IsReadOnly)
                    {
                        txtTarget.InsertText(sWhat);
                    }
                    else
                    {
                        if (!txtTarget.IsEnabled)
                        {
                            //  SetStatusTextTo("Cannot type into disabled field");
                        }
                        else
                        {
                            //  SetStatusTextTo("Cannot type into readonly field");
                        }
                    }
                }
                else
                {
                    RichTextBox richTextBox = TargetWindow.ControlToInjectInto as RichTextBox;
                    if (richTextBox != null)
                    {
                        if (richTextBox.IsEnabled && !richTextBox.IsReadOnly)
                        {
                            richTextBox.InsertText(sWhat);

                        }
                        else
                        {
                            if (!txtTarget.IsEnabled)
                            {
                                // SetStatusTextTo("Cannot type into disabled field");
                            }
                            else
                            {
                                // SetStatusTextTo("Cannot type into readonly field");
                            }
                        }
                    }
                }
            }
        }

        RelayCommand _ExecuteKeyPressedCommand;
        public RelayCommand ExecuteKeyPressedCommand
        {
            get
            {

                return _ExecuteKeyPressedCommand ??
                       (_ExecuteKeyPressedCommand = new RelayCommand(
                        param =>
                        {
                            String sWhat = param as String;
                            if (!String.IsNullOrEmpty(sWhat))
                            {
                                Inject(sWhat);
                            }
                        },
                        param => true
                        ));
            }
        }


    }
}
