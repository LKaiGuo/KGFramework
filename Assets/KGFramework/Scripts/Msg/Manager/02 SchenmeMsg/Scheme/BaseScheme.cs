using UnityEngine;
using System.Collections;

public abstract class BaseScheme
{

    private MsgFacade _facade;


    public string SchemeNmae;

    public MsgFacade facade
    {
        get
        {
            if (_facade==null)
            {
                _facade = MsgFacade.Instance;
            }
            return _facade;
        }
    }

   
  
    public virtual void Init()
    {
        facade.AddSchemeDic(SchemeNmae, this);
    }

    /// <summary>
    /// 发送数据
    /// </summary>
    protected virtual void SendScheme( string data)
    {
        _facade.SendScheme(this.SchemeNmae,data);
    }

    /// <summary>
    /// 接收服务器数据处理
    /// </summary>
    /// <param name="data"></param>
    public abstract void OnScheme(string data);
    
}
