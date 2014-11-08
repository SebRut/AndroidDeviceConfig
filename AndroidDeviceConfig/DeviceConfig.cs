using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;

namespace AndroidDeviceConfig
{
    /// <summary>
    /// Holds a complete device config with versions, name, vendor etc.
    /// </summary>
    [Serializable]
    public class DeviceConfig
    {
        static XmlSerializer serializer;

        private string _Name = String.Empty;

        private string _Vendor = String.Empty;

        public string ADCVersion = "0.2";

        /// <summary>
        /// Holds the different versions of the device model available
        /// </summary>
        public List<DeviceVersion> Versions = new List<DeviceVersion>();

        /// <summary>
        /// The name of the device
        /// </summary>
        [XmlAttribute]
        public string Name
        {
            get { return _Name; }
            set { if(!Equals(Name, value)) _Name = value; }
        }

        /// <summary>
        /// The vendor of the device
        /// </summary>
        [XmlAttribute]
        public string Vendor
        {
            get { return _Vendor; }
            set { if(!Vendor.Equals(value))_Vendor = value; }
        }

        /// <summary>
        /// Derializises a file into a DeviceConfig object
        /// </summary>
        /// <param name="file">the file to deserialize</param>
        /// <returns>a new DeviceConfig object</returns>
        public static DeviceConfig LoadConfig(string file)
        {
            if (serializer == null)
            {
                serializer = new XmlSerializer(typeof (DeviceConfig));
            }
            using (FileStream stream = File.OpenRead(file))
            {
                return serializer.Deserialize(stream) as DeviceConfig;
            }
        }

        /// <summary>
        /// Serializes a DeviceConfig object into a file
        /// </summary>
        /// <param name="file">the destination file</param>
        /// <param name="config">the config to serialize</param>
        public static void SaveConfig(string file, DeviceConfig config)
        {
            if (serializer == null)
            {
                serializer = new XmlSerializer(typeof(DeviceConfig));
            }
            using (FileStream stream = File.Create(file))
            {
                serializer.Serialize(stream, config);
            }
        }

        /// <summary>
        /// Serializes the current Deviceconfig object into a file
        /// </summary>
        /// <param name="file">the destination file</param>
        public void SaveConfig(string file)
        {
            DeviceConfig.SaveConfig(file, this);
        }
    }
}