using UnityEngine;
[CreateAssetMenu(fileName = "DownloadInfo", menuName = "Data/Download Info")]
public class SO_DownloadInfo : ScriptableObject
{
    public string Link => _link;
    public string SavePath => Application.persistentDataPath + _savePath;
    [SerializeField] string _link;
    [SerializeField] string _savePath;
}
