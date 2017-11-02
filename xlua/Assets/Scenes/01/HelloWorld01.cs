using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public class HelloWorld01 : MonoBehaviour {

    private LuaEnv luaEvn;//只创建一个
    // Use this for initialization
    void Start () {
        luaEvn = new LuaEnv();
        luaEvn.DoString("print('11111')");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnDestroy()
    {
        luaEvn.Dispose();
    }
}
