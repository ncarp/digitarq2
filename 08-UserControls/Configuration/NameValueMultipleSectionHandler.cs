// Reference: https://github.com/Jodan-pz/spoolpad/blob/master/RuntimeConfiguration/NameValueMultipleSectionHandler.cs
//==============================================================================================================================================================

using System;
using System.Collections;
using System.Collections.Specialized;
using System.Configuration;
using System.Globalization;
using System.Reflection;
using System.Xml;

namespace ADP.Configuration
{
    public class NameValueMultipleSectionHandler : NameValueCollection, IConfigurationSectionHandler
    {
        public NameValueMultipleSectionHandler() : base()
        {
        }

        public NameValueMultipleSectionHandler(IEqualityComparer comp) : base(comp)
        {
        }

        public NameValueMultipleSectionHandler(NameValueCollection value) : base(value)
        {
        }

        public void SetReadOnly()
        {
            IsReadOnly = true;
        }

        static internal NameValueCollection GetConfig(string sectionName)
        {
            return (NameValueCollection)ConfigurationManager.GetSection(sectionName);
        }

        public object Create(object parent, object context, XmlNode section)
        {
            NameValueCollection collection = null;

            if (parent == null)
            {
                collection = new NameValueMultipleSectionHandler(StringComparer.InvariantCultureIgnoreCase);
            }
            else
            {
                collection = new NameValueMultipleSectionHandler(parent as NameValueCollection);
            }

            foreach (XmlNode xmlNode in section.ChildNodes)
            {
                if (xmlNode.NodeType == XmlNodeType.Element)
                {
                    switch (xmlNode.Name)
                    {
                        case "add":
                            collection.Add(xmlNode.Attributes["key"].Value, xmlNode.Attributes["value"].Value);
                            break;
                        case "remove":
                            collection.Remove(xmlNode.Attributes["key"].Value);
                            break;
                        case "clear":
                            collection.Clear();
                            break;
                    }
                }
            }
            return collection;
        }
    }
}
