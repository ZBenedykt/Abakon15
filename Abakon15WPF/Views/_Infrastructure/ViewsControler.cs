using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Threading;

namespace Abakon15WPF.Views
{
    //    public class ViewsControler : IProgressView
    //    {

    //        public IProgressView ProgressView
    //        {
    //            get
    //            {
    //                return this;
    //            }
    //        }

    //        void DoEvents()
    //        {
    //            Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new Action(delegate { }));
    //        }

    //        ProgressBarWindow m_ProgressBarWin;
    //        public void ProgressViewInit(int stepCount, string titleText, bool showCancel)
    //        {
    //            ProgressBarVM vm = new ProgressBarVM(titleText, stepCount, showCancel);
    //            m_ProgressBarWin = ProgressBarWindow.OpenProgressBarWin(vm);
    //            DoEvents();
    //        }

    //        public bool ProgressViewUpdate(int progress, string titleText)
    //        {
    //            if (m_ProgressBarWin != null)
    //            {
    //                ProgressBarVM vm = m_ProgressBarWin.DataContext as ProgressBarVM;
    //                vm.Progress = progress;
    //                vm.ProgressPerCent = vm.StepCount != 0 ? (decimal)vm.Progress / (decimal)vm.StepCount : 0;
    //                if (titleText != null) vm.Title = titleText;
    //                DoEvents();
    //                return vm.Cancel;
    //            }
    //            else
    //                return false;
    //        }

    //        public bool ProgressViewUpdate(int progress)
    //        {
    //            return ProgressViewUpdate(progress, null);
    //        }

    //        public void ProgressViewRemove()
    //        {
    //            if (m_ProgressBarWin != null)
    //            {
    //                m_ProgressBarWin.AllowClose = true;
    //                m_ProgressBarWin.Close();
    //                m_ProgressBarWin = null;
    //            }
    //        }

    //}
}
