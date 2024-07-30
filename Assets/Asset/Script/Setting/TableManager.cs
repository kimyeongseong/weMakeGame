using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableManager : MonoBehaviour
{
    public List<string[]> data = new List<string[]>();
    private LoadGoogleSheet loadGoogleSheet;
    private bool tablesLoaded;

    public bool AreTablesLoaded => tablesLoaded;

    private void Awake()
    {
        loadGoogleSheet = gameObject.AddComponent<LoadGoogleSheet>();
    }

    public void SetData(string sheetData)
    {
        string[] rows = sheetData.Split('\n');
        foreach (string row in rows)
        {
            data.Add(row.Split('\t'));
        }
        tablesLoaded = true;
    }

    public string GetData(int row, int column)
    {
        if (row < data.Count && column < data[row].Length)
        {
            return data[row][column];
        }
        return null;
    }

    public IEnumerator FetchSheetData()
    {
        yield return loadGoogleSheet.FetchSheetData();
        SetData(loadGoogleSheet.GetSheetData());
    }
}
