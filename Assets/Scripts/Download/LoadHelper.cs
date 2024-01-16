using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public abstract class LoadHelper<T> : MonoBehaviour
{
    [SerializeField] SO_Event _onLoadRequest;
    [SerializeField] SO_BaseEvent<T> _onLoadComplited;
    [SerializeField] SO_BaseEvent<T> _onDownloadComplited;
    [SerializeField] SO_Event _onDownloadRequest;
    [SerializeField] protected SO_DownloadInfo _downloadInfo;


    protected virtual void OnLoadRequest(){
        Debug.LogWarning("OnLoadRequestNotImplemented");
        //check if file exsists at _downloadInfo.Path
            //if so invoke OnLoadComplited with exsisting file
            //if not send download request > wait for _downloadComplited, then onLoadComplited.Invoke(Loaded);
    }

    protected void OnLoadComplited(T value){
        _onLoadComplited.Invoke(value);
    }

    protected void RequestDownload(){
        _onDownloadRequest.Invoke();
    }
    protected virtual void OnDownloadComplited(T value){
        OnLoadComplited(value);
    }
    
    protected bool CheckPath(string path){
        if(File.Exists(path)) return true;
        return false;
    }

    protected virtual void OnEnable() {
        _onLoadRequest.AddListener(OnLoadRequest);
        _onDownloadComplited.AddListener(OnLoadComplited);
    }
    protected virtual void OnDisable() {
        _onLoadRequest.RemoveListener(OnLoadRequest);
        _onDownloadComplited.RemoveListener(OnLoadComplited);
    }
}
