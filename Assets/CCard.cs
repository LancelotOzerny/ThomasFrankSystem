using System.IO;
using System.Xml;
using UnityEngine;

public class CCard : MonoBehaviour
{
    [SerializeField] private string xmlPath = string.Empty;
    private string startData =  "<?xml version = \"1.0\" encoding = \"utf-8\" ?>" +
                                "\n<cards>\n</cards>";
    private void Awake()
    {
        xmlPath = xmlPath.Replace("/", "\\");

        if (xmlPath == string.Empty)
        {
            xmlPath = "data\\data.xml";
        }

        if (File.Exists(xmlPath) == false)
        {
            string[] path = xmlPath.Split('\\');
            string currentPath = ".";

            for (int i = 0; i < path.Length - 1; i++)
            {
                currentPath += "\\" + path[i];
                if (Directory.Exists(currentPath) == false)
                {
                    Directory.CreateDirectory(currentPath);
                }
            }

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.InnerXml = startData;
            xmlDoc.Save(xmlPath);
        }
    }
}