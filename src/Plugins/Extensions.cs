namespace PFE.Sample.Plugins
{
    using Microsoft.Xrm.Sdk;
    using System;

    public static class Extensions
    {
        public static void Write(this ITracingService service, string message)
        {
            service.Trace(DateTime.UtcNow.ToString("s") + " - " + message);
        }
    }
}