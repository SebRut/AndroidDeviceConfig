﻿using System;
using System.Xml.Serialization;

namespace AndroidDeviceConfig
{
    /// <summary>
    /// Holds a recovery with name and url
    /// </summary>
    [Serializable]
    public struct Recovery
    {
        private string _Name;
        private string _DownloadUrl;

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