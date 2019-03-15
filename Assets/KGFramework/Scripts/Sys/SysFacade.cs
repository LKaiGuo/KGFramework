using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


/// <summary>
/// 业务逻辑
/// </summary>
public class SysFacade :MonoBehaviour
{
    private static SysFacade _instance;

    public static SysFacade Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.Find("GameRoot").GetComponent<SysFacade>();
            }
            return _instance;
        }

        set
        {
            _instance = value;
        }
    }

    public GameSys gameSys;
    public StartSys startSys;

    private void Awake()
    {
        _instance = this;
    }

    public void InitSys()
    {
        this.GetType().GetFields().Where(v => typeof(BaseSys).IsAssignableFrom(v.FieldType)).ToList()
        .ForEach(v =>
        {
            BaseSys sys = this.gameObject.AddComponent(v.FieldType) as BaseSys;
            v.SetValue(this, sys);
            sys.InitSys();
        });

    }
}

