using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class LoadGoogleSheet : MonoBehaviour
{
    const string googleSheetURL = "https://docs.google.com/spreadsheets/d/1gxz5J8xEh3owhlCK_vSTWdRh-Cp5QKVgxX-HX1PhnbY/export?format=tsv&range=A2:D3";

    private string sheetData;

    public IEnumerator FetchSheetData()
    {
        using (UnityWebRequest www = UnityWebRequest.Get(googleSheetURL))
        {
            yield return www.SendWebRequest();

            if (www.isDone && string.IsNullOrEmpty(www.error))
            {
                sheetData = www.downloadHandler.text;
            }
            else
            {
                Debug.LogError("Error fetching Google Sheet: " + www.error);
            }
        }
    }

    public string GetSheetData()
    {
        return sheetData;
    }
}
