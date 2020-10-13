using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Xunit.Sdk;

namespace FastCodeZoo.XML
{
    public static class XmlOperator
    {
        public static Exception InjectElementWithTexts
        (string xmlPath, string rootXPath, string targetXPath,
            string injectElement, List<string> textList)
        {
            if (string.IsNullOrEmpty(xmlPath))
            {
                return new Exception("xmlPath is empty");
            }

            if (string.IsNullOrEmpty(rootXPath))
            {
                return new Exception("rootXPath is empty");
            }

            if (string.IsNullOrEmpty(targetXPath))
            {
                return new Exception("targetXPath is empty");
            }

            if (string.IsNullOrEmpty(injectElement))
            {
                return new Exception("injectElement is empty");
            }

            if (textList == null)
            {
                return new Exception("attributes is empty");
            }

            if (textList.Count == 0)
            {
                return new Exception("attributes.Count is 0");
            }

            if (!File.Exists(xmlPath))
            {
                return new FileNotFoundException("xmlPath not found");
            }

            try
            {
                XmlDocument xmlRoot = new XmlDocument();
                xmlRoot.Load(xmlPath);
                var selectRootNode = xmlRoot.SelectSingleNode(rootXPath);
                if (selectRootNode == null)
                {
                    return new Exception($"rootXPath {rootXPath} not exist");
                }

                XmlNode targetNode = selectRootNode.SelectSingleNode(targetXPath);
                if (targetNode == null)
                {
                    return new Exception($"targetXPath {targetXPath} not exist");
                }

                XmlNodeList injectList = selectRootNode.SelectNodes(injectElement);
                List<string> needInject = new List<string>();
                if (injectList == null)
                {
                    needInject.AddRange(textList);
                }
                else
                {
                    if (injectList.Count == 0)
                    {
                        needInject.AddRange(textList);
                    }
                    else
                    {
                        foreach (XmlElement inject in injectList)
                        {
                            string s = inject.GetAttribute(injectElement);
                            if (!textList.Contains(s))
                            {
                                needInject.Add(s);
                            }
                        }
                    }
                }


                if (needInject.Count > 0)
                {
                    foreach (string i in needInject)
                    {
                        XmlElement itemElement = xmlRoot.CreateElement(injectElement);
                        XmlText itemText = xmlRoot.CreateTextNode(i);
                        itemElement.AppendChild(itemText);
                        targetNode.AppendChild(itemElement);
                    }

                    xmlRoot.Save(xmlPath);
                }

                return null;
            }
            catch (Exception e)
            {
                return new XmlOperatorException($"xmlPath {xmlPath} error", e);
            }
        }
    }

    public class XmlOperatorException : Exception
    {
        public XmlOperatorException(string message) : base(message)
        {
        }

        public XmlOperatorException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}