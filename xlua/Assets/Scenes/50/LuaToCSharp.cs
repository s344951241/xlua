using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public class LuaToCSharp : MonoBehaviour {

	// Use this for initialization
	void Start () {
        LuaEnv luaEnv = new LuaEnv();

        luaEnv.DoString("require 'LuaCallCSharp'");


        luaEnv.Dispose();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
