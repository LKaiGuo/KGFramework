using UnityEngine;
using System.Collections;

public class SetDataScheme : BaseScheme
{
   
    public  override void Init()
    {
        SchemeNmae = "Set";
        base.Init();
    }

    public override void OnScheme(string data)
    {

       
        string[] StrData = data.Split('/');

        facade.dataMng.gameData.hand_Dic = (Hand_Dic)(int.Parse(StrData[0]));

        facade.dataMng.gameData.Grip = (int.Parse(StrData[3]));
        facade.dataMng.gameData.difficult = (Difficult)(int.Parse(StrData[4]));
        facade.dataMng.gameData.GameTimer = (int.Parse(StrData[5]));
        facade.dataMng.gameData.playerData.PlayerName = StrData[8];
        facade.dataMng.gameData.playerData.PlayerSex = StrData[9];
        facade.dataMng.ScoreData.PlayerNmae = StrData[8];
        facade.dataMng.ScoreData.PlayerSex = StrData[9];
       
        facade.uiMng.PushPanlSycn(UIPanelType.Information);
        facade.uiMng.PushPanlSycn(UIPanelType.PlayGame);

    }


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
