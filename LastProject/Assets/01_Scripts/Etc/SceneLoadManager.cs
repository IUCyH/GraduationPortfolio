using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum Scene
{
    None = -1,
    Title,
    Game
}

public class SceneLoadManager : Singleton_DontDestroy<SceneLoadManager>
{
    AsyncOperation asyncOperation;
    [SerializeField]
    Canvas loadingCanvas;
    [SerializeField]
    Image loadingBar;

    int playerID;

    Scene currentLoadingScene = Scene.None;

    protected override void OnStart()
    {
        loadingCanvas.enabled = false;
    }

    public void Load(Scene scene, int? id)
    {
        EventManager.Instance.CancelAllInvoke();
        asyncOperation = SceneManager.LoadSceneAsync((int)scene);
        currentLoadingScene = scene;
        if (id.HasValue)
        {
            playerID = id.Value;
        }
        loadingCanvas.enabled = true;
    }

    void Update()
    {
        if (asyncOperation != null && currentLoadingScene != Scene.None)
        {
            if (!asyncOperation.isDone)
            {
                loadingBar.fillAmount = asyncOperation.progress;
                //TODO : 로딩 바 업데이트 로직 작성 및 로딩 중 할 일 작성
            }
            else
            {
                //TODO : 로딩 바 100%로 채우는 로직 작성 및 로딩이 끝난 후 할 일 작성
                loadingBar.fillAmount = 1f;

                
                GameManager.Instance.SetPlayer(playerID); //(int)id -> id.Value로 고치기
                GameStoryManager.Instance.InitAllChapterScripts();

                currentLoadingScene = Scene.None;
                loadingCanvas.enabled = false;
            }
        }
    }
}
 