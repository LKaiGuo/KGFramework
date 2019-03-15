/****************************************************
    文件：BaseSys.cs
	作者：KG
    邮箱: 695907593@qq.com
    日期：#CreateTime#
	功能：SYS
*****************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSys : MonoBehaviour 
{
    private MsgFacade _msgFacade;
    private SysFacade _sysFacade;


    public MsgFacade msgFacade
    {
        get
        {
            if (_msgFacade == null)
            {
                _msgFacade = MsgFacade.Instance;
            }
            return _msgFacade;
        }

        set
        {
            _msgFacade = value;
        }
    }

    public SysFacade sysFacade
    {
        get
        {
            if (sysFacade == null)
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

    public abstract void InitSys();

}