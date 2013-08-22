using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Xml.Linq;

namespace linq2ga.Sample.Managers
{
    public static class Settings
    {
        public static string ClientIdentifier
        {
            get
            {
                return getValue("ClientIdentifier");
            }
        }

        public static string ClientSecret
        {
            get
            {
                return getValue("ClientSecret");
            }
        }

        public static string ProfileId
        {
            get
            {
                return getValue("ProfileId");
            }
        }

        public static string RefreshToken
        {
            get
            {
                return getValue("RefreshToken");
            }
            set
            {
                setValue("RefreshToken", value);
            }
        }

        private static string getValue(string tagname)
        {
            string appDataPath = HttpContext.Current.Server.MapPath("~/App_Data/");
            string settingsPath = Path.Combine(appDataPath, "Settings.xml");
            XDocument xdoc = XDocument.Load(settingsPath);
            return xdoc.Document.Root.Descendants(tagname).First().Value;
        }

        private static void setValue(string tagname, string value)
        {
            string appDataPath = HttpContext.Current.Server.MapPath("~/App_Data/");
            string settingsPath = Path.Combine(appDataPath, "Settings.xml");
            XDocument xdoc = XDocument.Load(settingsPath);
            xdoc.Document.Root.Descendants(tagname).First().Value = value;
            xdoc.Save(settingsPath);
        }
    }
}