using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using AndroidDeviceConfig.WpfTool.Annotations;

namespace AndroidDeviceConfig.WpfTool
{
    class DeviceConfigViewModel : INotifyPropertyChanged
    {
        private DeviceConfig _Model;

        public DeviceConfig Model
        {
            get { return _Model; }
        }

        public DeviceConfigViewModel(DeviceConfig model)
        {
            _Model = model;

            foreach (DeviceVersion deviceVersion in _Model.Versions)
            {
                _Versions.Add(deviceVersion);
            }

            _Versions.CollectionChanged += _Versions_CollectionChanged;
        }

        void _Versions_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            _Model.Versions = new List<DeviceVersion>(_Versions);
            OnPropertyChanged("Versions");
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public string Vendor
        {
            get { return Model.Vendor; }
            set
            {
                if (Vendor == value) return;
                _Model.Vendor = value;
                OnPropertyChanged("Vendor");
            }
        }

        private string _Name;
        public string Name
        {
            get { return Model.Name; }
            set
            {
                if (Name == value) return;
                _Model.Name = value;
                OnPropertyChanged("Name");
            }
        }

        public ObservableCollection<DeviceVersion> Versions
        {
            get { return _Versions; }
            set
            {
                if (_Versions == value) return;
                _Versions = value;
                OnPropertyChanged("Versions");
            }
        }
        private ObservableCollection<DeviceVersion> _Versions = new ObservableCollection<DeviceVersion>();
    }
}
