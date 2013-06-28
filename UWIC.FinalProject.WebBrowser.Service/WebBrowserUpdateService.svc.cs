using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace UWIC.FinalProject.WebBrowser.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "WebBrowserUpdateService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select WebBrowserUpdateService.svc or WebBrowserUpdateService.svc.cs at the Solution Explorer and start debugging.
    public class WebBrowserUpdateService : IWebBrowserUpdateService
    {
        public Dictionary<string, object> CheckForUpdates(Version currentVersion)
        {
            try
            {
                return new CheckForUpdatesHandler().CheckForUpdates(currentVersion);
            }
            catch (FaultException ex)
            {
                throw;
            }
        }
    }
}
