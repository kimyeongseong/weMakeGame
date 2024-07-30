using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Manage game stages
/// <summary>
/// 게임 스테이지를 관리함
/// </summary>
public class StageManager : MonoBehaviour
{
    private static StageManager instance;

    public static StageManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<StageManager>();
                if (instance == null)
                {
                    Debug.LogError("No StageManager instance found in the scene.");
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    float spawnTime = 1f;
    int wave = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetWave(int wv)
    {
        wave = wv;
    }

    /// <summary>
    /// 다음 웨이브로 진행
    /// </summary>
    public void NextWave()  { wave++; }

    /// <summary>
    /// 적 스폰 시작
    /// </summary>
    public void StartSpawn()
    {
        InvokeRepeating("SpawnEnemy", 0f, spawnTime);
    }

    void SpawnEnemy()
    {
        
    }
}
