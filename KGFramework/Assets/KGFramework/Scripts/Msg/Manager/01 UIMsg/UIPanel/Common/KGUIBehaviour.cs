using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Reflection;
using UnityEngine.UI;


public enum KGUIState
{

    None,
    OnEnter,
    OnPause,
    OnResume,
    OnExit,

}
public abstract class KGUIBehaviour : MonoBehaviour, IKGUIPro
{

    #region UIState
    private KGUIState uIState = KGUIState.None;


    public KGUIState UIState
    {
        get
        {
            return uIState;
        }

        set
        {
            if (value == KGUIState.OnResume && uIState != KGUIState.OnPause)
                return;
            UIStateEvent(value);
            uIState = value;
        }
    }


    public void SwitchUIState(KGUIState state)
    {
        switch (state)
        {
            case KGUIState.None:
                break;
            case KGUIState.OnEnter:
                OnEnter();
                break;
            case KGUIState.OnPause:
                OnPause();
                break;
            case KGUIState.OnResume:
                if (state == KGUIState.OnPause)
                    OnResume();
                break;
            case KGUIState.OnExit:
                OnExit();
                break;
        }
    }

    private Action<KGUIState> UIStateEvent;

    //private Action<KGUIState> UIStateEvent
    //{
    //    get
    //    {
    //        return uIStateEvent;
    //    }

    //    set
    //    {
    //        uIStateEvent = value;
    //    }
    //}

    public void AddUIStateEvent(Action<KGUIState> action)
    {
        UIStateEvent += action;
    }
    public void RemoveUIStateEvent(Action<KGUIState> action)
    {
        UIStateEvent -= action;
        UIStateEvent.GetInvocationList();
    }
    public void RemoveAllUIStateEvent(Action<KGUIState> action)
    {
        Action<KGUIState>[] actions = UIStateEvent.GetInvocationList().Select(v => v as Action<KGUIState>).ToArray();
        for (int i = 0; i < actions.Length; i++)
        {
            UIStateEvent -= actions[i];
        }
        UIStateEvent += SwitchUIState;
    }
    #endregion

    #region UI Dic  Module   Init
    private Dictionary<string, FieldInfo> uIModule;

    public Dictionary<string, FieldInfo> UIModule
    {
        get
        {
            if (uIModule == null)
            {
                uIModule = new Dictionary<string, FieldInfo>();
                FieldInfo[] fields = this.GetType().GetFields();
                fields.ToList().ForEach(v => uIModule.Add(v.Name, v));
            }
            return uIModule;
        }

        set
        {
            uIModule = value;
        }
    }



    public void InitUIModule()
    {
        this.GetComponentsInChildren<KGUI_T>().ToList().ForEach(v =>
        {
            string ObjName = v.gameObject.name;
            if (UIModule.ContainsKey(ObjName))
            {
                if (v.gameObject.GetType() == UIModule[ObjName].FieldType)
                {
                    UIModule[ObjName].SetValue(this, v.gameObject);

                }
                else
                {
                    UIModule[ObjName].SetValue(this, v.gameObject.GetComponent(UIModule[ObjName].FieldType));
                }

            }
        });
    }
    #endregion



    #region IKGUIPro
    public  void Init()
    {
        
        UIStateEvent += SwitchUIState;
        InitUI();
    }
    public virtual void InitUI()
    {
        InitUIModule();
    }

    public virtual void ResetUI()
    {

    }

    public virtual void OnEnter()
    {
        this.gameObject.SetActive(true);
    }

    public virtual void OnPause()
    {
        
    }

    public virtual void OnResume()
    {
        
    }

    public virtual void OnExit()
    {
        this.gameObject.SetActive(false);
    }

    public abstract void PlayClickSound();

    public abstract Transform SetUITop();

   
    #endregion
}

