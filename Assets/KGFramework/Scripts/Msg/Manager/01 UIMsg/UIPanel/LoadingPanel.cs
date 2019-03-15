/****************************************************
    文件：LoadingPanel.cs
	作者：KG
    邮箱: 695907593@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LoadingPanel : BasePanel
{
    public Text LoadPCTtxt;
    public Slider LoadSlr;

    public float CurrenPCT;
    public float MaxPCT;

    public Image HintImg;
    public List<Sprite> sprites;

    public override void InitUI()
    {
        base.InitUI();
        sprites = Resources.LoadAll<Sprite>("Loading").ToList();

        Debug.Log(sprites.Count);
    }


    public override void OnEnter()
    {
        base.OnEnter();
        CurrenPCT = 0;
        MaxPCT = 0;
        HintImg.sprite= sprites[Random.Range(0, sprites.Count)];
    }

    public override void OnExit()
    {
        base.OnExit();
        CurrenPCT = 0;
        MaxPCT = 0;
    }

    public override void ResetUI()
    {
        base.ResetUI();
    }

 



    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (CurrenPCT< MaxPCT)
        {
            CurrenPCT += 0.02f;
            if (CurrenPCT > 1)
                CurrenPCT = 1;
            LoadPCTtxt.text = ((int)(CurrenPCT * 100)).ToString() + "%";
            LoadSlr.value = CurrenPCT;
        }
        

    }

    public void Loading(float v)
    {
        MaxPCT = v;
       
    }

}