using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public static class Loader
{
    public enum Scene
    {
        MainMenu, GameScene1, LoadingScene, TaskScene1
    }

    private static Scene targetScene;


    public static void Load(Scene targetScene)
    {
        Loader.targetScene = targetScene;
        SceneManager.LoadScene(Scene.LoadingScene.ToString());
    }

    public static void LoaderCallback()
    {
        SceneManager.LoadScene(targetScene.ToString());
    }
}
