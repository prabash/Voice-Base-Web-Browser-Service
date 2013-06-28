using System;
using System.Collections.Generic;
using System.Xml;

namespace UWIC.FinalProject.WebBrowser.Service
{
    public class CheckForUpdatesHandler
    {
        public Dictionary<string, object> CheckForUpdates(Version currentVersion)
        {
            var results = new Dictionary<string, object> {{"Available", false}, {"DownloadLink", null}};
            var downloalUrl = "";
            Version newVersion = null;
            const string xmlUrl = "C://VebBrowserUpdates//update.xml";
            var reader = new XmlTextReader(xmlUrl);
            try
            {
                reader.MoveToContent();
                var elementName = "";
                if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "VoiceBrowser"))
                {
                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Element)
                            elementName = reader.Name;
                        else if ((reader.NodeType == XmlNodeType.Text) && (reader.HasValue))
                        {
                            switch (elementName)
                            {
                                case "version":
                                    {
                                        newVersion = new Version(reader.Value);
                                        break;
                                    }
                                case "url":
                                    {
                                        downloalUrl = reader.Value;
                                        break;
                                    }
                            }
                        }
                    }
                }
                // how to get the version of an application
                //Version currentVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;

                if (currentVersion.CompareTo(newVersion) < 0)
                {
                    results["Available"] = true;
                    results["url"] = downloalUrl;
                }
                else
                {
                    results["Available"] = false;
                    results["url"] = "";
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                reader.Close();
            }
            return results;
        }
    }
}