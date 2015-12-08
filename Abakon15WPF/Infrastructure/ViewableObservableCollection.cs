using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;

namespace Abakon15WPF.Infrastructure
{
    public class ViewableObservableCollection<T> : ObservableCollection<T> where T : class
    {
        public ViewableObservableCollection()
            : base()
        {
        }

        public ViewableObservableCollection(IEnumerable<T> collection)
            : base(collection)
        {
        }

        public ViewableObservableCollection(List<T> list)
            : base(list)
        {
        }

        public ViewableObservableCollection(object p)
        {
            // TODO: Complete member initialization
            this.p = p;
        }


        public T CurrentItem
        {
            get
            {
                return this.View.CurrentItem as T;
            }
        }


        public event EventHandler CurrentChanged;

        protected void OnCurrentChanged()
        {
            if (CurrentChanged != null) CurrentChanged(this, EventArgs.Empty);
        }

        void _View_CurrentChanged(object sender, EventArgs e)
        {
            OnPropertyChanged(new PropertyChangedEventArgs("CurrentItem"));
            OnCurrentChanged();
        }


        private ListCollectionView _View;
        private object p;

        /// <summary>
        /// A bindable view of this Observable Collection (of T) that supports
        /// filtering, sorting, and grouping.
        /// </summary>
        public ListCollectionView View
        {
            get
            {
                if (_View == null)
                {
                    _View = new ListCollectionView(this);
                    _View.CurrentChanged += new EventHandler(_View_CurrentChanged);
                }
                return _View;
            }
        }


    }
}
