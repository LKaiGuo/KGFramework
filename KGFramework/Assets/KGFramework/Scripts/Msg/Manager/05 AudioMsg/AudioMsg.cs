using UnityEngine;
using System.Collections;




public class AudioMsg : BaseMsg
{

    public AudioSource audioSourceBG;
    public AudioSource audioSourceNormal;


    public float AudioVolume=1;

    public const string StartPath= "Sounds/";

   

    public AudioMsg(MsgFacade facade) : base(facade)
    {
    }

    public override void OnDestroy()
    {
       
    }



    public override void Init()
    {
        GameObject audio = new GameObject("AudioGameObject");
        audio.transform.parent = facade.gameObject.transform;
        audioSourceBG = audio.AddComponent<AudioSource>();
        audioSourceNormal= audio.AddComponent<AudioSource>();
        PlayBG(AudioNmae.S_BGM);
    }


    public void SetAudioVolume()
    {
        audioSourceBG.volume = AudioVolume;
        audioSourceNormal.volume = AudioVolume;
    }

    /// <summary>
    /// 播放循环音乐
    /// </summary>
    /// <param name="sourceName"></param>
    /// <param name="volume"></param>
    public void PlayBG(string sourceName,float volume= 0.5f)
    {
        PlaySource(audioSourceBG,LoadClip(sourceName),volume, true);
    }
    /// <summary>
    /// 播放音效
    /// </summary>
    /// <param name="sourceName"></param>
    /// <param name="volume"></param>
    public void PlayNormal(string sourceName, float volume = 1)
    {
        PlaySource(audioSourceNormal, LoadClip(sourceName), volume);
    }

    /// <summary>
    /// 播放
    /// </summary>
    /// <param name="source"></param>
    /// <param name="clip"></param>
    /// <param name="volume"></param>
    /// <param name="loop"></param>
    public void PlaySource(AudioSource source,AudioClip clip,float volume,bool loop=false)
    {
        source.clip = clip;
        source.volume = volume;
        source.loop = loop;
        source.Play();
    }
    /// <summary>
    /// 加载
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public AudioClip LoadClip(string path)
    {
        return Resources.Load<AudioClip>(StartPath+path);
    }

    public string Add()
    {
        return "1";
    }

    public override void Update()
    {
  
    }
}
