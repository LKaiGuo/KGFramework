using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

public class SchemeMsg : BaseMsg
{

    public Dictionary<string, BaseScheme> SchemeDic = new Dictionary<string, BaseScheme>();




    public SchemeMsg(MsgFacade facade) : base(facade)
    {

    }


    public void AddScheme(string data, BaseScheme baseScheme)
    {
        SchemeDic.Add(data, baseScheme);
    }
    /// <summary>
    /// 获取一个解决方案
    /// </summary>
    public BaseScheme GetScheme(string name )
    {
        return SchemeDic[name];
    }

    public override void Init()
    {
        var types = AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => a.GetTypes().Where(t => typeof(BaseScheme).IsAssignableFrom(t) && t.IsClass && !t.IsInterface && !t.IsAbstract)).ToList();

        types.ForEach(v=> 
        {
            ((BaseScheme)Activator.CreateInstance(v)).Init();
        });
    }

    public override void OnDestroy()
    {

    }

    public override void Update()
    {

    }
}
