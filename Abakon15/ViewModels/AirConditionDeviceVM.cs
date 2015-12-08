using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using AbakonDataModel;
using System.ComponentModel;
using System.Windows;
using Abakon15.Infrastructure;
using Abakon15.Utility;
namespace Abakon15.ViewModels
{
    class AirConditionDeviceVM : ViewModelBase
    {
        private ObservableCollection<AirConditionDevice> _AirConditionDeviceCollection;
        public ObservableCollection<AirConditionDevice> AirConditionDeviceCollection
        {
            get { return _AirConditionDeviceCollection; }
            set { SetField(ref _AirConditionDeviceCollection, value, () => AirConditionDeviceCollection); }
        }

        private AirConditionDevice _currentAirConditionDevice;
        public AirConditionDevice CurrentAirConditionDevice
        {
            get { return _currentAirConditionDevice; }
            set { SetField(ref _currentAirConditionDevice, value, () => CurrentAirConditionDevice); }
        }

        public AirConditionDeviceVM()
        {
            if (!(bool)(DesignerProperties.IsInDesignModeProperty.GetMetadata(typeof(DependencyObject)).DefaultValue))
            {
                LoadAirConditionDeviceCollection();
            }
        }

        private void LoadAirConditionDeviceCollection()
        {
            AirConditionDeviceCollection = new ObservableCollection<AirConditionDevice>(AirConditionDevice.Load());
        }

        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            switch (e.PropertyName)
            {

                case "CurrentAirConditionDevice":
                    {
                        deleteAskObjectName = CurrentAirConditionDevice != null ? CurrentAirConditionDevice.AirConditionDeviceId : "";
                        break;
                    }
                default:
                    break;
            }
        }

        protected override bool CanDeleteCommand()
        {
            return base.CanDeleteCommand() && CurrentAirConditionDevice != null;
        }

        protected override void DeleteFromBase()
        {
            AirConditionDevice x = CurrentAirConditionDevice;
            AirConditionDevice.Delete(x);
            if (AirConditionDeviceCollection.Contains(x))
            {
                AirConditionDeviceCollection.Remove(x);
            }
        }

        RelayCommand _newAirConditionDevice;
        public RelayCommand NewAirConditionDevice
        {
            get
            {

                return _newAirConditionDevice ??
                       (_newAirConditionDevice = new RelayCommand(
                        param =>
                        {

                            AirConditionDevice newRec = AirConditionDevice.Create();

                            AirConditionDeviceCollection.Add(newRec);
                            CurrentAirConditionDevice = newRec;

                            RaisePropertyChanged("CurrentAirConditionDevice");

                        },

                        param => true
                        ));
            }
        }
    }
}
