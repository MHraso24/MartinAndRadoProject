using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TaskScene1Script : MonoBehaviour
{
    [SerializeField] private Button HideInfoButton;
    [SerializeField] private Button ShowInfoButton;
    [SerializeField] private Button StoryLineContinueButton1;
    public GameObject panel;
    public Image img;


    private void Awake()
    {

        ShowInfoButton.onClick.AddListener(() =>
        {
            panel.SetActive(true);
        });

        HideInfoButton.onClick.AddListener(() =>
        {
            panel.SetActive(false);
        });
        StoryLineContinueButton1.onClick.AddListener(() =>
        {
            img.gameObject.SetActive(false);
        });
    }
}
