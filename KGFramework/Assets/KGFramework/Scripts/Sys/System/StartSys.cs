/****************************************************
    文件：StartSys.cs
	作者：KG
    邮箱: 695907593@qq.com
    日期：#CreateTime#
	功能：StartSys
*****************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSys : BaseSys
{
 


    public override void InitSys()
    {
        Debug.Log("StartSys  Init");
    }

    void Start () {
      

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadGameScene()
    {
       
        msgFacade.resMsg.AsyncLoadScene("cee",()=>Debug.Log("1234aa"));
    }

    public void PlayGame()
    {
       
    }


   

}