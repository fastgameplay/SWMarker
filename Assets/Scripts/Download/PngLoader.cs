using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PngLoader : LoadHelper<Texture2D>
{
    protected override void OnLoadRequest(){
        if(CheckPath(_downloadInfo.SavePath)){
            byte[] fileData = System.IO.File.ReadAllBytes(_downloadInfo.SavePath);
            Texture2D texture = new Texture2D(2,2);
            texture.LoadImage(fileData);
            OnLoadComplited(texture);
            return;
        }
        Debug.Log("Image Not Found, Requested Download...");
        RequestDownload();
    }
    // protected override void OnDownloadComplited(Texture2D value){
    //     OnLoadComplited
    // }
}