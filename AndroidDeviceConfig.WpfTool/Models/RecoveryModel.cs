using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AndroidDeviceConfig.WpfTool.Models
{
    public sealed class RecoveryModel : INotifyPropertyChanged
    {
        private readonly Recovery _Recovery;

        public RecoveryModel(Recovery recovery)
        {
            _Recovery = recovery;
        }

        public string Name
        {
            get { return _Recovery.Name; }
            set
            {
                if (Name == value) return;
                _Recovery.Name = value;
                OnPropertyChanged();
            }
        }

        public string DownloadUrl
        {
            get { return _Recovery.DownloadUrl; }
            set
            {
                if (_Recovery.DownloadUrl == value) return;
                _Recovery.DownloadUrl = value;
                OnPropertyChanged();
            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public Recovery GetRecovery()
        {
            return _Recovery;
        }
    }
}