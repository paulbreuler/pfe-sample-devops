using Microsoft.Dynamics365.UIAutomation.Browser;
using System;

namespace UI.Tests
{
    public static class TestSettings
    {
        private static readonly string Type = System.Configuration.ConfigurationManager.AppSettings["BrowserType"].ToString();

        public static BrowserOptions Options = new BrowserOptions
        {
            BrowserType = (BrowserType)Enum.Parse(typeof(BrowserType), Type),
            PrivateMode = true,
            FireEvents = true,
            Headless = false,
            UserAgent = false
        };
    }
}