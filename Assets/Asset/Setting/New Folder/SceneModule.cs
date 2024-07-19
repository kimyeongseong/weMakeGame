using UnityEngine;

public class SceneModule
{
    public SceneManager SceneManager { get; }
    public CameraManager CameraManager { get; }

    public SceneModule(MonoBehaviour owner)
    {
        SceneManager = owner.gameObject.AddComponent<SceneManager>();
        CameraManager = owner.gameObject.AddComponent<CameraManager>();

        CameraManager.SetupCameraAndCanvas();
    }
}
