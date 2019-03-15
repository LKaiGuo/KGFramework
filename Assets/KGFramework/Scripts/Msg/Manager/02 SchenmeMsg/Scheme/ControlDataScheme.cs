using UnityEngine;
using System.Collections;

public class ControlDataScheme : BaseScheme
{
    public override void OnScheme(string data)
    {
        DebugLog.Log_("有调用控制数据" + data);
        string[] StrData = data.Split('/');

        facade.dataMng.controlData.X = int.Parse(StrData[0]);
        facade.dataMng.controlData.Y = int.Parse(StrData[1]);
        facade.dataMng.controlData.Z = int.Parse(StrData[2]);

        facade.dataMng.controlData.WristAngle = int.Parse(StrData[3]);
        facade.dataMng.controlData.Grip = int.Parse(StrData[4]);
    }

    protected override void SendScheme(string data)
    {
        base.SendScheme(data);
    }
    public override void Init()
    {
        SchemeNmae = "Value";
        base.Init();
    }
   
}
