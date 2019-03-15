using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class GameTopData
{
   public string PlayerNmae = "（空）";
    public string PlayerSex;
    public string difficult;
    private int score;

    public int Score
    {
        get
        {
            return score;
        }

        set
        {
            if (value>score)
            {
                score = value;
            }
            
        }
    }
}



