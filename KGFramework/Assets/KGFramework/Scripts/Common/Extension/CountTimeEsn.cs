using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public static class CountTimeEsn
{

    public static string Count(this int Timer)
    {
        int minute = Timer / 60;
        int second = Timer - (minute*60);
        return minute+"分"+second+"秒";
    }

}

