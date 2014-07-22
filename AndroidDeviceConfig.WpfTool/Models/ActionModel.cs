using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using AndroidDeviceConfig.WpfTool.Annotations;

namespace AndroidDeviceConfig.WpfTool.Models
{
    public class ActionModel : INotifyPropertyChanged
    {
        private Action _Action;
        private ObservableCollection<string> _AdditionalInfos;

        public ActionModel(Action action)
        {
            _Action = action;

            _AdditionalInfos = new ObservableCollection<string>(_Action.AdditionalInfos);
            _AdditionalInfos.CollectionChanged += _AdditionalInfos_CollectionChanged;
        }

        void _AdditionalInfos_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged("AdditionalInfos");
        }

        public ActionType Type
        {
            get { return _Action.Type; }
        }

        public ObservableCollection<string> AdditionalInfos
        {
            get { return _AdditionalInfos; }
            set
            {
                if (AdditionalInfos != value)
                {
                    _AdditionalInfos = value;
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

        public Action GetAction()
        {
            _Action.AdditionalInfos.Clear();

            foreach (string additionalInfo in AdditionalInfos)
            {
                _Action.AdditionalInfos.Add(additionalInfo);
            }

            return _Action;
        }
    }
}