using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public class BasePanel: KGUIBehaviour
{
    protected MsgFacade facade;
    private SysFacade _sysFacade;
    protected SysFacade sysFacade
    {
        get
        {
            if (_sysFacade == null)
            {
                _sysFacade = SysFacade.Instance;
            }
            return _sysFacade;
        }

        set
        {
            _sysFacade = value;
        }
    }
    protected UIMsg uIManager;


    public override  void InitUI()
    {
        facade = MsgFacade.Instance;
        uIManager = facade.uiMng;
        base.InitUI();

    }

    public override void PlayClickSound()
    {
        facade.audioMng.PlayNormal(AudioNmae.S_ButtonClick);
    }


    /// <summary>
    /// 置顶层级
    /// </summary>
    public override Transform SetUITop()
    {
        transform.SetSiblingIndex(transform.parent.childCount - 1);
        return transform;
    }

    public void Pop(bool OnResume)
    {
        facade.uiMng.PopPanel(this, OnResume);
    }
}

