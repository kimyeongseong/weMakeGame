using System.Collections;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    // 비동기 씬 로드 (씬 이름으로)
    public void LoadSceneAsync(string sceneName)
    {
        StartCoroutine(LoadSceneAsyncCoroutine(sceneName));
    }

    // 비동기 씬 로드 (씬 인덱스로)
    public void LoadSceneAsync(int sceneIndex)
    {
        StartCoroutine(LoadSceneAsyncCoroutine(sceneIndex));
    }

    // 비동기 씬 로드를 처리하는 코루틴 (씬 이름)
    private IEnumerator LoadSceneAsyncCoroutine(string sceneName)
    {
        // 테이블이 로드될 때까지 대기
        yield return StartCoroutine(WaitForTablesToLoad());

        AsyncOperation asyncLoad = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName);
        
        // 씬 로드가 완료될 때까지 대기
        while (!asyncLoad.isDone)
        {
            // 여기서 로딩 상태를 업데이트하거나 다른 작업을 수행할 수 있습니다.
            yield return null;
        }
    }

    // 비동기 씬 로드를 처리하는 코루틴 (씬 인덱스)
    private IEnumerator LoadSceneAsyncCoroutine(int sceneIndex)
    {
        // 테이블이 로드될 때까지 대기
        yield return StartCoroutine(WaitForTablesToLoad());

        AsyncOperation asyncLoad = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneIndex);
        
        // 씬 로드가 완료될 때까지 대기
        while (!asyncLoad.isDone)
        {
            // 여기서 로딩 상태를 업데이트하거나 다른 작업을 수행할 수 있습니다.
            yield return null;
        }
    }

    // 테이블이 로드될 때까지 대기하는 코루틴
    private IEnumerator WaitForTablesToLoad()
    {
        while (!Framework.TableManager.AreTablesLoaded)
        {
            yield return null;
        }
    }
}
