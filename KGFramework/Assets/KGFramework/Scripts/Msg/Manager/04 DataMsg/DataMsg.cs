using UnityEngine;
using System.Collections;
using System.Runtime.Remoting.Messaging;
using System.Collections.Generic;
using System;
using System.Linq;

public class DataMsg : BaseMsg
{

    /// <summary>
    /// 游戏设置的数据
    /// </summary>
    public GameSetData gameData=new GameSetData() { GameTimer=5};
    /// <summary>
    /// 游戏操控传过来的数据
    /// </summary>
    public ControlData controlData=new ControlData();

    /// <summary>
    /// 当前时间
    /// </summary>
    public int currentTime;

    /// <summary>
    /// 排行榜数据
    /// </summary>
    private List<GameTopData> topDatas=new List<GameTopData>();

    /// <summary>
    /// 排行榜数据/组
    /// </summary>
    public GameTopData ScoreData=new GameTopData();

    public GameScoreData Player1=new GameScoreData();
    public GameScoreData Player2=new GameScoreData();

    public float AIX;
    public float AIY;

    public event Action<int> TimerEvent;

    //X百分比
    public float PercentX
    {
        get { return ClampData((float)controlData.X, 120, 50); }
    }
    //Y百分比
    public float PercentY
    {
        get { return ClampData((float)controlData.Y, 370, 100); }
    }
    //Z百分比
    public float PercentZ
    {
        get { return ClampData((float)controlData.Z, 20, 220); }
    }
    /// <summary>
    /// 握力百分比
    /// </summary>
    public float PercemtGrip

    {
        get { return ClampData((float)controlData.Grip, 0, 100); }
    }

    /// <summary>
    /// 排行榜数据
    /// </summary>
    public List<GameTopData> TopDatas
    {
        get
        {
            GetTop();
            return topDatas;
        }

        set
        {
            topDatas = value;
        }
    }


    /// <summary>
    /// 获取排行榜信息
    /// </summary>
    /// <returns></returns>
    public List<GameTopData> GetTop()
    {
        
        //Enum.GetName(typeof(Difficult), gameData.difficult)
        //获取路径
        string Path = Application.dataPath + @"/" + ScoreData.difficult + ".xml";


        if (facade.dbMng.Data_Read<GameTopData>(Path) != null)
        {
            //读取
            topDatas = facade.dbMng.Data_Read<GameTopData>(Path);

            topDatas.Add(ScoreData);


        }
        else
        {
            topDatas.Add(ScoreData);

        }
        topDatas = topDatas.OrderByDescending(V => V.Score).GroupBy(V => V.PlayerNmae).Select(v => v.First()).ToList();
        //超出排行榜数量就删除
        while (topDatas.Count > 3)
        {
            topDatas.Remove(topDatas[topDatas.Count - 1]);
        }

        return topDatas;

    }

    /// <summary>
    /// 保存当前排行榜信息
    /// </summary>
    public void SaveTop()
    {
        string Path = Application.dataPath + @"/" + ScoreData .difficult+ ".xml";



        facade.dbMng.Data_Save(GetTop(),Path);


    }







    public DataMsg(MsgFacade facade) : base(facade)
    {
    }

    public override void Init()
    {
    }

    public override void OnDestroy()
    {
       
    }

    public override void Update()
    {
       
            
           
        
    }
    /// <summary>
    /// 计算百分比
    /// </summary>
    /// <param name="value"></param>
    /// <param name="max"></param>
    /// <param name="min"></param>
    /// <returns></returns>
    public float ClampData(float value, float max, float min)
    {

        if (min < 0)
        {
            float result = Mathf.Clamp(value, min, max)
             + Mathf.Abs(min);
            result /= (Mathf.Abs(min) + max);
            return result;
        }
        else
        {
            float result = Mathf.Clamp(value, min, max)
             - Mathf.Abs(min);
            result /= (max - min);

            return result;

        }
    }

    public string Add()
    {
        return "2";
        
    }

    public void PlayTimer()
    {
        StartCoroutine(MTimer());
    }

    public IEnumerator MTimer()
    {
        currentTime = gameData.GameTimer;
        while (currentTime > 0)
        {
            currentTime--;
           
            TimerEvent?.Invoke(currentTime);
            if (facade.dataMng.currentTime == 15)
            {

            }
            yield return new WaitForSeconds(1);
        }
        if (!facade.GameOver)
        {
            facade.SendGameOver();
        }

    }
}
