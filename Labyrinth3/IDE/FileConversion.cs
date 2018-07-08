// Decompiled with JetBrains decompiler
// Type: Labyrinth.FileConversion
// Assembly: Labyrinth, Version=3.6.1928.15690, Culture=neutral, PublicKeyToken=null
// MVID: 1462002E-0BD1-49D2-9B56-C22E66C903E7
// Assembly location: C:\Dropbox\Workspace\Programs\Labyrinth\Labyrinth.exe

using System.Xml;

namespace Labyrinth
{
    public class FileConversion
    {
        public static bool Convert(ref string content)
        {
            bool flag = false;
            string str = "";
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(content);
            foreach (XmlNode childNode in xmlDocument.DocumentElement.ChildNodes)
            {
                if (childNode.Name == "SaveFormat")
                {
                    str = childNode.InnerText;
                    break;
                }
            }
            if (str == "")
            {
                XmlElement element = xmlDocument.CreateElement("SaveFormat");
                element.InnerText = "3.3";
                xmlDocument.DocumentElement.InsertAfter((XmlNode)element, (XmlNode)null);
                str = "3.3";
                flag = true;
            }
            if (str == "3.3")
            {
                foreach (XmlNode childNode in xmlDocument.DocumentElement.ChildNodes)
                {
                    if (childNode.Name == "SaveFormat")
                    {
                        childNode.InnerText = "3.4";
                        break;
                    }
                }
                str = "3.4";
                flag = true;
            }
            if (str == "3.4")
                flag = true;
            if (flag)
                content = xmlDocument.OuterXml;
            return flag;
        }
    }
}