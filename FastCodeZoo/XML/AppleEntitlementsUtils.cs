using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace FastCodeZoo.XML
{
    public class AppleEntitlementsUtils
    {
        private const string EntitlementsArrayXPath = "key";
        private const string EntitlementsArrayKey = "com.apple.developer.applesignin";

        public static Exception AddSignWithApple
            (string entitlementsPath)
        {
            if (string.IsNullOrEmpty(entitlementsPath))
            {
                return new Exception("entitlementsPath is empty");
            }

            if (!File.Exists(entitlementsPath))
            {
                return new FileNotFoundException($"entitlementsPath not found at: {entitlementsPath}");
            }

            XmlDocument entitlements = new XmlDocument();
            try
            {
                entitlements.Load(entitlementsPath);
                XmlNode plist = entitlements.SelectSingleNode("plist");
                if (plist == null)
                {
                    return new AppleEntitlementsException($"plist node not found");
                }

                XmlNode dict = plist.SelectSingleNode("dict");
                if (dict == null)
                {
                    return new AppleEntitlementsException($"plist.dict node not found");
                }

                XmlNodeList keyList = dict.SelectNodes(EntitlementsArrayXPath);
                if (keyList == null || keyList.Count == 0)
                {
                    XmlElement itemElement = entitlements.CreateElement(EntitlementsArrayXPath);
                    XmlText itemText = entitlements.CreateTextNode(EntitlementsArrayKey);
                    itemElement.AppendChild(itemText);
                    dict.AppendChild(itemElement);
                    XmlElement stringItem = entitlements.CreateElement("string");
                    XmlText defaultText = entitlements.CreateTextNode("Default");
                    stringItem.AppendChild(defaultText);
                    XmlElement arrayItem = entitlements.CreateElement("array");
                    arrayItem.AppendChild(stringItem);
                    dict.AppendChild(arrayItem);
                }
                else
                {
                    bool hasAddKey = false;
                    foreach (XmlElement key in keyList)
                    {
                        if (key.InnerText == EntitlementsArrayKey)
                        {
                            hasAddKey = true;
                            break;
                        }
                    }

                    if (!hasAddKey)
                    {
                        XmlElement itemElement = entitlements.CreateElement(EntitlementsArrayXPath);
                        XmlText itemText = entitlements.CreateTextNode(EntitlementsArrayKey);
                        itemElement.AppendChild(itemText);
                        dict.AppendChild(itemElement);
                        XmlElement stringItem = entitlements.CreateElement("string");
                        XmlText defaultText = entitlements.CreateTextNode("Default");
                        stringItem.AppendChild(defaultText);
                        XmlElement arrayItem = entitlements.CreateElement("array");
                        arrayItem.AppendChild(stringItem);
                        dict.AppendChild(arrayItem);
                    }
                }

                entitlements.Save(entitlementsPath);
            }
            catch (Exception e)
            {
                return new AppleEntitlementsException($"entitlements load: {entitlementsPath} error", e);
            }

            return null;
        }
    }

    public class AppleEntitlementsException : Exception
    {
        public AppleEntitlementsException(string message) : base($"AppleEntitlements {message}")
        {
        }

        public AppleEntitlementsException(string message, Exception innerException) : base(
            $"AppleEntitlements {message}", innerException)
        {
        }
    }
}