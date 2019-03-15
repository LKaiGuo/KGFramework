using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SetPanel : BasePanel
{

    public Toggle AudioToggle;
    public Button QuitButton;
    public Button CloseButton;

    private void Start()
    {
        AudioToggle = this.gameObject.transform.Find("AudioToggle").GetComponent<Toggle>();
        QuitButton = this.gameObject.transform.Find("QuitButton").GetComponent<Button>();
        CloseButton = this.gameObject.transform.Find("CloseButton").GetComponent<Button>();


          AudioToggle.onValueChanged.AddListener(OnAuioClick);
        CloseButton.onClick.AddListener(OnCloseClick);
        //   QuitButton.onClick.AddListener(OnQuitClick);
    }

    public override void OnEnter()
    {
        Time.timeScale = 0;
        this.gameObject.SetActive(true);
    }

    public override void OnExit()
    {
        Time.timeScale = 1;
        this.gameObject.SetActive(false);
    }

    public override void OnPause()
    {
        Time.timeScale = 1;
        this.gameObject.SetActive(false);
    }

    public override void OnResume()
    {
        Time.timeScale = 0;
        this.gameObject.SetActive(true);
    }


    public void OnAuioClick(bool auio)
    {
       
        if (auio)
        {
            facade.audioMng.AudioVolume = 0;
            facade.audioMng.SetAudioVolume();
        }
        else
        {
            facade.audioMng.AudioVolume = 1;
            facade.audioMng.SetAudioVolume();
        }
       
    }
    public void OnQuitClick()
    {
        Debug.Log("123");
        PlayClickSound();
        Time.timeScale = 1;
       
        MsgFacade.Instance.SendGameOver();
       
        
    //  Application.Quit();
    }
    public void OnCloseClick()
    {
        facade.uiMng.PopTopPanel();
    }

}
