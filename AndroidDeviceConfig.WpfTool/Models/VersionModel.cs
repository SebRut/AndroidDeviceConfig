using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AndroidDeviceConfig.WpfTool.Models
{
    public sealed class VersionModel : INotifyPropertyChanged
    {
        private ObservableCollection<ActionSetModel> _ActionSets;
        private ObservableCollection<RecoveryModel> _Recoveries;
        private ObservableCollection<IdentifierModel> _Identifiers;
        private DeviceVersion version;

        public VersionModel(DeviceVersion version)
        {
            this.version = version;
            _Recoveries = new ObservableCollection<RecoveryModel>();
            _Recoveries.CollectionChanged += recoveries_CollectionChanged;

            foreach (Recovery recovery in this.version.Recoveries)
            {
                _Recoveries.Add(new RecoveryModel(recovery));
            }

            ActionSets = new ObservableCollection<ActionSetModel>();
            ActionSets.CollectionChanged += actionSets_CollectionChanged;

            foreach (ActionSet actionSet in this.version.PossibleActions)
            {
                ActionSets.Add(new ActionSetModel(actionSet));
            }

            Identifiers = new ObservableCollection<IdentifierModel>();
            Identifiers.CollectionChanged += _Identifiers_CollectionChanged;

            foreach (DeviceIdentifier deviceIdentifier in this.version.Identifiers)
            {
                Identifiers.Add(new IdentifierModel(deviceIdentifier));
            }
        }

        void _Identifiers_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged("Identifiers");
        }

        public ObservableCollection<RecoveryModel> Recoveries
        {
            get { return _Recoveries; }
            set
            {
                if (Recoveries == value) return;
                _Recoveries = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<ActionSetModel> ActionSets
        {
            get { return _ActionSets; }
            set
            {
                if (ActionSets == value) return;
                _ActionSets = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<IdentifierModel> Identifiers
        {
            get { return _Identifiers; }
            set {
                if (Identifiers != value)
                {
                    _Identifiers = value;
                    OnPropertyChanged();
                }  }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        private void actionSets_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged("ActionSets");
        }

        private void recoveries_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged("Recoveries");
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public DeviceVersion GetVersion()
        {
            version.Identifiers.Clear();
            version.PossibleActions.Clear();
            version.Recoveries.Clear();

            foreach (ActionSetModel actionSetModel in ActionSets)
            {
                version.PossibleActions.Add(actionSetModel.GetActionSet());
            }

            foreach (RecoveryModel recoveryModel in Recoveries)
            {
                version.Recoveries.Add(recoveryModel.GetRecovery());
            }

            foreach (IdentifierModel identifierModel in Identifiers)
            {
                version.Identifiers.Add(identifierModel.GetIdentifier());
            }

            return version;
        }
    }
}