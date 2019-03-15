using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InformationPanel : BasePanel
{
    public Image haedPortrait;

    public Text PlayerName;
    public Text Socore;
    public Text Diff;

    public Text GameTimerTxt;

    public Image Accumulators;

    public Button SetButton;
  


    public override void OnEnter()
    {
        this.gameObject.SetActive(true);
    }

    public override void OnExit()
    {
        this.gameObject.SetActive(false);
    }

    public override void OnPause()
    {
       
    }

    public override void OnResume()
    {
        this.gameObject.SetActive(true);
    }

    private void Awake()
    {
        SetButton = transform.Find("SetButton").GetComponent<Button>();
           haedPortrait = transform.Find("infobox/haedPortrait").GetComponent<Image>();
        Accumulators = transform.Find("AccumulatorsUI/Accumulators").GetComponent<Image>();

        PlayerName = transform.Find("infobox/PlayerName").GetComponent<Text>();
        Socore = transform.Find("infobox/Socore").GetComponent<Text>();
        Diff = transform.Find("infobox/Diff").GetComponent<Text>();

        GameTimerTxt = transform.Find("Timer_UI/Timer_Image/TimerTxt").GetComponent<Text>();
        SetButton.onClick.AddListener(OnSetClick);
    }
    // Use this for initialization
    void Start()
    {
        UpdateData();
      
    }

    // Update is called once per frame
    void Update()
    {
        Socore.text = "本次游戏最高得分"+facade.dataMng.ScoreData.Score;
        Accumulators.fillAmount = facade.dataMng.PercemtGrip;
        Accumulators.color = Color.Lerp(Color.green,Color.red,Accumulators.fillAmount);
    }

    public void OnSetClick()
    {
        facade.PushPanel(UIPanelType.Set);
    }

    /// <summary>
    /// 更新数据
    /// </summary>
    public void UpdateData()
    {
        //更新难度数据
        switch (facade.dataMng.gameData.difficult)
        {
            case Difficult.easy:
                facade.dataMng.ScoreData.difficult = "简单";
                Diff.text = "游戏难度：简单";
                break;
            case Difficult.middle:
                facade.dataMng.ScoreData.difficult = "中等";
                Diff.text = "游戏难度：中等";
                break;
            case Difficult.hard:
                facade.dataMng.ScoreData.difficult = "困难";
                Diff.text = "游戏难度：困难";
                break;

        }

        //更新时间
        
        //开始计时
        GameTimerTxt.text = facade.dataMng.currentTime.Count();
        //   StartCoroutine(PlayTimer());
        PlayerName.text = facade.dataMng.gameData.playerData.PlayerName;

        //更新头像
        switch (facade.dataMng.gameData.playerData.PlayerSex)
        {
            case "男":
                haedPortrait.sprite = Resources.Load<Sprite>("Main/Male");
                break;
            case "女":
                haedPortrait.sprite = Resources.Load<Sprite>("Main/Woman");
                break;
        }
    }
    public void StartPlayTimer()
    {
        facade.dataMng.TimerEvent += v => GameTimerTxt.text = v.Count();
        facade.dataMng.PlayTimer();
       
        
    }


    
    
}
