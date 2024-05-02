using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;

public class Json : MonoBehaviour
{
    public TMP_Text nm;
    public TMP_Text lvl;
    public Slider dat1;
    public string jsonURL;
    public JsonClass jsnData;
    void Start()
    {
        dat1.interactable = false;
        StartCoroutine(getData());
    }
    IEnumerator getData()
    {
        Debug.Log("Download...");
        var uwr = new UnityWebRequest(jsonURL);
        uwr.method = UnityWebRequest.kHttpVerbGET;
        var resultFile = Path.Combine(Application.persistentDataPath, "result.json");
        var dh = new DownloadHandlerFile(resultFile);
        dh.removeFileOnAbort = true;
        uwr.downloadHandler = dh;
        yield return uwr.SendWebRequest();
        if (uwr.result != UnityWebRequest.Result.Success)
            nm.text = "ERROR";
        else
        {
            Debug.Log("Download saved to: " + resultFile);
            jsnData = JsonUtility.FromJson<JsonClass>(File.ReadAllText(Application.persistentDataPath + "/result.json"));
            nm.text = jsnData.Name.ToString();
            lvl.text = jsnData.Level.ToString();
            dat1.value = jsnData.Level;
            yield return StartCoroutine(getData());
        }
    }

    [System.Serializable]
    public class JsonClass
    {
        public string Name;
        public int Level;
    }
}