using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class UIMsg : BaseMsg
{
    public UIMsg(MsgFacade facade) : base(facade)
    {
        //初始化路径

    }
    #region Field
    private Dictionary<UIPanelType, string> PanelPathDic = new Dictionary<UIPanelType, string>();//存路径
    private Dictionary<UIPanelType, BasePanel> PanelDic;//存UI

    private Transform canvasTransform;

    private Transform effectCanvas;

    private MessagePanel msgPanel;
    public ScorePanel scorePanel;



    private List<BasePanel> PanelList;

    public static readonly string Obj = "lock";




    private UIPanelType panelTypeToPush = UIPanelType.None;



    #endregion

    public Transform CanvasTransform
    {
        get
        {
            if (canvasTransform == null)
            {

                canvasTransform = GameObject.Find("Canvas").transform;
            }
            return canvasTransform;
        }

        set
        {
            canvasTransform = value;
        }
    }
    public Transform EffectCanvas
    {
        get
        {
            if (effectCanvas==null)
                effectCanvas = GameObject.Find("EffectCanvas").transform;

            if (!EffectCanvas.gameObject.GetComponent<Canvas>().worldCamera)
            {
                EffectCanvas.gameObject.GetComponent<Canvas>().worldCamera = Camera.main;
            }

            return effectCanvas;
        }

        set
        {
            effectCanvas = value;
        }
    }

  
    public override void Update()
    {

        if (panelTypeToPush != UIPanelType.None)
        {
            lock (Obj)
            {
                PushPanel(panelTypeToPush);
                panelTypeToPush = UIPanelType.None;
            }

        }



    }
    public override void OnDestroy()
    {

    }
    #region  Init

    public override void Init()
    {
        ParseUIPanelPath();
        PushPanel(UIPanelType.Message);

      
       
    }
    /// <summary>
    /// 初始化UI预制体的路径
    /// </summary>
    public void ParseUIPanelPath()
    {

        foreach (UIPanelType item in Enum.GetValues(typeof(UIPanelType)))
        {
            PanelPathDic.Add(item, "UIPanel/" + item.ToString() + "Panel");
        }


    }

    public void InitmsgPanel(MessagePanel message)
    {
        this.msgPanel = message;
    }
    public void InitscorePanel(ScorePanel scorePanel)
    {
        this.scorePanel = scorePanel;
    }
    #endregion

    #region Push Or Pop

    /// <summary>
    /// （线程用专用）把某个页面入栈，  把某个页面显示在界面上
    /// </summary>
    /// <param name="panelType"></param>
    public void PushPanlSycn(UIPanelType panelType)
    {
        lock (Obj)
        {
            if (panelTypeToPush == UIPanelType.None)
            {
                panelTypeToPush = panelType;
            }
        }



    }

    public BasePanel PushPanel(UIPanelType uIPanelType, bool UIPause = true)
    {
        lock (Obj)
        {
            if (PanelList == null)
            {
                PanelList = new List<BasePanel>();
            }
            if (PanelList.Count > 0 && UIPause)
            {
                BasePanel TopPanel = PanelList[PanelList.Count - 1];
                TopPanel.UIState = KGUIState.OnPause;
            }


            BasePanel basePanel = GetPanel<BasePanel>(uIPanelType);
            basePanel.UIState = KGUIState.OnEnter;
            basePanel.SetUITop();
            if (PanelList.Contains(basePanel))
            {
                PanelList.Remove(basePanel);
            }
            PanelList.Add(basePanel);
            return basePanel;
        }

    }
    public T PushPanel<T>(UIPanelType uIPanelType = UIPanelType.None, bool UIPause = true) where T : BasePanel
    {

        if (PanelList == null)
        {
            PanelList = new List<BasePanel>();
        }
        if (PanelList.Count > 0 && UIPause)
        {
            BasePanel TopPanel = PanelList[PanelList.Count - 1];
            TopPanel.UIState = KGUIState.OnPause;
        }
        BasePanel basePanel = null;

        if (uIPanelType != UIPanelType.None)
        {


            basePanel = GetPanel(uIPanelType);
        }
        else
        {

            basePanel = GetPanel<T>();
        }

        basePanel.UIState = KGUIState.OnEnter;
        basePanel.SetUITop();
        if (PanelList.Contains(basePanel))
        {
            PanelList.Remove(basePanel);
        }
        PanelList.Add(basePanel);
        return basePanel as T;
    }



    public void PopTopPanel()
    {
        if (PanelList == null)
        {
            PanelList = new List<BasePanel>();
        }
        if (PanelList.Count <= 0)
        {
            return;
        }

        BasePanel basePanel = PanelList[PanelList.Count - 1];
        PanelList.Remove(basePanel);
        Debug.Log(basePanel.gameObject.name);
        basePanel.UIState = KGUIState.OnExit;

        if (PanelList.Count <= 0)
        {
            return;
        }
        BasePanel basePanel2 = PanelList[PanelList.Count - 1];
        Debug.Log(basePanel2.gameObject.name);
        basePanel2.UIState = KGUIState.OnResume;

    }

    public void PopPanel()
    {
        if (PanelList == null)
        {
            PanelList = new List<BasePanel>();
        }
        if (PanelList.Count <= 0)
        {
            return;
        }

        BasePanel basePanel = PanelList[PanelList.Count - 1];
        PanelList.Remove(basePanel);
        Debug.Log(basePanel.gameObject.name);
        basePanel.UIState = KGUIState.OnExit;

        if (PanelList.Count <= 0)
        {
            return;
        }
        BasePanel basePanel2 = PanelList[PanelList.Count - 1];
        Debug.Log(basePanel2.gameObject.name);
        basePanel2.UIState = KGUIState.OnResume;

    }

    public void PopPanel(BasePanel basePanel, bool OnResume = false)
    {
        if (PanelList == null)
        {
            PanelList = new List<BasePanel>();
        }
        if (PanelList.Count <= 0)
        {
            return;
        }

        for (int i = 0; i < PanelList.Count; i++)
        {
            if (PanelList[i] == basePanel)
            {
                basePanel.UIState = KGUIState.OnExit;
                PanelList.Remove(basePanel);
                if (PanelList.Count <= 0 && !OnResume && i == 0)
                {
                    return;
                }
                BasePanel basePanel2 = PanelList[i - 1];
                Debug.Log(basePanel2.gameObject.name);
                basePanel2.UIState = KGUIState.OnResume;
            }

        }

        Debug.Log(basePanel.gameObject.name);




    }

    #endregion

    #region GetUI


    /// <summary>
    /// 获取UI
    /// </summary>
    /// <param name="uIPanelType"></param>
    /// <returns></returns>
    public T GetPanel<T>(UIPanelType uIPanelType = UIPanelType.None) where T : BasePanel
    {
        if (PanelDic == null)
        {
            PanelDic = new Dictionary<UIPanelType, BasePanel>();
        }

        BasePanel basePanel = null;
        if (uIPanelType != UIPanelType.None)
        {
            basePanel = PanelDic.TryGet(uIPanelType);
        }
        else
        {
            basePanel = PanelDic.TryGet<UIPanelType, BasePanel, T>();
        }


        if (basePanel == null)
        {
            string loadPath = uIPanelType != UIPanelType.None ? PanelPathDic.TryGet(uIPanelType) : "UIPanel/" + typeof(T).Name;

            GameObject tempPanelObj = GameObject.Instantiate(Resources.Load(loadPath)) as GameObject;
            tempPanelObj.transform.SetParent(CanvasTransform, false);
            basePanel = tempPanelObj.GetComponent<BasePanel>();

            basePanel.Init();
            PanelDic.Add(uIPanelType, basePanel);


        }
        return basePanel as T;
    }
    public BasePanel GetPanel(UIPanelType uIPanelType)
    {
        if (PanelDic == null)
        {
            PanelDic = new Dictionary<UIPanelType, BasePanel>();
        }

        BasePanel basePanel = PanelDic.TryGet(uIPanelType);


        if (basePanel == null)
        {
            GameObject tempPanelObj = GameObject.Instantiate(Resources.Load(PanelPathDic.TryGet(uIPanelType))) as GameObject;

            tempPanelObj.transform.SetParent(CanvasTransform, false);
            basePanel = tempPanelObj.GetComponent<BasePanel>();


            basePanel.Init();

            PanelDic.Add(uIPanelType, basePanel);


        }
        return basePanel;
    }



    /// <summary>
    /// 判断这个UI是否存在场景
    /// </summary>
    /// <param name="uIPanelType"></param>
    /// <returns></returns>
    public bool GetPanelActiveSelf(UIPanelType uIPanelType)
    {
        BasePanel basePanel = PanelDic.TryGet(uIPanelType);
        if (basePanel == null || basePanel.gameObject.activeSelf == false)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    #endregion

    #region ManagerUI

    public void ShowManager(string msg)
    {
        if (msgPanel == null)
        {
            Debug.Log("无法显示提示信息，为空"); return;
        }
        msgPanel.ShowMessage(msg);
    }
    public void ShowMessageSync(string msg)
    {
        if (msgPanel == null)
        {
            Debug.Log("无法显示提示信息，为空"); return;
        }
        msgPanel.ShowMessageSync(msg);
    }
    #endregion

    #region Event
    public void RemoveEvent<T>(T panel) where T : BasePanel
    {
        panel.AddUIStateEvent(v =>
        {
            if (v == KGUIState.OnExit)
            {
                PanelList.Remove(panel);
            }
        });
    }
    #endregion



}

