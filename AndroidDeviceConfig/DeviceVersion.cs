using System.Collections.Generic;

namespace AndroidDeviceConfig
{
    public class DeviceVersion
    {
        public List<DeviceIdentifier> Identifiers = new List<DeviceIdentifier>();
        
        public List<Recovery> Recoveries = new List<Recovery>();

        public List<ActionSet> PossibleActions = new List<ActionSet>();
    }
}