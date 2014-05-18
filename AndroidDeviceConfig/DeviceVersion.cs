using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace AndroidDeviceConfig
{
    /// <summary>
    /// Holds a specific device version
    /// </summary>
    [Serializable]
    public class DeviceVersion
    {
        /// <summary>
        /// Holds the identfiers that could be used to identify that version
        /// </summary>
        [XmlArrayItem("Identifier")]
        public List<DeviceIdentifier> Identifiers = new List<DeviceIdentifier>();
        
        /// <summary>
        /// Holds all recoveries compatible with this version
        /// </summary>
        public List<Recovery> Recoveries = new List<Recovery>();

        /// <summary>
        /// Holds all possible actions for that device
        /// </summary>
        public List<ActionSet> PossibleActions = new List<ActionSet>();
    }
}