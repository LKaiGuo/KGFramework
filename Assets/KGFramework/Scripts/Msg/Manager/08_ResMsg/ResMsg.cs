using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;
using UniRx;


public class ResMsg : BaseMsg
{
    public ResMsg(MsgFacade facade) : base(facade)
    {
    }
    #region AstncLoadScene

    Action loadedEvent = null;

    public void AsyncLoadScene(string SceneName, Action loadedEnd, Action<float> loadedStay=null)
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(SceneName);
        async.allowSceneActivation = false;
        LoadingPanel loading = facade.PushPanel<LoadingPanel>();
     
        loadedEvent = () =>
        {

            float val = async.progress;
            
            loadedStay?.Invoke(val);
           
            loading.Loading(val);
            if (val >= 0.89f)
            {

                loadedStay?.Invoke(1);
                loading.Loading(1);
                Observable.Timer(TimeSpan.FromSeconds(3)).Subscribe(_ =>
                {
                    facade.PopPanel();
                    async.allowSceneActivation = true;
                    loadedEnd();
                    async = null;
                    
                 
                });
                loadedEvent = null;

            }
        };
    }
    #endregion

    //public T LoadObj<T>(string path)
    //{
    //    Canvas
    //}


    public override void Update()
    {
        loadedEvent?.Invoke();
    }


    public override void Init()
    {

    }

    public override void OnDestroy()
    {

    }
}

