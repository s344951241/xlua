using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;
using System.IO;
public class LoaderTest : MonoBehaviour {

	// Use this for initialization
	void Start () {

        LuaEnv luaEvn = new LuaEnv();

        luaEvn.AddLoader(MyLoader);

        luaEvn.DoString("require 'testLua'");

        luaEvn.Dispose();
		
	}

    private byte[] MyLoader(ref string filePath)
    {
        print(Application.streamingAssetsPath);

        string absPath = Application.streamingAssetsPath + "/" + filePath + ".lua.txt";

        return System.Text.Encoding.UTF8.GetBytes(File.ReadAllText(absPath));
    }
	// Update is called once per frame
	void Update () {
		
	}
}
