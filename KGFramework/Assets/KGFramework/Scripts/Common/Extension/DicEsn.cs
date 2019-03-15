using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DicEsn   {


    /// <summary>
    /// 根据Ket值返回Value值
    /// </summary>
    /// <typeparam name="Tket"></typeparam>
    /// <typeparam name="Tvalu"></typeparam>
    /// <param name="dic"></param>
    /// <param name="tket"></param>
    /// <returns></returns>
    public static Tvalu TryGet<Tket, Tvalu>(this Dictionary<Tket,Tvalu> dic, Tket  tket)
    {
        Tvalu  tvalu=default(Tvalu);
       dic.TryGetValue(tket,out tvalu);
        return tvalu;

    }

    public static T TryGet<Tket, Tvalu, T>(this Dictionary<Tket, Tvalu> dic) where T : Tvalu
    {
        Tvalu tvalu = default(Tvalu);

        foreach (var item in dic.Values)
        {
            if (item is T)
            {
                tvalu = item;
            }
        }
        return (T)tvalu;

    }

}
