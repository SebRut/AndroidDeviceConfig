namespace AndroidDeviceConfig
{
    /// <summary>
    /// Holds the varipus identifitication types
    /// </summary>
    public enum IdentifierType
    {
        /// <summary>
        /// identification via ro.product.name; additional args = codename to search
        /// </summary>
        Name,
        /// <summary>
        /// identification via ro.product.device or ro.build.product
        /// </summary>
        ProductDevice,
        /// <summary>
        /// identification via OS version; additional args = OS version, format X.X.X
        /// </summary>
        AndroidVersion
    }
}