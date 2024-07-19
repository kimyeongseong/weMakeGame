using UnityEngine;

public enum ObjectType
{
    Unit
}

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
