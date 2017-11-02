using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;
public class HelloWorld02 : MonoBehaviour {

	// Use this for initialization
	void Start () {
       // TextAsset ta = Resources.Load<TextAsset>("hellow.lua");
        LuaEnv env = new LuaEnv();

        env.DoString("require 'hellow'");//loader   resources下的hellow.lua.txt
        env.Dispose();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
