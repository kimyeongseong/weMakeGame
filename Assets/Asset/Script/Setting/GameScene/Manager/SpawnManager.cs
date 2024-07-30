using UnityEngine;

/// <summary>
/// 맵에 존재하는 오브젝트 타입
/// </summary>
public enum ObjectType
{
    Unit
}

// 스폰을 전반적으로 관리
public class SpawnManager : MonoBehaviour
{
    public GameObject SpawnObject(ObjectType objectType, Vector3 position, Quaternion rotation, string unitName)
    {
        GameObject unitPrefab = null;
        switch (objectType)
        {
            case ObjectType.Unit:
                unitPrefab = Framework.GameModule.ResourceLoadManager.LoadResource<GameObject>("Prefab/Unit");
                break;
        }

        if (unitPrefab != null)
        {
            GameObject unit = Instantiate(unitPrefab, position, rotation);
            AtlasAnimation atlasAnimation = unit.GetComponent<AtlasAnimation>();
            if (atlasAnimation != null)
            {
                atlasAnimation.SetAtlasName(unitName);
            }
            else
            {
                Debug.LogError("AtlasAnimation component not found on unit prefab.");
            }
            return unit;
        }

        Debug.LogError("Prefab not assigned for object type: " + objectType);
        return null;
    }
}
