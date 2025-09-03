using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Button PlayButton;
    [SerializeField] private Button QuitButton;

    private void Awake()
    {
        PlayButton.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.GameScene1);
        });
        QuitButton.onClick.AddListener(() =>
        {
            Application.Quit();
        });
    }
}
