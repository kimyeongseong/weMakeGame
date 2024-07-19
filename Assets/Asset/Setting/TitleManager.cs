using UnityEngine;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    // 버튼 참조
    public Button loadSceneButton;
    public string sceneNameToLoad;

    private void Start()
    {
        loadSceneButton= GetComponent<Button>();
        // 버튼 클릭 시 LoadScene 메서드 호출
        loadSceneButton.onClick.AddListener(() => LoadScene(sceneNameToLoad));
    }

    // 씬 로드 메서드
    public void LoadScene(string sceneName)
    {
        Framework.Instance.SceneManager.LoadSceneAsync(sceneName);
    }
}