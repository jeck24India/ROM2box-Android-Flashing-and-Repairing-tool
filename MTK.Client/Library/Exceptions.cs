using System;

namespace clicktoolpro.Shared.Exceptions
{
    internal class DeviceSecurityNotSupportedException : Exception
    {
        public DeviceSecurityNotSupportedException()
            : base("Device security not supported") { }
    }
}
