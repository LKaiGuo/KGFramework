using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;






public static class UIEsn
{
    #region Text
    public static Text SetText(this  Text txt,string Value)
    {
        txt.text = Value; 
        return txt;
    }



    #endregion


    #region BasePanel
    public static T PushPanel<T>(this T Panel) where T : BasePanel
    {
       // Panel
        return Panel;
    }
    #endregion
}

