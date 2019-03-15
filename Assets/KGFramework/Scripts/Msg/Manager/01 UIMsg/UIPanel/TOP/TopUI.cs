using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopUI : MonoBehaviour {
    public List<Top_M> Top = new List<Top_M>();

    public Text headline;
   
    // Use this for initialization
    void Start () {
     
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnEnable()
    {
        if (Top.Count == 0)
        {
            Init();
        }

    }

    public void Init()
    {
        Top.Add(transform.Find("Top1").GetComponent<Top_M>());
        Top.Add(transform.Find("Top2").GetComponent<Top_M>());
        Top.Add(transform.Find("Top3").GetComponent<Top_M>());
        headline = transform.Find("headline").GetComponent<Text>();

    }

    public void UpdateTopUI(List<GameTopData> topDatas)
    {
      
        if (Top.Count==0)
        {
            Init();
        }
        headline.text = topDatas[0].difficult+ "难度训练记录排行";
        for (int i = 0; i < topDatas.Count; i++)
        {
            Top[i].UpdateUI(topDatas[i]);
            Debug.Log(Top[i]);
        }

    }
}
