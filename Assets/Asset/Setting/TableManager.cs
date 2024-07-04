using UnityEngine;
using System.Collections.Generic;
using GoogleSheetsToUnity; // Ensure this is the correct namespace
using UnityEngine.Events;

public class TableManager : MonoBehaviour
{
    private List<ItemDataReader> itemDataReaders;

    void Awake()
    {
        LoadItemDataReaders();
    }

    void Start()
    {
        foreach (var itemDataReader in itemDataReaders)
        {
            if (itemDataReader != null)
            {
                itemDataReader.DataList.Clear();
                UpdateStats(itemDataReader);
            }
            else
            {
                Debug.LogError("ItemDataReader is not assigned!");
            }
        }
    }

    void LoadItemDataReaders()
    {
        itemDataReaders = new List<ItemDataReader>(Resources.LoadAll<ItemDataReader>(""));
        if (itemDataReaders.Count == 0)
        {
            Debug.LogError("No ItemDataReader assets found in Resources!");
        }
    }

    void UpdateStats(ItemDataReader itemDataReader)
    {
        SpreadsheetManager.Read(new GSTU_Search(itemDataReader.associatedSheet, itemDataReader.associatedWorksheet), (ss) =>
        {
            for (int i = itemDataReader.START_ROW_LENGTH; i <= itemDataReader.END_ROW_LENGTH; ++i)
            {
                itemDataReader.UpdateStats(ss.rows[i], i);
            }
        });
    }
}
