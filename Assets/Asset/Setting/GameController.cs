using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Button spawnUnitButton;

    void Start()
    {
                if (!gameObject.TryGetComponent<Button>(out spawnUnitButton))
        {
            spawnUnitButton = gameObject.AddComponent<Button>();
        }
        // 버튼에 클릭 이벤트 연결
        if (spawnUnitButton != null)
        {
            spawnUnitButton.onClick.AddListener(() => SpawnUnit("unit_himawari"));
        }
        else
        {
            Debug.LogError("Spawn Unit Button is not assigned!");
        }
    }

    void SpawnUnit(string unitName)
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-5f, 5f), 0, Random.Range(-5f, 5f));
        Framework.GameModule.SpawnManager.SpawnObject(ObjectType.Unit, spawnPosition, Quaternion.identity, unitName);
    }
}
