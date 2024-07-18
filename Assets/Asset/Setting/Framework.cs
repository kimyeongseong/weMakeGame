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

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            // Initialize TableManager
            AddTableManagerComponent();
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

    private static TableManager tableManagerInstance;
    public static TableManager TableManager
    {
        get
        {
            if (tableManagerInstance == null)
            {
                tableManagerInstance = Instance.GetComponent<TableManager>();
            }
            return tableManagerInstance;
        }
    }
}
