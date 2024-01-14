using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

public class PNGDownloader : DownloadHelper<Texture2D>
{
    protected override IEnumerator Download(){
        using(UnityWebRequest www = UnityWebRequestTexture.GetTexture(_downloadInfo.Link)){
            yield return www.SendWebRequest();
            if(www.result == UnityWebRequest.Result.Success){
                Save(DownloadHandlerTexture.GetContent(www));
            }
            else{
                Debug.LogWarning("Error while downloading Texture");
               _onDownloadError.Invoke(); 
            }

        }
    }

    protected override void Save(Texture2D value){
        byte[] bytes = value.EncodeToPNG();
        
        string directoryPath = Path.GetDirectoryName(_downloadInfo.SavePath);
        if (!Directory.Exists(directoryPath)){
            Directory.CreateDirectory(directoryPath);
        }
        Debug.Log(directoryPath);
        Debug.Log(_downloadInfo.SavePath);
        File.WriteAllBytes(_downloadInfo.SavePath, bytes);
        _onDownloadComplited.Invoke(value);
    }

}
