using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using XLua;

public class XlUaStart : MonoBehaviour
{

    public static LuaEnv luaenv = new LuaEnv();
    void Start()
    {
        luaenv.AddLoader(MyLoader);
        luaenv.DoString("require 'LuaStart'");
    }


    private void OnDestroy()
    {
        luaenv.DoString("require 'LuaEnd'");
        luaenv.Dispose();
    }
    private byte[] MyLoader(ref string filepath)
    {
        string abspath = Application.streamingAssetsPath + "/" + filepath + ".lua.txt";
        return Encoding.UTF8.GetBytes(File.ReadAllText(abspath));
    }
}
