using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using AndroidDeviceConfig.WpfTool.Annotations;

namespace AndroidDeviceConfig.WpfTool.Models
{
    public class IdentifierModel : INotifyPropertyChanged
    {
        private DeviceIdentifier _Identifier;
        private ObservableCollection<string> _AdditionalArgs ;

        public IdentifierModel(DeviceIdentifier deviceIdentifier)
        {
            _Identifier = deviceIdentifier;

            _AdditionalArgs = new ObservableCollection<string>(_Identifier.AdditionalArgs);
            _AdditionalArgs.CollectionChanged += _AdditionalArgs_CollectionChanged;
        }

        void _AdditionalArgs_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged("AdditionalArgs");
        }

        public IdentifierType Type
        {
            get { return _Identifier.Type; }
            set
            {
                if (Type != value)
                {
                    _Identifier.Type = value;
                    OnPropertyChanged();
                }
            }
        }

        public DeviceIdentifier GetIdentifier()
        {
            _Identifier.AdditionalArgs.Clear();

            foreach (string additionalArg in AdditionalArgs)
            {
                _Identifier.AdditionalArgs.Add(additionalArg);
            }

            return _Identifier;
        }

        public ObservableCollection<string> AdditionalArgs
        {
            get { return _AdditionalArgs; }
            set
            {
                if (AdditionalArgs != value)
                {
                    _AdditionalArgs = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}