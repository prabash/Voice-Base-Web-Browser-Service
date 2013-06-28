using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace UWIC.FinalProject.WebBrowser.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IWebBrowserUpdateService" in both code and config file together.
    [ServiceContract]
    public interface IWebBrowserUpdateService
    {
        [OperationContract]
        Dictionary<string,object> CheckForUpdates(Version currentVersion);
    }
}
