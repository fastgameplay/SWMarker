using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GLBLoader : LoadHelper<Byte[]>
{
    protected override void OnLoadRequest(){
        if(CheckPath(_downloadInfo.SavePath)){

            return;
        }
        Debug.Log("Image Not Found, Requested Download...");
        RequestDownload();
    }
    protected override void OnDownloadComplited(Byte[] value){

    }
}
