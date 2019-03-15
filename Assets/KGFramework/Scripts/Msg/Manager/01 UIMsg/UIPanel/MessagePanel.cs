using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessagePanel : BasePanel {
    public override void OnEnter()
    {
        text = GetComponent<Text>();
        facade.uiMng.InitmsgPanel(this);
        text.enabled = false;
        text.CrossFadeAlpha(0, 0.2f, false);

    }

    public Text text;

    private float ShowTime = 2;

    private string message = null;



    // Use this for initialization
    void Start() {


    }

    // Update is called once per frame
    void Update() {
        if (message != null)
        {
            ShowMessage(this.message);
            message = null;
        }
    }

    public void ShowMessageSync(string msg)
    {
        message = msg;
    }

    /// <summary>
    /// 显示消息
    /// </summary>
    /// <param name="msg"></param>
    public void ShowMessage(string msg)
    {
        text.CrossFadeAlpha(1,0.2f,false);
        text.text = msg;
        text.enabled = true;
        Invoke("Hide", ShowTime);
    }
    /// <summary>
    /// 隐藏
    /// </summary>
    private void Hide()
    {
        text.CrossFadeAlpha(0, 1, false);
    }

}
