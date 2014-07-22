using System;
using System.Collections.Generic;
using System.Xml.Serialization;

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
        [XmlArray]
        public List<Action> Actions = new List<Action>();
        private string _Description = String.Empty;

        /// <summary>
        /// A description of the Actinos performed
        /// </summary>
        [XmlElement]
        public string Description
        {
            get { return _Description; }
            set { if(!Description.Equals(value))_Description = value; }
        }
    }
}