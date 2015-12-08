using System;
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
using System.Windows.Shapes;
using System.Windows.Media.Effects;
using Abakon15.ViewModels;
using Abakon15.Interfaces;

namespace Abakon15.Views.Windows
{
    /// <summary>
    /// Interaction logic for KeyBoardWindow.xaml
    /// </summary>
    public partial class KeyBoardWindow : Window
    {
        public KeyBoardWindow()
        {
            InitializeComponent();
            if (_desiredTargetWindow != null)
            {
                _viewModel.TargetWindow = _desiredTargetWindow;
            }
        }

        string[] charList = { "±", "²", " ³", "°","′","″", "α","β","γ","δ","ε","ζ","η","θ","μ","ξ","π","ρ","ς","σ","φ","ψ","ω", "∆","Ω", "∑","∞","‰",
                                "dobry","positive"};


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var item in _viewModel.keys.OrderBy(p => p._KeyLp))
            {
                Button but = new Button();
                but.MinHeight = 20;
                but.MinWidth = 25;
                but.Margin = new Thickness(2, 2, 2, 2);
                but.Style = (Style)FindResource("KeyBoardButton");
                but.Content = item._KeyValue;
                but.FontSize = 16;
                //  but.FontWeight = FontWeights.Black;

                but.Click += new RoutedEventHandler(but_Click);
                _wrapPanel.Children.Add(but);

            }
            if (_viewModel.TargetWindow == null)
            {
                _viewModel.TargetWindow = Owner as IVirtualKeyboardInjectable;
            }
        }

        void but_Click(object sender, RoutedEventArgs e)
        {
            Button sb = sender as Button;
            if (sb != null)
            {

                ((KeyBoardVM)this.DataContext).ExecuteKeyPressedCommand.Execute(sb.Content);
            }
        }

        private static IVirtualKeyboardInjectable _desiredTargetWindow;


        public IVirtualKeyboardInjectable TargetWindow
        {
            set
            {
                _desiredTargetWindow = value;
                if (_viewModel != null)
                {
                    _viewModel.TargetWindow = value;
                }
            }
        }

        //private static KeyBoardWindow _theVirtualKeyboard;
        //public static bool IsUp
        //{
        //    get { return _theVirtualKeyboard != null; }
        //}
        //public static void ShowOrAttachTo(IVirtualKeyboardInjectable targetWindow)
        //{
        //    try
        //    {
        //        _desiredTargetWindow = targetWindow;
        //        // Evidently, for modal Windows I can't share user-focus with another Window unless I first close and then recreate it.
        //        // A shame. Seems like a waste of time. But I don't know of a work-around to it (yet).
        //        if (IsUp)
        //        {
        //            Console.WriteLine("VirtualKeyboard: re-attaching to a different Window.");
        //            targetWindow.TheVirtualKeyboard = null;
        //        }
        //        else
        //        {
        //            KeyBoardWindow virtualKeyboard = ShowIt(targetWindow);
        //            targetWindow.TheVirtualKeyboard = virtualKeyboard;
        //        }
        //    }
        //    catch (Exception x)
        //    {
        //        MessageBox.Show("in VirtualKeyboard.ShowOrAttachTo: " + x.Message);
        //    }
        //}



    }
}
