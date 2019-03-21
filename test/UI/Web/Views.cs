using Microsoft.Dynamics365.UIAutomation.Api;
using Microsoft.Dynamics365.UIAutomation.Browser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Security;

namespace UI.Tests
{
    [TestClass]
    public class Views
    {
        private static SecureString _username;
        private static SecureString _password;
        private static Uri _uri;

        public static BrowserOptions _options;

        [ClassInitialize]
        public static void SetupTests(TestContext testContext)
        {
            _username = testContext.Properties["upn"].ToString().ToSecureString();
            _password = testContext.Properties["password"].ToString().ToSecureString();
            _uri = new Uri(testContext.Properties["orgUrl"].ToString());

            _options = new BrowserOptions
            {
                BrowserType = (BrowserType)Enum.Parse(typeof(BrowserType), testContext.Properties["browserType"].ToString()),
                PrivateMode = true,
                FireEvents = true,
                Headless = false,
                UserAgent = false
            };
        }

        [TestMethod]
        public void Login()
        {
            using (var xrmBrowser = new Browser(_options))
            {
                xrmBrowser.LoginPage.Login(_uri, _username, _password);
            }
        }

        // EasyRepro does not currently support the latest UCI in v9.1.x
        //[TestMethod]
        //public void SwitchView()
        //{
        //    using (var xrmBrowser = new Browser(_options))
        //    {
        //        xrmBrowser.LoginPage.Login(_uri, _username, _password);
        //        //xrmBrowser.GuidedHelp.CloseGuidedHelp();

        //        xrmBrowser.Grid.SwitchView("Active Accounts");

        //    }
        //}
    }
}