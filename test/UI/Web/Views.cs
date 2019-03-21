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
        private readonly SecureString _username = System.Configuration.ConfigurationManager.AppSettings["OnlineUsername"].ToSecureString();
        private readonly SecureString _password = System.Configuration.ConfigurationManager.AppSettings["OnlinePassword"].ToSecureString();
        private readonly Uri _uri = new Uri(System.Configuration.ConfigurationManager.AppSettings["OnlineCrmUrl"].ToString());

        [TestMethod]
        public void SwitchView()
        {
            using (var xrmBrowser = new Browser(TestSettings.Options))
            {

                xrmBrowser.LoginPage.Login(_uri, _username, _password);
                xrmBrowser.GuidedHelp.CloseGuidedHelp();

<<<<<<< HEAD
                xrmBrowser.Navigation.OpenSubArea("Account Management", "Accounts");
=======
                xrmBrowser.Navigation.OpenSubArea("Sales", "Accounts");
>>>>>>> upstream/master
                xrmBrowser.Grid.SwitchView("Active Accounts");

            }
        }
    }
}