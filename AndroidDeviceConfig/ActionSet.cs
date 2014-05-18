using System;
using System.Collections.Generic;

namespace AndroidDeviceConfig
{
    /// <summary>
    /// Descriptions actions required to perform the described task
    /// </summary>
    [Serializable]
    public class ActionSet
    {
        /// <summary>
        /// The actions performed top->down
        /// </summary>
        public List<Action> Actions = new List<Action>();
        private string _Description;

        /// <summary>
        /// A description of the Actinos performed
        /// </summary>
        public string Description
        {
            get { return _Description; }
            set { if(!Description.Equals(value))_Description = value; }
        }
    }
}