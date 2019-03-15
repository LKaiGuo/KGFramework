using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePanel : BasePanel {
    public override void OnEnter()
    {
        this.gameObject.SetActive(true);
        facade.uiMng.InitscorePanel(this);
    }

    public override void OnExit()
    {
        this.gameObject.SetActive(false);
    }

    public override void OnPause()
    {
        base.OnPause();
    }

    public override void OnResume()
    {
        this.gameObject.SetActive(true);
    }


    public Text PlayerScore;
    public Text AIScore;

    // Use this for initialization
    void Start () {
        PlayerScore = transform.Find("ScoreUI/PlayerTxt").GetComponent<Text>();
        AIScore = transform.Find("ScoreUI/AITxt").GetComponent<Text>();
        UpdateScore();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UpdateScore()
    {
        PlayerScore.text = facade.dataMng.Player1.Score.ToString();
        AIScore.text = facade.dataMng.Player2.Score.ToString();
    }
}
