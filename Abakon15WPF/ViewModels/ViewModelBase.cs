using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.ComponentModel;
using System.Resources;
using Abakon15WPF.LangKeys;
using System.Diagnostics;
using Abakon15WPF.Infrastructure;
using Abakon15WPF.Views;
using System.Windows;
using AbakonDataModel.DataAccess;
using AbakonDataModel;
using System.Windows.Media;
using System.Windows.Controls;

namespace Abakon15WPF.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        //AppDomain currentDomain = AppDomain.CurrentDomain;


        //static void MyHandler(object sender, UnhandledExceptionEventArgs args)
        //{
        //    Exception e = (Exception)args.ExceptionObject;
        //    MessageBox.Show(e.Message + System.Environment.NewLine + e.InnerException.Message);

        //}

        //public ViewModelBase()
        //{
        //    currentDomain.UnhandledException -= new UnhandledExceptionEventHandler(MyHandler);
        //    currentDomain.UnhandledException += new UnhandledExceptionEventHandler(MyHandler);
        //}





        protected ResourceManager m_resourceManager = new ResourceManager("Abakon15WPF.LangKeys.ResourceLang", typeof(ResourceLang).Assembly);
        protected string deleteAskObjectName;



        bool m_ReadOnly = true;
        public virtual bool ReadOnly
        {
            get { return m_ReadOnly; }
            set
            {
                SetField(ref m_ReadOnly, value, () => ReadOnly);
            }
        }

        #region ============== Property changed ==============================

        public void RaisePropertyChanged(String propertyName)
        {
            VerifyPropertyName(propertyName);
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        public void RaisePropertyChanged<T>(Expression<Func<T>> propertyExpression)
        {
            RaisePropertyChanged(ExtractPropertyName(propertyExpression));
        }


        [field: NonSerialized]
        public virtual event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                try
                {
                    handler(this, e);
                }
                catch (Exception)
                {
                }
            }
        }

        [Conditional("DEBUG")]
        [DebuggerStepThrough]
        public void VerifyPropertyName(String propertyName)
        {
            if (TypeDescriptor.GetProperties(this)[propertyName] == null)
            {
                throw new ArgumentException("Błędna nazwa własności(Property)", propertyName);
            }
        }

        public bool SetField<T>(ref T field, T value, Expression<Func<T>> propertyExpression)
        {
            var changed = !EqualityComparer<T>.Default.Equals(field, value);
            if (changed)
            {
                field = value;
                RaisePropertyChanged(ExtractPropertyName(propertyExpression));
            }
            return changed;
        }

        public static string ExtractPropertyName<T>(Expression<Func<T>> propertyExpression)
        {
            var memberExpression = propertyExpression.Body as MemberExpression;
            if (memberExpression == null)
                throw new ArgumentException("Expression must be a MemberExpression.", "propertyExpression");
            return memberExpression.Member.Name;

        }
        #endregion




        #region ================== PrograssBar ==========================================




        //ViewsControler m_ViewsControler = new ViewsControler();
        //public ViewsControler ViewsControler
        //{
        //    get { return m_ViewsControler; }
        //    set
        //    {
        //        SetField(ref m_ViewsControler, value, () => ViewsControler);
        //    }
        //}

        //protected void ProgressViewInit(int stepCount, string titleText, bool showCancel)
        //{
        //    this.ViewsControler.ProgressView.ProgressViewInit(stepCount, titleText, showCancel);
        //}

        //protected bool ProgressViewUpdate(int progress, string titleText)
        //{
        //    return this.ViewsControler.ProgressView.ProgressViewUpdate(progress, titleText);
        //}

        //protected bool ProgressViewUpdate(int progress)
        //{
        //    return this.ViewsControler.ProgressView.ProgressViewUpdate(progress);
        //}


        //protected void ProgressViewRemove()
        //{
        //    this.ViewsControler.ProgressView.ProgressViewRemove();
        //}

        #endregion

        #region ============ Print
        //RelayCommand _PrintCommand;
        //public RelayCommand PrintCommand
        //{
        //    get
        //    {
        //        if (_PrintCommand == null)
        //        {
        //            _PrintCommand = new RelayCommand(
        //                param => this.View.PrintView(),
        //                param => true
        //                );
        //        }
        //        return _PrintCommand;
        //    }
        //} 
        #endregion

        #region Standard Commands

        //RelayCommand m_openHelpCommand = null;
        //public RelayCommand OpenHelpCommand
        //{
        //    get
        //    {
        //        if (m_openHelpCommand == null)
        //        {
        //            m_openHelpCommand = new RelayCommand(
        //                                            param =>
        //                                            {
        //                                                if (param != null)
        //                                                {
        //                                                    string helpFileName = @".\HelpDocs\" + param.ToString() + "_" + System.Globalization.CultureInfo.CurrentCulture.TwoLetterISOLanguageName + ".xps";

        //                                                    if (System.IO.File.Exists(helpFileName))
        //                                                    {
        //                                                        HelpInfoWindow.OpenHelpInfoWindow(helpFileName);
        //                                                    }
        //                                                    else
        //                                                    {
        //                                                        HelpInfoWindow.OpenHelpInfoWindow(@".\HelpDocs\MissingTheme.xps");
        //                                                    }
        //                                                }
        //                                            },
        //                                            param => true
        //                                            );
        //        }
        //        return m_openHelpCommand;
        //    }
        //}

        //RelayCommand _CloseFormCommand;
        //public RelayCommand CloseFormCommand
        //{
        //    get
        //    {
        //        if (_CloseFormCommand == null)
        //        {
        //            _CloseFormCommand = new RelayCommand(

        //                param =>
        //                {
        //                    if (this.SaveContextDataWithMsg())
        //                    {
        //                        this.CloseView();
        //                    }
        //                },
        //                param => true
        //                );
        //        }
        //        return _CloseFormCommand;
        //    }
        //}

        RelayCommand _saveCommand;
        public RelayCommand SaveCommand
        {
            get
            {
                if (_saveCommand == null)
                {
                    _saveCommand = new RelayCommand(
                        param =>
                        {
                            this.SaveToDB(param);
                            MessageBox.Show("_savedChanges".Translate(), "", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                            ,
                        param => CanSave()
                        );
                }
                return _saveCommand;
            }
        }

        protected virtual void SaveToDB(object param = null)
        {
            DataAccessBaseClass.SaveChanges();
        }

        protected virtual bool CanSave()
        {
            return true;
        }


        RelayCommand m_AddNewCommand;
        public RelayCommand AddNewCommand
        {
            get
            {
                if (m_AddNewCommand == null)
                {
                    m_AddNewCommand = new RelayCommand(
                        param => this.AddNew(param),
                        param => CanAdd()
                        );
                }
                return m_AddNewCommand;
            }
        }

        protected virtual bool CanAdd()
        {

            return !ReadOnly;
        }

        protected virtual void AddNew(object param = null) { }

        RelayCommand m_addFromClipboardCommand;
        public RelayCommand AddFromClipboardCommand
        {
            get
            {
                if (m_addFromClipboardCommand == null)
                {
                    m_addFromClipboardCommand = new RelayCommand(
                        param => AddFromClipboard(param),
                        param => CanAddFromClipboard(param)
                        );
                }
                return m_addFromClipboardCommand;
            }
        }

        protected virtual bool CanAddFromClipboard(object param)
        {
            return true;
        }

        protected virtual void AddFromClipboard(object param, bool init = true) { }

        RelayCommand m_DeleteCommand;
        public RelayCommand DeleteCommand
        {
            get
            {
                if (m_DeleteCommand == null)
                {
                    m_DeleteCommand = new RelayCommand(
                        param =>
                        {
                            this.Delete();
                            var u = param as UIElement;
                            if (u != null) u.Refresh();
                        },
                        param => this.CanDeleteCommand()
                        );
                }
                return m_DeleteCommand;
            }
        }

        protected virtual bool CanDeleteCommand()
        {
            return !this.ReadOnly;
        }

        protected virtual void Delete()
        {
            string kom = "_deleteDataAsk".Translate() + ":" + Environment.NewLine + deleteAskObjectName;
            string komHeader = "_confirm".Translate();
            if (MessageBox.Show(kom, komHeader, MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes) == MessageBoxResult.Yes)
            {
                DeleteFromBase();
            }
        }

        protected virtual void DeleteFromBase() { }


        RelayCommand _UndoChangesCommand;
        public RelayCommand UndoChangesCommand
        {
            get
            {
                if (_UndoChangesCommand == null)
                {
                    _UndoChangesCommand = new RelayCommand(
                         param =>
                         {
                             
                             System.Windows.Controls.DataGrid ctrlDataGrid = param as System.Windows.Controls.DataGrid;
                             if (ctrlDataGrid != null)
                             {
                                 try
                                 {

                                     {
                                         ctrlDataGrid.CommitEdit();
                                         ctrlDataGrid.Items.Refresh();
                                     }
                                 }
                                 catch (Exception)
                                 {
                                 }
                             }
                             else
                             {
                                 System.Windows.Controls.UserControl depObj = param as System.Windows.Controls.UserControl;
                                 if (depObj != null)
                                 {
                                     IEnumerable<DataGrid> tabs = FindVisualChildren<DataGrid>(depObj);

                                     foreach (var dg in tabs)
                                     {
                                         dg.CommitEdit();
                                         dg.Items.Refresh();
                                     }
                                 }
                             }




                             RaiseChanged();
                         },
                         param => true
                         );
                }
                return _UndoChangesCommand;
            }
        }

        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }

        protected virtual void RaiseChanged() { }

        #endregion



    }
}
