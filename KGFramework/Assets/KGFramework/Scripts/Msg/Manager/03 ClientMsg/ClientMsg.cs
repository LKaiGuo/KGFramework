using UnityEngine;
using System.Collections;
using System;
using System.Net.Sockets;
using System.Text;
using System.Linq;
using System.Collections.Generic;

public class ClientMsg : BaseMsg
{
    public ClientMsg(MsgFacade facade) : base(facade)
    {
    }

    private const string IP = "192.168.2.97";
    private const int PORT = 8898;

    private Socket Msocket;

    public static readonly string Obj = "lock";

    public Queue<RXD> RxdQue=new Queue<RXD>();

    private byte[] Data
    {
        get { return data; }
    }

    /// <summary>
    /// 数据
    /// </summary>
    private byte[] data = new byte[1024];

    public override void OnDestroy()
    {
       // GameFacade.Instance.GameOver(1);
        Msocket. Shutdown(SocketShutdown.Both);
       Msocket.Close();
        Debug.Log("dd");
        Debug.Log(Msocket.Connected);
    }

    public override void Init()
    {

        Msocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        Debug.Log("练了789789798765465412012310");
        try
        {
            Msocket.Connect(IP, PORT);
          
            Start();
        }
        catch (Exception e)
        {

            Debug.Log("无法连接上位机" + e);
        }
    }

    public override void Update()
    {

        if (RxdQue.Count>0)
        {
            
            RXD data = RxdQue.Dequeue();
  
            OnProcessDataCallback(data.ReceiveData,data.count);
            
        }
    }

    // Use this for initialization
    void Start()
    {
        Msocket.BeginReceive(data,0,data.Length, SocketFlags.None,ReceiveCallback,null);
    }

    /// <summary>
    /// 接收
    /// </summary>
    /// <param name="ar"></param>
    public void ReceiveCallback(IAsyncResult ar)
    {

        try
        {

            if (Msocket == null|| Msocket.Connected==false)
            {
                return;
            }

            int count1 = Msocket.EndReceive(ar);
            if (count1 == 0)
            {
                OnDestroy();
            }
            AddRXD(new RXD {ReceiveData=data,count= count1 });
           // OnProcessDataCallback(data,count1);
           
            Start();
        }
        catch (Exception e)
        {
           
            
            Debug.Log(e.ToString());
        }
    }


    /// <summary>
    /// 接收到然后回调
    /// </summary>
    /// <param name="ReceiveData"></param>
    public void OnProcessDataCallback(byte[] ReceiveData,int count)
    {
        try
        {
            string s = Encoding.UTF8.GetString(ReceiveData, 0, count);

            Debug.Log(s);
        //    DebugLog.Log_(s);

            string[] subData = s.Split('/');

            string temp = null;

            temp = s.Substring(subData[0].Length + 1);

            if (facade.GetScheme(subData[0])!=null)
            {
                facade.GetScheme(subData[0]).OnScheme(temp); ;
            }
            
        }
        catch (Exception e)
        {

            Debug.Log(e);
        }
        
    }

    
    public void Send_Scheme(string name,string s)
    {

        byte[] temp = Encoding.UTF8.GetBytes(name+"/");
        byte[] temp1= Encoding.UTF8.GetBytes(s);



       Msocket.Send(temp.Concat(temp1).ToArray<byte>());
      
    }
    public void Send_Data(string s)
    {

        
        byte[] temp1 = Encoding.UTF8.GetBytes(s);



        Msocket.Send(temp1);

    }

    public void AddRXD(RXD data)
    {
       
            RxdQue.Enqueue(data);

    }


}

public class RXD
{
   public byte[] ReceiveData;
    public int count;
}
