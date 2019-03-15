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

public  class Tool 
{
    /// <summary>
    /// 判断里面的属性和字段的值是否都一致
    /// </summary>
    /// <param name="field"></param>
    /// <param name="property"></param>
    /// <param name="field2"></param>
    /// <param name="property2"></param>
    /// <returns></returns>
    public bool Judge_Equality(FieldInfo[] field, PropertyInfo[] property, FieldInfo[] field2, PropertyInfo[] property2)
    {
        int temp = 0;
        foreach (FieldInfo item in field)
        {
            foreach (FieldInfo item2 in field2)
            {
                if (item.Name==item2.Name)
                {
                    temp++;
                }
            }
        }
       
        foreach (PropertyInfo item in property)
        {
            foreach (PropertyInfo item2 in property2)
            {
                if (item.Name == item2.Name)
                {
                    temp++;
                }
            }
        }


        return temp == field.Length + property.Length;
    }
}
