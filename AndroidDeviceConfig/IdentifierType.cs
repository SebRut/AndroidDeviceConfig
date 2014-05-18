namespace AndroidDeviceConfig
{
    /// <summary>
    /// Holds the varipus identifitication types
    /// </summary>
    public enum IdentifierType
    {
        /// <summary>
        /// identification via codename; additional args = codename to search
        /// </summary>
        CodeName,
        /// <summary>
        /// identification via OS version; additional args = OS version, format X.X.X
        /// </summary>
        AndroidVersion
    }
}