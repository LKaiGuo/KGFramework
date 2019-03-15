using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public static class TopEsn
{

    /// <summary>
    /// 检测重复名字排序，比较大小，
    /// </summary>
    /// <param name="topDatas"></param>
    /// <returns></returns>
    public static List<GameTopData> TSort(this List<GameTopData> topDatas)
    {
        Dictionary<string, int> dic = new Dictionary<string, int>();
        //寻找重复名字
        for (int i = 0; i < topDatas.Count; i++)
        {
            //找到就往字典加一
            if (dic.ContainsKey(topDatas[i].PlayerNmae))
            {
                Debug.Log(dic[topDatas[i].PlayerNmae]);
                dic[topDatas[i].PlayerNmae] += 1;
            }
            else
            {
                dic.Add(topDatas[i].PlayerNmae, 1);
            }
        }
        List<string> PlyaerNmae = new List<string>();
        //遍历 字典查找重复次数
        foreach (string item in dic.Keys)
        {

            if (dic[item] > 1)
            {
                PlyaerNmae.Add(item);

            }
        }
        //临时存放 每组玩家名字相同的数据
        List<List<GameTopData>> tempListData = new List<List<GameTopData>>();
        List<GameTopData> tempRemoveData = new List<GameTopData>();

        //遍历 有重复的名字，找出来组成链表,然后添加到移除组
        for (int i = 0; i < PlyaerNmae.Count; i++)
        {
            //新建 临时重复名字的数据链表
            List<GameTopData> tempData = new List<GameTopData>();
            for (int t = 0; t < topDatas.Count; t++)
            {
                if (PlyaerNmae[i] == topDatas[t].PlayerNmae)
                {
                    //添加每组重复的数据
                    tempData.Add(topDatas[t]);
                    //添加要移除进行排序，重复名字的数据
                    tempRemoveData.Add(topDatas[t]);
                }

            }
            //添加到总的组
            tempListData.Add(tempData);
        }
        Debug.Log(tempListData.Count);
        //把找出来的进行移除
        for (int i = 0; i < tempRemoveData.Count; i++)
        {
            topDatas.Remove(tempRemoveData[i]);
        }
        //然后把每个 重复的名字 链表数据 进行排序选出最大,然后添加回来
        for (int i = 0; i < tempListData.Count; i++)
        {
            //排序大小
            tempListData[i] = tempListData[i].TSortSize();
            //添加最大的
            topDatas.Add(tempListData[i][0]);
        }
        //最后再进行一次排序大小
        topDatas.TSortSize();

        return topDatas;
    }
    /// <summary>
    /// 比较大小排序
    /// </summary>
    /// <param name="topDatas"></param>
    /// <returns></returns>
    public static List<GameTopData> TSortSize(this List<GameTopData> topDatas)
    {

        for (int i = 0; i < topDatas.Count - 1; i++)
        {

            for (int t = i + 1; t < topDatas.Count; t++)
            {
                if (topDatas[i].Score < topDatas[t].Score)
                {
                    GameTopData tempTop = topDatas[i];
                    topDatas[i] = topDatas[t];
                    topDatas[t] = tempTop;
                }
            }
        }
        return topDatas;
    }
}
