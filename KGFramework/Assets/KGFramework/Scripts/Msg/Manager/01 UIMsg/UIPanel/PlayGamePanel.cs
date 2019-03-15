using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayGamePanel : BasePanel {
    public TopUI top;
    public override void OnEnter()
    {
        base.OnEnter();
    }

    public override void OnExit()
    {
        this.gameObject.SetActive(false);
       
    }

    public override void OnPause()
    {
        this.gameObject.SetActive(false);
    }

    public override void OnResume()
    {
        this.gameObject.SetActive(true);
    }


    public Button PlayGameButton;

    // Use this for initialization
    void Start () {
        PlayGameButton = transform.Find("PlayGame").GetComponent<Button>();
        
        PlayGameButton.onClick.AddListener(()=> 
        {
            PlayClickSound();
            (facade.uiMng.GetPanel<InformationPanel>(UIPanelType.Information)).StartPlayTimer();

            sysFacade.startSys.PlayGame();
            facade.uiMng.PushPanel(UIPanelType.Score);

        });
        top = transform.Find("TopUI").GetComponent<TopUI>();

        top.UpdateTopUI(facade.dataMng.TopDatas);
        facade.dataMng.SaveTop();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
