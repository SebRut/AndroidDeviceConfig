using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AndroidDeviceConfig.WpfTool.Models
{
    public class DeviceConfigModel : INotifyPropertyChanged
    {
        private readonly DeviceConfig _Config;
        private ObservableCollection<VersionModel> _Versions;

        public DeviceConfigModel(DeviceConfig config)
        {
            _Config = config;
            Versions = new ObservableCollection<VersionModel>();
            Versions.CollectionChanged += versions_CollectionChanged;

            foreach (DeviceVersion deviceVersion in _Config.Versions)
            {
                Versions.Add(new VersionModel(deviceVersion));
            }
        }

        public DeviceConfigModel() : this(new DeviceConfig())
        {
            
        }

        public string Vendor
        {
            get { return _Config.Vendor; }
            set
            {
                if (_Config.Vendor == value) return;
                _Config.Vendor = value;
                OnPropertyChanged();
            }
        }

        public string Name
        {
            get { return _Config.Name; }
            set
            {
                if (_Config.Name == value) return;
                _Config.Name = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<VersionModel> Versions
        {
            get { return _Versions; }
            set
            {
                if (Versions == value) return;
                _Versions = value;
                OnPropertyChanged();
            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        private void versions_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged("Versions");
            _Config.Versions.Clear();
        }

        public DeviceConfig GetConfig()
        {
            _Config.Versions.Clear();

            foreach (VersionModel versionModel in Versions)
            {
                _Config.Versions.Add(versionModel.GetVersion());
            }

            return _Config;
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}