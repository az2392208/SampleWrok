using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using XLua;

[System.Serializable]

public class TestSerilizable
{
    [XmlAttribute("Id")]
    public int Id { get; set; }
    [XmlAttribute("Name")]
    public string Name { get; set; }
    [XmlElement("list")]
    //[XmlArray("list")]
    public List<int> list { get; set; }
    //[XmlElement("dic")]
    //public Dictionary<int, string> dic { get; set; }
    //dictionary 不能直接序列化 但是你可以通过序列化类来表示一个字典
    public  MyDictionary Mydic { get;set;}
}

[System.Serializable]
public class MyDictionary
{

}
