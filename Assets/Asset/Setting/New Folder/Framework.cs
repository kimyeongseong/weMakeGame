using System.Collections;
using UnityEngine;

public class Framework : MonoBehaviour
{
    private static Framework instance;

    public static Framework Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Framework>();
                if (instance == null)
                {
                    GameObject singleton = new GameObject(typeof(Framework).Name);
                    instance = singleton.AddComponent<Framework>();
                    DontDestroyOnLoad(singleton);
                }
            }
            return instance;
        }
    }

    private SceneModule sceneModule;
    public static SceneModule SceneModule => Instance.sceneModule;

    private GameModule gameModule;
    public static GameModule GameModule => Instance.gameModule;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            StartCoroutine(InitializeModules());
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator InitializeModules()
    {
        sceneModule = new SceneModule(this);
        gameModule = new GameModule(this);

        yield return gameModule.Initialize();

        // 게임 시작 또는 다른 초기화 완료 작업 수행
    }
}
