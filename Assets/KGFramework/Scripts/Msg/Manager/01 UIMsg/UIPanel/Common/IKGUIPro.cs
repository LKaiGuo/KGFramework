using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public interface IKGUIPro
{



    void Init();

    void InitUI();

    void PlayClickSound();

    void ResetUI();

    Transform SetUITop();


    /// <summary>
    /// 界面被显示出来
    /// </summary>
    void OnEnter();

    /// <summary>
    /// 界面暂停
    /// </summary>
    void OnPause();

    /// <summary>
    /// 界面继续
    /// </summary>
    void OnResume();

    /// <summary>
    /// 界面不显示,退出这个界面，界面被关系
    /// </summary>
    void OnExit();


}

