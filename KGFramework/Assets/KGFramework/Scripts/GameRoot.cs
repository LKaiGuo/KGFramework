using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class GameRoot : MonoBehaviour
{
    private void Awake()
    {
       
    }
    
    private void Start()
    {
        //init  Mgr
        if (!this.gameObject.GetComponent<MsgFacade>())
            this.gameObject.AddComponent<MsgFacade>();
        MsgFacade.Instance.InitManager();

        // Init Sys
        if (!this.gameObject.GetComponent<SysFacade>())
            this.gameObject.AddComponent<SysFacade>();
        SysFacade.Instance.InitSys();

        DontDestroyOnLoad(this.gameObject);
    }                                                                                                  
}

