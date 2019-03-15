
using UnityEngine;

public class AISchenme : BaseScheme
{
    public override void Init()
    {
        SchemeNmae = "AI";
        base.Init();
    }


    public override void OnScheme(string data)
    {
        string[] StrData = data.Split('/');
        facade.dataMng.AIX = float.Parse(StrData[0]);
        facade.dataMng.AIY = float.Parse(StrData[1]);
        Debug.Log(facade.dataMng.AIX);
    }
}

