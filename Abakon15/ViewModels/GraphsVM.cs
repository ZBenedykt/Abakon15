using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows;
using AbakonDataModel;
using System.Collections.ObjectModel;
using Abakon15.Infrastructure;
using Abakon15.Utility;

namespace Abakon15.ViewModels
{
    public class GraphsVM : ViewModelBase
    {

        public PrzyrzadPomiarowy CurrentPrzyrzadPomiarowy
        { get; set; }

        private ObservableCollection<GraphsElementVM> _singleGraphVM;
        public ObservableCollection<GraphsElementVM> SingleGraphVM
        {
            get { return _singleGraphVM; }
            set { SetField(ref _singleGraphVM, value, () => SingleGraphVM); }
        }

        GraphsElementVM _currentSingleGraphVM;
        internal GraphsElementVM CurrentSingleGraphVM
        {
            get { return _currentSingleGraphVM; }
            set { SetField(ref _currentSingleGraphVM, value, () => CurrentSingleGraphVM); }
        }

        string _excelFile = string.Empty;
        public string ExcelFile
        {
            get { return _excelFile; }
            set { SetField(ref _excelFile, value, () => ExcelFile); }
        }



        public GraphsVM(PrzyrzadPomiarowy equipment)
        {
            if (!(bool)(DesignerProperties.IsInDesignModeProperty.GetMetadata(typeof(DependencyObject)).DefaultValue))
            {
                CurrentPrzyrzadPomiarowy = equipment;
                if (equipment.AktualnaKalibracja != null && equipment.AktualnaKalibracja.ExcelFile != null)
                {
                    ExcelFile = equipment.AktualnaKalibracja.ExcelFile.filePath.Path + @"\" + equipment.AktualnaKalibracja.ExcelFile.FileName;

                }
            }
        }

        RelayCommand m_showFileCommand;
        public RelayCommand ShowFileCommand
        {
            get
            {
                if (m_showFileCommand == null)
                {
                    m_showFileCommand = new RelayCommand(
                        param => FilesUtility.OpenFile(ExcelFile),
                        param => ExcelFile != ""
                        );
                }
                return m_showFileCommand;
            }
        }


    }
}
