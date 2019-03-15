using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DBMsg : BaseMsg
{
    public DBMsg(MsgFacade facade) : base(facade)
    {

    }


    /// <summary>
    /// 保存一个链表
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="Data"></param>
    /// <param name="path"></param>
    public void Data_Save<T>(List<T> Data, string path)
    {
        XMLSave.M_Serialization_Save(Data, path);
    }
    /// <summary>
    /// 保存单个数据
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="Data"></param>
    /// <param name="path"></param>
    public void Data_Save<T>(T Data, string path)
    {
        XMLSave.M_Serialization_Save(Data, path); 
    }
    /// <summary>
    /// 保存一个数组
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="Data"></param>
    /// <param name="path"></param>
    public void Data_Save<T>(T[] Data, string path)
    {
        XMLSave.M_Serialization_Save(Data, path);
    }
    /// <summary>
    /// 读取数据
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="path"></param>
    /// <returns></returns>
    public List<T> Data_Read<T>(string path)
    {
        return XMLSave.M_Deserialization_Read<T>(path);
    }

    /// <summary>
    /// 添加一组数据_链表
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="Data"></param>
    /// <param name="path"></param>
    public void Data_AddAll<T>(List<T> Data, string path)
    {
        XMLSave.M_Serialization_Add(Data, path);
    }
    /// <summary>
    /// 添加一组数据_数组
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="Data"></param>
    /// <param name="path"></param>
    public void Data_AddAll<T>(T[] Data, string path)
    {
        XMLSave.M_Serialization_Add(Data, path);
    }
    /// <summary>
    /// 添加单个
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="Data"></param>
    /// <param name="path"></param>
    public void Data_AddAll<T>(T Data, string path)
    {
        XMLSave.M_Serialization_Add(Data, path);
    }
    /// <summary>
    /// 删除XML里面含有链表里面的数据
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="Data"></param>
    /// <param name="path"></param>
    public void Data_Remove<T>(List<T> Data, string path)
    {
        XMLSave.M_Serialization_Remove(Data, path);
    }
    /// <summary>
    /// 删除XML里面含有数组里面的数据
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="Data"></param>
    /// <param name="path"></param>
    public void Data_Remove<T>(T[] Data, string path)
    {
        XMLSave.M_Serialization_Remove(Data, path);
    }
    /// <summary>
    /// 删除XML里面含有单个数据的数据
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="Data"></param>
    /// <param name="path"></param>
    public void Data_Remove<T>(T Data, string path)
    {
        XMLSave.M_Serialization_Remove(Data, path);
    }

    /// <summary>
    /// 根据类型更新数据
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="Quondam_data"></param>
    /// <param name="Now_data"></param>
    /// <param name="path"></param>
    public void UpdateData<T>(T Quondam_data, T Now_data, string path)
    {
        XMLSave.UpdateData(Quondam_data, Now_data, path);
    }
    /// <summary>
    /// 根据某个名字数值，查询到然后修改值
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="name"></param>
    /// <param name="value"></param>
    /// <param name="changeName"></param>
    /// <param name="changeValue"></param>
    /// <param name="path"></param>
    public void UpdateData<T>(string name, string value, string changeName, string changeValue, string path)
    {
        XMLSave.UpdateData<T>(name, value, changeName, changeValue, path);
    }

    /// <summary>
    /// 根据名字查找某个值
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="name"></param>
    /// <param name="value"></param>
    /// <param name="changeName"></param>
    /// <param name="path"></param>
    /// <returns></returns>
    public string FindData(string name, string value, string changeName, string path)
    {
      return  XMLSave.FindData(name,value,changeName,path);
    }

    public override void Init()
    {
      
    }

    public override void Update()
    {
       
    }

    public override void OnDestroy()
    {
       
    }
}
