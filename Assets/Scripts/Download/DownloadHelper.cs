using System.Collections;
using UnityEngine;

public abstract class DownloadHelper<T> : MonoBehaviour
{
    [Header("Events")]
    //Out Events
    [SerializeField] protected SO_Event _onDownloadError;
    [SerializeField] protected SO_BaseEvent<T> _onDownloadComplited;
    
    [Space(2)]
    //In Events
    [SerializeField] private SO_Event _onDownloadRequest;
    
    [Space(10)]
    [Header("Data")]
    [SerializeField] protected SO_DownloadInfo _downloadInfo;
    
    [Header("Settings")]
    [SerializeField] private bool _downloadOnStart;

    private Coroutine _downloadCorroutine;

    protected virtual void Start(){
        if(_downloadOnStart) OnDownloadRequest();

    }
    protected abstract IEnumerator Download();
    protected abstract void Save(T value);
    protected virtual void OnDownloadRequest(){
        if(_downloadCorroutine != null) return;
        _downloadCorroutine = StartCoroutine("Download");
    }
}
