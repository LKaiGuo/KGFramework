using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[SerializeField]
public class Top_M : MonoBehaviour {

    public Image haedPortrait_UI;

    public Text Name_TXT;

    public Text Score_TXT;


    private void OnEnable()
    {
        haedPortrait_UI = transform.Find("haedPortrait").GetComponent<Image>();
        Name_TXT = transform.Find("Name").GetComponent<Text>();
        Score_TXT = transform.Find("Score").GetComponent<Text>();

    }

    // Use this for initialization
    void Start () {
      
    }

    public void UpdateUI(GameTopData data)
    {
        //更新头像
        switch (data.PlayerSex)
        {
            case "男":
                haedPortrait_UI.sprite = Resources.Load<Sprite>("Main/Male");
                break;
            case "女":
                haedPortrait_UI.sprite = Resources.Load<Sprite>("Main/Woman");
                break;
        }
        Name_TXT.text = data.PlayerNmae;
        Score_TXT.text = "得分：" + data.Score;


    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
