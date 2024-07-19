using UnityEngine;
using UnityEngine.UI;

public class CameraManager : MonoBehaviour
{
    private static CameraManager instance;
    private Camera mainCamera;

    public static CameraManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<CameraManager>();
                if (instance == null)
                {
                    Debug.LogError("No CameraManager instance found in the scene.");
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

            // Setup Camera and Canvas
            SetupCameraAndCanvas();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetupCameraAndCanvas()
    {
        // 메인 카메라 찾기
        mainCamera = Camera.main;
        if (mainCamera == null)
        {
            Debug.LogError("No Main Camera found in the scene.");
            return;
        }

        mainCamera.orthographic = true;
        
        float targetAspect = 360.0f / 640.0f;
        float windowAspect = (float)Screen.width / (float)Screen.height;
        float scaleHeight = windowAspect / targetAspect;

        if (scaleHeight < 1.0f)
        {
            Rect rect = mainCamera.rect;
            rect.width = 1.0f;
            rect.height = scaleHeight;
            rect.x = 0;
            rect.y = (1.0f - scaleHeight) / 2.0f;
            mainCamera.rect = rect;
        }
        else
        {
            float scaleWidth = 1.0f / scaleHeight;
            Rect rect = mainCamera.rect;
            rect.width = scaleWidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scaleWidth) / 2.0f;
            rect.y = 0;
            mainCamera.rect = rect;
        }

        mainCamera.orthographicSize = 640.0f / 2.0f / 100.0f; // 100은 PPU(Pixels Per Unit)입니다.

        // Canvas 찾기 또는 생성
        Canvas canvas = FindObjectOfType<Canvas>();
        if (canvas == null)
        {
            Debug.LogError("No Canvas found in the scene.");
            return;
        }

        // Canvas 설정
        SetupCanvas(canvas);
    }

    public void SetupCanvas(Canvas canvas)
    {
        if (canvas != null)
        {
            CanvasScaler scaler = canvas.GetComponent<CanvasScaler>();
            if (scaler == null)
            {
                scaler = canvas.gameObject.AddComponent<CanvasScaler>();
            }
            scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            scaler.referenceResolution = new Vector2(360, 640);
            scaler.screenMatchMode = CanvasScaler.ScreenMatchMode.MatchWidthOrHeight;
            scaler.matchWidthOrHeight = 0.5f; // 너비와 높이를 균등하게 맞춤
        }
    }
}
