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

    private SceneManager sceneManager;
    public SceneManager SceneManager
    {
        get
        {
            if (sceneManager == null)
            {
                sceneManager = gameObject.AddComponent<SceneManager>();
            }
            return sceneManager;
        }
    }

    private CameraManager cameraManager;
    public CameraManager CameraManager
    {
        get
        {
            if (cameraManager == null)
            {
                cameraManager = gameObject.AddComponent<CameraManager>();
            }
            return cameraManager;
        }
    }

    private TableManager tableManager;
    public static TableManager TableManager
    {
        get
        {
            if (Instance.tableManager == null)
            {
                Instance.tableManager = Instance.gameObject.AddComponent<TableManager>();
            }
            return Instance.tableManager;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            // Initialize components
            AddTableManagerComponent();
            
            // Setup Camera and Canvas
            CameraManager.SetupCameraAndCanvas();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void AddTableManagerComponent()
    {
        gameObject.AddComponent<TableManager>();
    }
}
