using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class LoadGoogleSheet : MonoBehaviour
{
    private string sheetData;

    public IEnumerator FetchSheetData()
    {
        UnityWebRequest www = UnityWebRequest.Get("https://docs.google.com/spreadsheets/d/1gxz5J8xEh3owhlCK_vSTWdRh-Cp5QKVgxX-HX1PhnbY/export?format=tsv&range=A2:D3");
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError(www.error);
        }
        else
        {
            sheetData = www.downloadHandler.text;
        }
    }

    public string GetSheetData()
    {
        return sheetData;
    }
}
