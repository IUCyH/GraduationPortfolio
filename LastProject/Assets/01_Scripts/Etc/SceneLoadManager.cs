using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    Scene currentLoadingScene = Scene.None;
    
    public void Load(Scene scene)
    {
        asyncOperation = SceneManager.LoadSceneAsync((int)scene);
        currentLoadingScene = scene;
    }

    void Update()
    {
        if (asyncOperation != null && currentLoadingScene != Scene.None)
        {
            if (!asyncOperation.isDone)
            {
                //TODO : 로딩 바 업데이트 로직 작성 및 로딩 중 할 일 작성
            }
            else
            {
                //TODO : 로딩 바 100%로 채우는 로직 작성 및 로딩이 끝난 후 할 일 작성
                currentLoadingScene = Scene.None;
            }
        }
    }
}
 