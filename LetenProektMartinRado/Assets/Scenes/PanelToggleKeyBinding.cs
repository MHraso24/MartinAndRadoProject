using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public GameObject panel; // Assign your panel in Inspector

    private void Awake()
    {
        // Check if an instance already exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scenes
        }
        else
        {
            Destroy(gameObject); // Destroy duplicates
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && panel != null)
        {
            panel.SetActive(!panel.activeSelf);

            // Pause/resume game
            Time.timeScale = panel.activeSelf ? 0 : 1;
        }
    }
}
