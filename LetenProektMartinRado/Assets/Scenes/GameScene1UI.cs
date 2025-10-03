using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameScene1UI : MonoBehaviour
{
    [SerializeField] private Button ContinueButton;
    
    private void Awake()
    {

        ContinueButton.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.TaskScene1);
        });
    }
}
