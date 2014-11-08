using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AndroidDeviceConfig.Test
{
    [TestFixture]
    public class TestDeviceConfig
    {
        [Test]
        [ExpectedException(typeof(FileNotFoundException))]
        public void TestLoadConfigForFileNotFoundException()
        {
            var config = DeviceConfig.LoadConfig("specificFile.xml");
        }

        [Test]
        public void TestSaveEmptyConfig()
        {
            DeviceConfig config = new DeviceConfig();
            config.SaveConfig("config.xml");
        }

        [TearDown]
        public void TearDown()
        {
            if (File.Exists("config.xml"))
                File.Delete("config.xml");
        }
    }
}
