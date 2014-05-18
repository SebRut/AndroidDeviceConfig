using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace AndroidDeviceConfig
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class Action
    {
        private ActionType _Type;

        /// <summary>
        /// Holds additional infos, for example urls
        /// </summary>
        public List<string> AdditionalInfos = new List<string>();
        
        /// <summary>
        /// Defines the type of this action
        /// </summary>
        [XmlAttribute]
        public ActionType Type
        {
            get { return _Type; }
            set { if(!Type.Equals(value)) _Type = value; }
        }
    }
}