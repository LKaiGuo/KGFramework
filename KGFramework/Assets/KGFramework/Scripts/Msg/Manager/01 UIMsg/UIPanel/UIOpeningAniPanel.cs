using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIOpeningAniPanel : BasePanel {
   
    public Material curMaterial;
    public float timer=-1;

    public string ToMainScene;
    // Use this for initialization
    void Start () {
        Screen.SetResolution(1280, 720, true);//自己想要的分辨率，比如1024*768，true表示全屏
        Screen.fullScreen = true;
        curMaterial = GetComponent<Image>().material;
        Invoke("ToScene",2);
    }
	
	// Update is called once per frame
	void Update () {
        timer= Mathf.Lerp(timer, 5, Time.deltaTime/3);
        curMaterial.SetFloat("_CenterX", timer);
       
    }
    public void ToScene()
    {
       //   SceneManager.LoadScene(ToMainScene);
        
        SysFacade.Instance.startSys.LoadGameScene();
        Destroy(this.gameObject);
    }

  
}
