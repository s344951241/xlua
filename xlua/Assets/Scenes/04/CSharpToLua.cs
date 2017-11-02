using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;
public class CSharpToLua : MonoBehaviour {

	// Use this for initialization
	void Start () {
        LuaEnv luaEnv = new LuaEnv();

        luaEnv.DoString("require 'CSharpCallLua'");
        int a = luaEnv.Global.Get<int>("a");//获取lua全局变量
        print(a);
        string str = luaEnv.Global.Get<string>("str");
        print(str);
        //映射不用完全一样,比较灵活
        //类
        Person p = luaEnv.Global.Get<Person>("person");//属于深拷贝
        print("name" + p.name);
        print("age" + p.age);
        //接口
        IPerson Ip = luaEnv.Global.Get<IPerson>("person");//属于浅拷贝，引用,推荐
        print("Iname" + Ip.name);
        print("Iage" + Ip.age);
        Ip.eat(10,11);
        Ip.eat2(10, 11);
        Ip.eat3(10, 11);
        //字典
        Dictionary<string,object> dict =  luaEnv.Global.Get<Dictionary<string, object>>("person");
        foreach (string key in dict.Keys)
        {
            print(key + "-" + dict[key]);
        }
        //list

        List<object> lists = luaEnv.Global.Get<List<object>>("person");
        foreach (object o in lists)
        {
            print(o);
        }

        //luaTable
        LuaTable tab = luaEnv.Global.Get<LuaTable>("person");
        print(tab.Get<string>("name"));
        print(tab.Get<int>("age"));

        //全局函数
        Add add = luaEnv.Global.Get<Add>("add");

        int result = add.Invoke(70,80);
        print("result:" + result);
        add = null;

        OutBack back = luaEnv.Global.Get<OutBack>("outBack");
        string sss = "";
        
        print("outBack" + back.Invoke(10, 20, out sss) + sss);
        back = null;
        RefBack back2 = luaEnv.Global.Get<RefBack>("refBack");
        string ss = "";
        print("outBack" + back2.Invoke(10, 20, ref ss) + ss);
        back2 = null;
        luaEnv.Dispose();
	}
    [CSharpCallLua]
    delegate int Add(int a, int b);//从第二个返回参数开始对应out或者ref参数
    [CSharpCallLua]
    delegate int OutBack(int a, int b, out string str);

    [CSharpCallLua]
    delegate int RefBack(int a, int b, ref string str);
	
	// Update is called once per frame
	void Update () {
		
	}
}



class Person {
    public string name;
    public int age;

}

[CSharpCallLua]
interface IPerson
{
    string name { get; set; }
    int age { get; set; }
    void eat(int a,int b);
    void eat2(int a, int b);

    void eat3(int a, int b);
}
