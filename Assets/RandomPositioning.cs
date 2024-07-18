using System.Collections.Generic;
using UnityEngine;

public class RandomPositioning : MonoBehaviour
{
    private List<GameObject> childObjects = new List<GameObject>();

    void Start()
    {
        // 자식 오브젝트들을 리스트에 추가
        foreach (Transform child in transform)
        {
            childObjects.Add(child.gameObject);
        }

        // 각 자식 오브젝트의 위치를 랜덤하게 설정
        foreach (GameObject child in childObjects)
        {
            float randomX = Random.Range(-5f, 5f);
            float randomY = Random.Range(-5f, 5f);
            child.transform.localPosition = new Vector3(randomX, randomY, child.transform.localPosition.z);
        }
    }
}
