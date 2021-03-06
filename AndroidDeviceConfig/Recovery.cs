﻿using System;
using System.Xml.Serialization;

namespace AndroidDeviceConfig
{
    /// <summary>
    /// Holds a recovery with name and url
    /// </summary>
    [Serializable]
    public class Recovery
    {
        private string _Name = String.Empty;
        private string _DownloadUrl = String.Empty;
        private string _Md5 = String.Empty;

        [XmlAttribute]
        public string Md5
        {
            get { return _Md5; }
            set { _Md5 = value; }
        }

        /// <summary>
        /// The name of the recovery
        /// </summary>
        [XmlAttribute]
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        /// <summary>
        /// The url to download the recoveries .img
        /// </summary>
        [XmlAttribute]
        public string DownloadUrl
        {
            get { return _DownloadUrl; }
            set
            {
                if (!DownloadUrl.Equals(value) && Uri.IsWellFormedUriString(value, UriKind.Absolute))
                {
                    _DownloadUrl = value;
                }
            }
        }
    }
}