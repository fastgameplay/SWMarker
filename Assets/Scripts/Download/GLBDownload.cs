using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

public class GLBDownload : DownloadHelper<byte[]>
{
    protected override IEnumerator Download(){
        using (UnityWebRequest www = UnityWebRequest.Get(_downloadInfo.Link)){
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success){
                Save(www.downloadHandler.data);
            }
            else{
                Debug.LogWarning("Error downloading GLB file: " + www.error);
               _onDownloadError.Invoke(); 
            }
        }
    }

    protected override void Save(byte[] data){
        string directoryPath = Path.GetDirectoryName(_downloadInfo.SavePath);

        if (!Directory.Exists(directoryPath)){
            Directory.CreateDirectory(directoryPath);
        }

        File.WriteAllBytes(_downloadInfo.SavePath, data);

        _onDownloadComplited.Invoke(data);

        Debug.Log("GLB file downloaded and saved to: " + _downloadInfo.SavePath);
    }

}
