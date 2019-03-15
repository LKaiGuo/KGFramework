using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class GameSetData
{
    /// <summary>
    /// 手方向
    /// </summary>
    public Hand_Dic hand_Dic;
    private string hand_DicName;

    /// <summary>
    /// 限制的数据
    /// </summary>
    public LimitedData limitedData=new LimitedData(0);

    /// <summary>
    /// 难度
    /// </summary>
    public Difficult difficult;

    /// <summary>
    /// 玩家数据
    /// </summary>
    public PlayerData playerData;

    public float Grip;
    private int gameTimer;

    public int GameTimer
    {
        get
        {
            return gameTimer;
        }

        set
        {
            gameTimer = value*60;
        }
    }

    public string Hand_DicName
    {
        get
        {
            switch (hand_Dic)
            {
                case Hand_Dic.Left:
                    return "左手";
                    break;
                case Hand_Dic.Right:
                    return "右手";
                    break;
            }
            return hand_DicName;
        }

        set
        {
            hand_DicName = value;
        }
    }
}
public enum Hand_Dic
{
    Left,
    Right

}

//最大最小值
public struct AngleClamp
{
    public int min;
    public int max;
    public AngleClamp(int min,int max)
    {
        this.min = min;
        this.max = max;
    }
}
/// <summary>
/// 限制的数据
/// </summary>
public struct LimitedData
{
    //位置
    public AngleClamp X;
    public AngleClamp Y;
    public AngleClamp Z;
   


    //手腕
    public AngleClamp WristAngle;

    //握力
    public AngleClamp Grip;

    public LimitedData(int i=0)
    {
        X = new AngleClamp(35,145);
       Y = new AngleClamp(20, 470);
       Z = new AngleClamp(20, 220);

        WristAngle = new AngleClamp(10,230);
        Grip = new AngleClamp(0, 100);
    }

}
/// <summary>
/// 性别
/// </summary>
public struct PlayerData
{
    public string PlayerName;
    public string PlayerSex;
}
/// <summary>
/// 难度
/// </summary>
public enum Difficult
{
    no = 0,
    easy = 1,
    middle = 2,
    hard = 3,
}

