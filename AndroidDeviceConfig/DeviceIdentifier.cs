using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace AndroidDeviceConfig
{
    /// <summary>
    /// identifies ONE specific device version
    /// </summary>
    [Serializable]
    public class DeviceIdentifier
    {  
        private IdentifierType _Type;

        /// <summary>
        /// Holds additional argument for this type
        /// </summary>
        [XmlArrayItem("Argument")]
        public List<string> AdditionalArgs = new List<string>();

        /// <summary>
        /// Specifies the method to identificate the version
        /// </summary>
        [XmlAttribute]
        public IdentifierType Type
        {
            get { return _Type; }
            set { if(!Type.Equals(value))_Type = value; }
        }
    }
}