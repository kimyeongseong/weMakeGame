using UnityEngine;
using GoogleSheetsToUnity;
using System.Collections.Generic;
using System;
using UnityEngine.Events;

#if UNITY_EDITOR
using UnityEditor;
#endif

[Serializable]
public struct ItemData
{
    public int index;
    public string name;
    public float value;
    public string tag;

    public ItemData(int index, string name, float value, string tag)
    {
        this.index = index;
        this.name = name;
        this.value = value;
        this.tag = tag;
    }
}

[CreateAssetMenu(fileName = "Reader", menuName = "Scriptable Object/ItemDataReader", order = int.MaxValue)]
public class ItemDataReader : DataReaderBase
{
    [Header("스프레드시트에서 읽혀져 직렬화 된 오브젝트")][SerializeField] public List<ItemData> DataList = new List<ItemData>();

    internal void UpdateStats(List<GSTU_Cell> list, int itemID)
    {
        int index = 0;
        string name = null, tag = null;
        float value = 0;

        for (int i = 0; i < list.Count; i++)
        {
            Debug.Log($"Column ID: {list[i].columnId}, Value: {list[i].value}");
            switch (list[i].columnId)
            {
                case "index":
                    if (int.TryParse(list[i].value, out int parsedIndex))
                    {
                        index = parsedIndex;
                    }
                    else
                    {
                        Debug.LogError($"Failed to parse 'index' with value: {list[i].value}");
                    }
                    break;
                case "name":
                    name = list[i].value;
                    break;
                case "value":
                case "vaule": // Handle the typo
                    if (float.TryParse(list[i].value, out float parsedValue))
                    {
                        value = parsedValue;
                    }
                    else
                    {
                        Debug.LogError($"Failed to parse 'value' with value: {list[i].value}");
                    }
                    break;
                case "tag":
                    tag = list[i].value;
                    break;
            }
        }

        DataList.Add(new ItemData(index, name, value, tag));
        Debug.Log($"Added Item: {index}, {name}, {value}, {tag}");
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(ItemDataReader))]
public class ItemDataReaderEditor : Editor
{
    ItemDataReader data;

    void OnEnable()
    {
        data = (ItemDataReader)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        GUILayout.Label("\n\n스프레드 시트 읽어오기");

        if (GUILayout.Button("데이터 읽기(API 호출)"))
        {
            UpdateStats(UpdateMethodOne);
            data.DataList.Clear();
        }
    }

    void UpdateStats(UnityAction<GstuSpreadSheet> callback, bool mergedCells = false)
    {
        SpreadsheetManager.Read(new GSTU_Search(data.associatedSheet, data.associatedWorksheet), callback, mergedCells);
    }

    void UpdateMethodOne(GstuSpreadSheet ss)
    {
        for (int i = data.START_ROW_LENGTH; i <= data.END_ROW_LENGTH; ++i)
        {
            data.UpdateStats(ss.rows[i], i);
        }

        EditorUtility.SetDirty(target);
    }
}
#endif
