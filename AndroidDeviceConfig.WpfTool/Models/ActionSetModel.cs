using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using AndroidDeviceConfig.WpfTool.Annotations;

namespace AndroidDeviceConfig.WpfTool.Models
{
    public class ActionSetModel : INotifyPropertyChanged
    {
        private ActionSet actionSet;

        public ActionSetModel(ActionSet actionSet)
        {
            this.actionSet = actionSet;
        }

        private ObservableCollection<ActionModel> actions;

        public ObservableCollection<ActionModel> Actions
        {
            get { return actions; }
            set
            {
                if (Actions != value)
                {
                    actions = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Description
        {
            get { return actionSet.Description; }
            set {
                if (Description != value)
                {
                    actionSet.Description = value;
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

        public ActionSet GetActionSet()
        {
            actionSet.Actions.Clear();

            foreach (ActionModel actionModel in Actions)
            {
                actionSet.Actions.Add(actionModel.GetAction());
            }

            return actionSet;
        }
    }
}