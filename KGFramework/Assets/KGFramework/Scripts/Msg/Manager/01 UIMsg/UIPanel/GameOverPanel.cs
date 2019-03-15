using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOverPanel : BasePanel
{
    public Image BG;
    public float timer;
    public TopUI top;
    // Use this for initialization
    void Start()
    {
        Invoke("GameOver",4);
        Invoke("SendGameover", 2);
        BG = transform.Find("BG").GetComponent<Image>();
        top = transform.Find("TopUI").GetComponent<TopUI>();
        top.UpdateTopUI(facade.dataMng.TopDatas);
        facade.dataMng.SaveTop();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime/2;
        BG.color = Color.Lerp(Color.black,Color.clear, timer);
       
    }

    public void SendGameover()
    {
        facade.clientMng.Send_Data("QuitGame/10分0秒/end");
    }

    public void GameOver()
    {
      
        Application.Quit();   
    }

    public override void OnEnter()
    {
        this.gameObject.SetActive(true);
    }

    public override void OnPause()
    {
        base.OnPause();
    }

    public override void OnResume()
    {
        base.OnResume();
    }

    public override void OnExit()
    {
        base.OnExit();
    }
}
