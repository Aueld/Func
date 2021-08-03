using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class XMLData : MonoBehaviour
{
    public void CreateXml(string fName)
    {
        //Xml ������ ������ ����

        XmlDocument xmlDoc = new XmlDocument();

        xmlDoc.AppendChild(xmlDoc.CreateXmlDeclaration("1.0", "utf-8", "yes"));

        XmlNode root = xmlDoc.CreateNode(XmlNodeType.Element, "CharacterInfo", string.Empty);
        xmlDoc.AppendChild(root);

        XmlNode child = xmlDoc.CreateNode(XmlNodeType.Element, "Character", string.Empty);
        root.AppendChild(child);

        XmlElement name = xmlDoc.CreateElement("Name");
        name.InnerText = fName;
        child.AppendChild(name);

        XmlElement age = xmlDoc.CreateElement("Age");
        age.InnerText = "1";
        child.AppendChild(age);

        XmlElement status = xmlDoc.CreateElement("Status");
        status.InnerText = "0,0,0,0,0,0,0,";
        child.AppendChild(status);

        xmlDoc.Save("./Assets/Resources/Character.xml");
    }

    public string LoadXmlStatus()
    {
        //Xml ���� Ư���� �ҷ�����

        CreateXmlJug();

        TextAsset textAsset = (TextAsset)Resources.Load("Character");
        Debug.Log(textAsset);
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(textAsset.text);

        XmlNodeList nodes = xmlDoc.SelectNodes("CharacterInfo/Character");

        string str = "";
        foreach (XmlNode node in nodes)
        {
            Debug.Log("Name :: " + node.SelectSingleNode("Name").InnerText);
            Debug.Log("Age :: " + node.SelectSingleNode("Age").InnerText);
            Debug.Log("Status :: " + node.SelectSingleNode("Status").InnerText);
            str = node.SelectSingleNode("Status").InnerText;
        }
        return str;
    }

    public string LoadXmlName()
    {
        //Xml ���� Ư���� �ҷ�����

        TextAsset textAsset = (TextAsset)Resources.Load("Character");
        Debug.Log(textAsset);
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(textAsset.text);

        XmlNodeList nodes = xmlDoc.SelectNodes("CharacterInfo/Character");

        string str = "";
        foreach (XmlNode node in nodes)
        {
            Debug.Log("Name :: " + node.SelectSingleNode("Name").InnerText);
            Debug.Log("Age :: " + node.SelectSingleNode("Age").InnerText);
            Debug.Log("Status :: " + node.SelectSingleNode("Status").InnerText);
            str = node.SelectSingleNode("Name").InnerText;
        }
        return str;
    }

    public void SaveOverlapXml(string name, string age, string status)
    {
        //Xml ���� ����

        TextAsset textAsset = (TextAsset)Resources.Load("Character");
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(textAsset.text);

        XmlNodeList nodes = xmlDoc.SelectNodes("CharacterInfo/Character");
        XmlNode character = nodes[0];

        character.SelectSingleNode("Name").InnerText = name;
        character.SelectSingleNode("Age").InnerText = age;
        character.SelectSingleNode("Status").InnerText = status;//"0,0,0,0,0,0,0";

        xmlDoc.Save("./Assets/Resources/Character.xml");

        
        //���ҽ� ���� ��� �����ϰ� ������
        
        //using UnityEditor;
        //AssetDatabase.Refresh();
        
        //�߰�
    }

    protected void CreateXmlJug()
    {
        // Xml ������ �����ϴ��� Ȯ��

        string _Filestr = @"./Assets/Resources/Character.xml";
        System.IO.FileInfo fi = new System.IO.FileInfo(_Filestr);
        if (!fi.Exists)
        {
            CreateXml("Temp");
        }
    }
}
