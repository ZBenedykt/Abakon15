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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Abakon15.Views.Controls.Standard
{
    /// <summary>
    /// Interaction logic for NavigationPanel.xaml
    /// </summary>
    public partial class NavigationPanel : UserControl
    {
        public static readonly DependencyProperty CurrentIndexProperty;
        public static readonly DependencyProperty ViewProperty;
        static NavigationPanel()
        {
            FrameworkPropertyMetadata metadata = new FrameworkPropertyMetadata(null);//, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault);
            ViewProperty = DependencyProperty.Register("View", typeof(ListCollectionView), typeof(NavigationPanel), metadata);
            metadata = new FrameworkPropertyMetadata(-1, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault);
            CurrentIndexProperty = DependencyProperty.Register("CurrentIndex", typeof(int), typeof(NavigationPanel), metadata);
        }

        public NavigationPanel()
        {
            InitializeComponent();

        }


        public ListCollectionView View
        {
            get { return (ListCollectionView)GetValue(ViewProperty); }
            set
            {

                SetValue(ViewProperty, value);
                this.View.CurrentChanged += new EventHandler(View_CurrentChanged);
            }
        }

        void View_CurrentChanged(object sender, EventArgs e)
        {
            if (View != null)
            {
                OnPropertyChanged(new DependencyPropertyChangedEventArgs(CurrentIndexProperty, View.CurrentPosition, View.CurrentPosition));
            }
        }


        public int CurrentIndex
        {
            get
            {
                // return (int)GetValue(CurrentIndexProperty); 

                MessageBox.Show(View.CurrentPosition.ToString());
                return View != null ? View.CurrentPosition : 0;
            }
            set
            {

                //SetValue(ViewProperty, value);
                MessageBox.Show(this.CurrentIndex.ToString() + " " + View.CurrentPosition);
                if (View != null && this.CurrentIndex != View.CurrentPosition)
                {
                    View.MoveCurrentToPosition(this.CurrentIndex);
                }
            }
        }



        private void c_GotoFirstButton_Click(object sender, RoutedEventArgs e)
        {
            if (View != null)
            {
                this.View.MoveCurrentToFirst();
            }
        }

        private void c_GotoPrevButton_Click(object sender, RoutedEventArgs e)
        {
            if (View != null && View.CurrentPosition > 0)
            {
                this.View.MoveCurrentToPrevious();
            }

        }

        private void c_GotoNextButton_Click(object sender, RoutedEventArgs e)
        {
            if (View != null && View.CurrentPosition < View.Count - 1)
            {
                this.View.MoveCurrentToNext();
            }
        }

        private void c_GotoLastButton_Click(object sender, RoutedEventArgs e)
        {
            if (View != null)
            {
                this.View.MoveCurrentToLast();
            }
        }



        private void c_CurrentPosition_TextChanged(object sender, TextChangedEventArgs e)
        {
            int pos = 0;

            if (View != null)
            {
                pos = View.CurrentPosition;
                int.TryParse(c_CurrentPosition.Text, out pos);
                if (pos > 0 && pos <= View.Count)
                    try
                    {
                        View.MoveCurrentToPosition(pos - 1);
                    }
                    catch (Exception)
                    {

                    }

            }
            if (c_CurrentPosition.Text != (pos).ToString())
            {
                c_CurrentPosition.Text = (pos).ToString();
            }
        }
    }
}
