using System.Collections;
using UnityEngine;

public class GameModule
{
    public TableManager TableManager { get; }
    public SpawnManager SpawnManager { get; }
    public ResourceLoadManager ResourceLoadManager { get; }

    public GameModule(MonoBehaviour owner)
    {
        TableManager = owner.gameObject.AddComponent<TableManager>();
        SpawnManager = owner.gameObject.AddComponent<SpawnManager>();
        ResourceLoadManager = owner.gameObject.AddComponent<ResourceLoadManager>();
    }

    public IEnumerator Initialize()
    {
        yield return TableManager.FetchSheetData();

        // 추가 초기화 작업이 필요하다면 여기에 추가
    }
}
