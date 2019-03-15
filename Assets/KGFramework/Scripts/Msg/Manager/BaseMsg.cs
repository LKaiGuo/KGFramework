using UnityEngine;
using System.Collections;

public abstract class BaseMsg 
{

    protected MsgFacade facade;

    public BaseMsg(MsgFacade facade)
    {
        this.facade = facade;
        facade.UpdateAction += Update;
        facade.DestroyAction += OnDestroy;
    }


 

    public abstract void Init();


    public abstract void Update();


    public abstract void OnDestroy();

    protected void StartCoroutine(IEnumerator ie)
    {
        facade.StartCoroutine(ie);
    }
}
