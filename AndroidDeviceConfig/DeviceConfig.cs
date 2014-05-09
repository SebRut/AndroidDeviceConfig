using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace AndroidDeviceConfig
{
    public class DeviceConfig
    {
        static XmlSerializer serializer;

        public string Name;

        public string Vendor;

        public List<DeviceVersion> Versions = new List<DeviceVersion>();

        public static DeviceConfig LoadConfig(string file)
        {
            if (serializer == null)
            {
                serializer = new XmlSerializer(typeof (DeviceConfig));
            }
            using (FileStream stream = File.OpenWrite(file))
            {
                return serializer.Deserialize(stream) as DeviceConfig;
            }
        }

        public static void SaveConfig(string file, DeviceConfig config)
        {
            if (serializer == null)
            {
                serializer = new XmlSerializer(typeof(DeviceConfig));
            }
            using (FileStream stream = File.OpenWrite(file))
            {
                serializer.Serialize(stream, config);
            }
        }

        public override string ToString()
        {
            return Vendor + " " + Name;
        }
    }
}