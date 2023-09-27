using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Scene
{
    Title,
    Game
}

public class SceneLoadManager : Singleton_DontDestroy<SceneLoadManager>
{
    AsyncOperation asyncOperation;

    

    public void Load(Scene scene)
    {
        SceneManager.LoadSceneAsync((int)scene);    
    }

    void Update()
    {
        if (!asyncOperation.isDone)
        {

        }
        else
        {
            //GameManager
        }
    }
}
 