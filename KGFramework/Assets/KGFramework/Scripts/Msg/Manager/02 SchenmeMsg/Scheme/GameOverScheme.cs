using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Collections;


public class GameOverScheme : BaseScheme
{

    public override void Init()
    {
        SchemeNmae = "Data";
        base.Init();
    }

    public override void OnScheme(string data)
    {
       
    }

    public  void SendScheme(string GameName, Difficult difficult, Hand_Dic hand_Dic,int GameTimer, string Score,string MaxScore)
    {
        string dif = "";
        string Handdic = "";
        switch (difficult)
        {
            case Difficult.easy:
                dif = "低";
                break;
            case Difficult.middle:
                dif = "中";
                break;
            case Difficult.hard:
                dif = "高";
                break;
            
        }
        switch (hand_Dic)
        {
            case Hand_Dic.Left:
                Handdic = "左手";
                break;
            case Hand_Dic.Right:
                Handdic = "右手";
                break;
            
        }



        string Send_Data = string.Format("{0}/{1}/{2}/{3}/{4}/{5}/end",GameName,dif,Handdic,GameTimer,Score,MaxScore);
        base.SendScheme(Send_Data);

    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
