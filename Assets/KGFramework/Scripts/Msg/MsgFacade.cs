using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using System.Linq;

public class MsgFacade : MonoBehaviour
{

    private static MsgFacade _instance;

    public static MsgFacade Instance
    {
        get
        {
            if (_instance==null)
            {
                _instance = GameObject.Find("GameRoot").GetComponent<MsgFacade>();
                if (_instance==null)
                {
                    _instance = GameObject.Find("GameRoot").AddComponent<MsgFacade>();
                }
            }
            return _instance;
        }

        set
        {
            _instance = value;
        }
    }

    public AudioMsg audioMng;
    public DBMsg dbMng;
   

    public ClientMsg clientMng;
    public SchemeMsg schemeMng;
   
    public DataMsg dataMng;
    public CameraMsg  cameraMng;

    public UIMsg uiMng;
    public ResMsg resMsg;

    public bool GameOver;


    public Action UpdateAction;

    public Action DestroyAction;

    private void Awake()
    {
        _instance = this;
        Screen.SetResolution(1280, 720, true);//自己想要的分辨率，比如1024*768，true表示全屏
        Screen.fullScreen = true;
        
        DontDestroyOnLoad(this.gameObject);
    }


   
    /// <summary>
    /// 初始所有化基类
    /// </summary>
    public void InitManager()
    {

this.GetType().GetFields().Where(v => typeof(BaseMsg).IsAssignableFrom(v.FieldType)).ToList()
        .ForEach(v =>
        {
            BaseMsg Msg = (Activator.CreateInstance(v.FieldType, args: this)) as BaseMsg;
            v.SetValue(this, Msg);
            Msg.Init();
        });

    }

    // Use this for initialization
    void Start()
    {
      //  InitManager();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAction();

    }


    private void OnDestroy()
    {
        DestroyAction();
    }

    /// <summary>
    /// UI出栈
    /// </summary>
    public void PopPanel()
    {
        uiMng.PopTopPanel();
    }
    /// <summary>
    /// 拿一个UI
    /// </summary>
    /// <param name="uIPanelType"></param>
    /// <returns></returns>
    public T GetPanel<T>(UIPanelType uIPanelType) where T:BasePanel
    {
     return   uiMng.GetPanel<T>(uIPanelType);
    }
    public BasePanel GetPanel(UIPanelType uIPanelType) 
    {
        return uiMng.GetPanel(uIPanelType);

    }
    /// <summary>
    /// 判断场景是否存在这个UI
    /// </summary>
    /// <param name="uIPanelType"></param>
    /// <returns></returns>
    public bool GetPanelActiveSelf(UIPanelType uIPanelType)
    {
      return  uiMng.GetPanelActiveSelf(uIPanelType);
    }
    /// <summary>
    /// 显示UI
    /// </summary>
    /// <param name="uIPanelType"></param>
    /// <returns></returns>
    public BasePanel PushPanel(UIPanelType uIPanelType)
    {
        return uiMng.PushPanel(uIPanelType);
    }
    /// <summary>
    /// 显示UI
    /// </summary>
    /// <param name="uIPanelType"></param>
    /// <returns></returns>
    public T PushPanel<T>(UIPanelType uIPanelType=UIPanelType.None)where T:BasePanel
    {
        return uiMng.PushPanel<T>(uIPanelType);
    }

    /// <summary>
    /// 存储解决方案
    /// </summary>
    public void AddSchemeDic(string data,BaseScheme baseScheme)
    {
        schemeMng.AddScheme(data, baseScheme);

    }
    /// <summary>
    /// 拿出解决方案
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public BaseScheme GetScheme(string name)
    {
      return  schemeMng.GetScheme(name);
    }
    public void SendScheme(string name,string data)
    {
        clientMng.Send_Scheme(name,data);
    }

    /// <summary>
    /// 播放循环音乐
    /// </summary>
    /// <param name="sourceName"></param>
    /// <param name="volume"></param>
    public void PlayBG(string sourceName, float volume = 0.5f)
    {
        audioMng.PlayBG(sourceName, volume);
    }
    /// <summary>
    /// 播放音效
    /// </summary>
    /// <param name="sourceName"></param>
    /// <param name="volume"></param>
    public void PlayNormal(string sourceName, float volume = 1f)
    {
        audioMng.PlayNormal(sourceName, volume);
    }

   

    /// <summary>
    /// 游戏结束
    /// </summary>
    public void SendGameOver()
    {
        GameOver = true;
        try
        {
            clientMng.Send_Data("Data/曲棍球/" + dataMng.ScoreData.difficult + "/三维/" + dataMng.gameData.Hand_DicName + "/" + (dataMng.gameData.GameTimer - dataMng.currentTime).Count() + "/" + dataMng.ScoreData.Score + "/∞/end");
        }
        catch (System.Exception e)
        {

            Debug.Log(e);
        }
        finally
        {
            uiMng.PushPanel(UIPanelType.GameOver);
        }
      
      
        
    }
    /// <summary>
    /// 游戏结束
    /// </summary>
  
}
