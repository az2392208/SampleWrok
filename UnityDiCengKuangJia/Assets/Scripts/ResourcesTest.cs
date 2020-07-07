using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using XLua;

[Hotfix]
public class ResourcesTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //AssetBundle asset = AssetBundle.LoadFromFile(Application.streamingAssetsPath + "/bbb.modle");
        //Object[] o = asset.LoadAllAssets();
        //foreach (var item in o)
        //{
        //    GameObject.Instantiate(item);
        //}

        //GameObject obj = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefebs/Attack.prefab");
        //GameObject.Instantiate(obj);

        //CreatSerilize();
        //DeSerilizer();
        
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            DoLuaTest();
        }
    }

    [Hotfix]
    public void DoLuaTest()
    {
        Debug.Log("hello");
    }

    /// <summary>
    /// 序列化
    /// </summary>
    void CreatSerilize()
    {
        TestSerilizable testSerilizable = new TestSerilizable();
        testSerilizable.Id = 1;
        testSerilizable.Name = "Aive";
        testSerilizable.list = new List<int>();
        testSerilizable.list.Add(testSerilizable.Id);
        testSerilizable.list.Add(2);
        //testSerilizable.dic = new Dictionary<int, string>();
        //testSerilizable.dic.Add(testSerilizable.Id, testSerilizable.Name);
        //XmlSerilize(testSerilizable);

        BianrySerTest(testSerilizable);
    }

    void XmlSerilize(TestSerilizable testSerilizable)
    {
        //调用文件流 创建一个文件对象
        using (FileStream fileStream = new FileStream(Application.dataPath + "/Scripts/text.xml", FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
        {
            //调用写入流 创建一个写入的格式
            using (StreamWriter sw = new StreamWriter(fileStream, System.Text.Encoding.UTF8))
            {
                //调用xml的序列化方法
                XmlSerializer serializer = new XmlSerializer(testSerilizable.GetType());
                //序列化文件
                serializer.Serialize(sw, testSerilizable);
            }
        }
        Debug.Log("创建成功");
    }

    /// <summary>
    /// 反序列化
    /// </summary>
    void DeSerilizer()
    {
        TestSerilizable test = xmlDeSerilize();
        Debug.Log(test.Id);
        Debug.Log(test.Name);
    }

    public TestSerilizable xmlDeSerilize()
    {
        FileStream fs = new FileStream(Application.dataPath + "/Scripts/text.xml", FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
        XmlSerializer xs = new XmlSerializer(typeof(TestSerilizable));
        TestSerilizable testSerilizable = (TestSerilizable)xs.Deserialize(fs);
        return testSerilizable;
    }
    //序列化成二进制
    void BianrySerTest(TestSerilizable testSerilizable)
    {
        using (FileStream fs = new FileStream(Application.dataPath + "/Scripts/text.bytes", FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
        {
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, testSerilizable);
        }
    }
    [LuaCallCSharp]
    //二进制的反序列化
    public void BinaryDeSeriliable()
    {
        //using (FileStream fs = new FileStream(Application.dataPath + "/Scripts/text.xml", FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
        //{
        //    BinaryFormatter bf = new BinaryFormatter();
        //    TestSerilizable ts = (TestSerilizable)bf.Deserialize(fs);
        //    Debug.Log(ts.Id);
        //    Debug.Log(ts.Name);
        //}
    }
    void BinaryDeSeriliable(int a)
    {
        ////特别注意后面的地址  LoadAssetAtPath默认地址为Assest文件夹
        //TextAsset asset = UnityEditor.AssetDatabase.LoadAssetAtPath<TextAsset>("Assets/Scripts/text.bytes");
        //using (MemoryStream ms = new MemoryStream(asset.bytes))
        //{
        //    BinaryFormatter bf = new BinaryFormatter();
        //    TestSerilizable ts = (TestSerilizable)bf.Deserialize(ms);
        //    Debug.Log(ts.Id);
        //    Debug.Log(ts.Name);
        //}
    }
}
