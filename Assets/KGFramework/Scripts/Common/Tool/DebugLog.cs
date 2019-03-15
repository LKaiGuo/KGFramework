using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DebugLog :MonoBehaviour
{

    public static Text text;

    public static int dd=0;


    public static string qw="";
    public void Start()
    {

        text = GetComponent<Text>();
        text.text = "";
    }

    private void Update()
    {
        if (!string.IsNullOrEmpty(qw))
        {
          
            text.text += qw;
            qw = "";
            text.text += "";
        }
    }

    public static void Log_(string s)
    {
        dd++;
        qw+= "第"+dd+"条："+s+"\n";
    }
}
