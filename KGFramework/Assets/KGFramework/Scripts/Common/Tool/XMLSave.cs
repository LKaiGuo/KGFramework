using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.Linq;
using System.IO;
using System;
using System.Reflection;


public static class XMLSave
{

    #region 保存
    public static Tool tool=new Tool();

    /// <summary>
    /// 序列化 保存 覆盖
    /// </summary>
    /// <param name="ff"></param>
    public static void M_Serialization_Save<T>(List<T> ff, string path)
    {

      
        Type type = typeof(List<T>);//获取你要序列化的类型
        XmlSerializer xs = new XmlSerializer(type);//序列化转成XML的格式
        FileStream fs = null; 
        try
        {
            //创建新的 有则 覆盖
            fs = new FileStream(path, FileMode.Create);
            //转码格式 U3D识别UTF8
            StreamWriter sw = new StreamWriter(fs,System.Text.Encoding.UTF8);

            //开始序列化保存
            xs.Serialize(sw, ff);
        }
        catch (Exception e)
        {

            Debug.Log(e);
        }
        finally
        {
            fs.Close();
        }


    }

    /// <summary>
    /// 序列化 保存 覆盖 单个
    /// </summary>
    /// <param name="ff"></param>
    public static void M_Serialization_Save<T>(T ff, string path) 
    {
        
        List<T> my = new List<T>(); //
        my.Add(ff);
        M_Serialization_Save(my, path);
    }
    /// <summary>
    /// 序列化 保存 覆盖 数组
    /// </summary>
    /// <param name="ff"></param>
    public static void M_Serialization_Save<T>(T[] ff, string path)
    {

        List<T> my = new List<T>(); //
        foreach (T item in ff)
        {
            my.Add(item);
        }
        
        M_Serialization_Save(my, path);
    }

#endregion

    #region 添加

    /// <summary>
    /// 添加一个链表数据
    /// </summary>
    /// <param name="ff"></param>
    /// <param name="path"></param>
    public static void M_Serialization_Add<T>(List<T> ff, string path)
    {
        List<T> myNameScoers = new List<T>(); //

        Type type = typeof(List<T>);//获取你要序列化的类型
        XmlSerializer xs = new XmlSerializer(type);//序列化转成XML的格式
        FileStream fs = null;//声明一个流

        if (File.Exists(path))//判断是否含有该文件
        {
            try
            {
                //读原来的文件
                myNameScoers = M_Deserialization_Read<T>(path);

                //添加上一个所有数据
                foreach (T item in ff)
                {
                    myNameScoers.Add(item);
                }
                //选择创建流的模式
                fs = new FileStream(path, FileMode.Create);
                //转码格式 U3D识别UTF8
                StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.UTF8);
                //这个格式进行序列化
                xs.Serialize(sw, myNameScoers);
            }
            catch (Exception e)
            {

                Debug.Log("添加失败" + e);
            }
            finally
            {
                fs.Close();
            }
        }
        else
        {
            try
            {
                //选择创建流的模式
                fs = new FileStream(path, FileMode.Create);
                //转码格式 U3D识别UTF8
                StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.UTF8);
                //这个格式进行序列化
                xs.Serialize(sw, ff);
            }
            catch (Exception e)
            {

                Debug.Log("添加时候创建失败" + e);
            }
            finally
            {
                fs.Close();
            }
        }
    }
    /// <summary>
    /// 添加单个
    /// </summary>
    /// <param name="ff"></param>
    /// <param name="path"></param>
    public static void M_Serialization_Add<T>(T ff, string path)
    {
        //  M_Serialization_Add();
        List<T> d = new List<T>();
        d.Add(ff);
        M_Serialization_Add(d,path);
    }
    /// <summary>
    /// 添加一组数据——数组
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="ff"></param>
    /// <param name="path"></param>
    public static void M_Serialization_Add<T>(T[] ff, string path)
    {
        //  M_Serialization_Add();
        List<T> d = new List<T>();

        foreach (T item in ff)
        {
            d.Add(item);
        }
       
        M_Serialization_Add(d, path);
    }

    #endregion

    #region 读取

    //读取，反序列化
    public static List<T> M_Deserialization_Read<T>(string path)
    {
        List<T> myNameScoers = new List<T>(); //

        Type type = typeof(List<T>);//获取你要序列化的类型
        XmlSerializer xs = new XmlSerializer(type);//序列化转成XML的格式

       
        if (File.Exists(path))//判断是否含有该文件
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream(path, FileMode.Open);//打开该文件

                myNameScoers = (List<T>)xs.Deserialize(fs);

            }
            catch (Exception e)
            {
                Debug.LogError("打开错误,或者是类型不对" + e);
            }
            finally
            {
                //流用完关掉
                fs.Close();

            }
            return myNameScoers;
        }
        else
        {
            Debug.LogError("地址错误 检测不到文件");
            return null;
        }

    }
   
#endregion
    #region
    #endregion

    #region 删除指令

    /// <summary>
    /// 删除XML中某段数据
    /// </summary>
    /// <param name="path"></param>
    public static void M_Serialization_Remove<T>(List<T> ff, string path)
    {
        //  M_Serialization_Save(ff,path);

        if (File.Exists(path))
        {
            if (M_Deserialization_Read<T>(path).GetType() != ff.GetType())
            {
                Debug.LogError("当前要删除的数据类型和加载数据类型不符，请检查路径");
            }
            else
            {
                List<T> Quondam_List = M_Deserialization_Read<T>(path);

                List<T> Remove_List = new List<T>();

                foreach (T item in ff)
                {
                    //反射出要删除类里面的属性和字段
                    FieldInfo[] Remove_Field = item.GetType().GetFields();
                    PropertyInfo[] Remove_Property = item.GetType().GetProperties();
                    foreach (T item1 in Quondam_List)
                    {
                        //反射出原来数据里面类里面的属性和字段
                        FieldInfo[] Quondam_Field = item1.GetType().GetFields();
                        PropertyInfo[] Quondam_Property = item1.GetType().GetProperties();
                        //比较 是否一致 一致就删除
                        if (tool.Judge_Equality(Quondam_Field, Quondam_Property, Remove_Field, Remove_Property))
                        {
                            Remove_List.Add(item1);
                        }

                    }
                }
                foreach (T item in Remove_List)
                {
                    Quondam_List.Remove(item);
                }
                //最后保存
                M_Serialization_Save(Quondam_List, path);

            }
        }
        else
        {
            Debug.LogError("在读取的时候找不到该文件，检查地址");
        }

       




    }

    /// <summary>
    /// 删除XML中某段数据  单个
    /// </summary>
    /// <param name="path"></param>
    public static void M_Serialization_Remove<T>(T ff, string path)
    {
        List<T> Remove_List = new List<T>();
        Remove_List.Add(ff);
        M_Serialization_Remove(Remove_List, path);
    }
    /// <summary>
    /// 删除XML中某段数据 数组
    /// </summary>
    /// <param name="path"></param>
    public static void M_Serialization_Remove<T>(T[] ff, string path)
    {
        List<T> Remove_List = new List<T>();

        foreach (T item in ff)
        {
            Remove_List.Add(item);
        }

        M_Serialization_Remove(Remove_List, path);
    }


    #endregion

    #region 更新数据
   
   /// <summary>
   /// 更新数据
   /// </summary>
   /// <typeparam name="T"></typeparam>
   /// <param name="之前的数据"></param>
   /// <param name="要更换的数据"></param>
   /// <param name="路径"></param>
    public static void UpdateData<T>(T Quondam_data, T Now_data,string path)
    {
        List<T> temp_List = M_Deserialization_Read<T>(path);

       
        FieldInfo[] Quondam_Field = Quondam_data.GetType().GetFields();
        PropertyInfo[] Quondam_Property = Quondam_data.GetType().GetProperties();
        //判断是哪个数据
        for (int i = 0; i < temp_List.Count; i++)
        {
            FieldInfo[] temp_Field = temp_List[i].GetType().GetFields();
            PropertyInfo[] temp_Property = temp_List[i].GetType().GetProperties();
            if (tool.Judge_Equality(Quondam_Field, Quondam_Property, temp_Field, temp_Property))
            {
              temp_List[i]=Now_data;
                break;
            }
        }
        M_Serialization_Save(temp_List,path);
    }

    /// <summary>
    /// 更新数据 单个值
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="通过哪个名字的数据找到他"></param>
    /// <param name="他的值多少"></param>
    /// <param name="要改变的数据叫什么"></param>
    /// <param name="改成多少"></param>
    /// <param name="path"></param>
    public static void UpdateData<T>(string name, string value,string changeName,string changeValue, string path)
    {
        XElement root = XElement.Load(path);
        foreach (XElement item in root.Nodes())
        {
            if ((item.Element(name).Value).ToString()==value)
            {
                item.Element(changeName).Value = changeValue;
            }
        }
        root.Save(path);
    }
    #endregion
    #region 根据名字查找某个值

    public static string FindData(string name, string value, string changeName, string path)
    {
        string temp = "";
        XElement root = XElement.Load(path);
        foreach (XElement item in root.Nodes())
        {
            if ((item.Element(name).Value).ToString() == value)
            {
                temp = item.Element(changeName).Value;
              
            }
        }

        return temp;
    }
    #endregion
}
