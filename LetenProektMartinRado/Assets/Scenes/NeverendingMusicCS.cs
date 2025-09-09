using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;

    void Awake()
    {
        // If there's already a MusicManager, destroy this one
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // Otherwise, set this as the instance
        instance = this;

        // Don't destroy this object when loading new scenes
        DontDestroyOnLoad(gameObject);
    }
}
