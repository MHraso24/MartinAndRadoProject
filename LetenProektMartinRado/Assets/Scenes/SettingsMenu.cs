using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] private AudioMixer MainMixer;   // Must have exposed param "MusicVolume"
    [SerializeField] private Slider MusicSlider;

    [Header("UI")]
    [SerializeField] private GameObject SettingsMenuUI;
    [SerializeField] private Button CloseSettingsButton;
    [SerializeField] private Button SettingsButton;

    private const string ExposedParam = "MusicVolume";
    private const string PrefsKey = "MusicVolume";

    private void Awake()
    {
        // Hook up open/close buttons
        SettingsButton.onClick.AddListener(OpenSettings);
        CloseSettingsButton.onClick.AddListener(CloseSettings);

        // Hook up slider in Inspector instead of here (avoids duplicate calls)
        // musicSlider.onValueChanged.AddListener(SetMusicVolume); // remove this if set in Inspector
    }

    private void Start()
    {
        // Hide menu on start
        CloseSettings();

        // Load saved volume (default = 1)
        float savedValue = PlayerPrefs.GetFloat(PrefsKey, 1f);
        MusicSlider.value = savedValue;

        // Apply immediately
        SetMusicVolume(savedValue);
    }

    public void OpenSettings()
    {
        SettingsMenuUI.SetActive(true);
    }

    public void CloseSettings()
    {
        SettingsMenuUI.SetActive(false);
    }

    public void SetMusicVolume(float sliderValue)
    {
        // Avoid Log10(0) by clamping
        float dB = (sliderValue <= 0.0001f) ? -80f : Mathf.Log10(sliderValue) * 20f;

        // Update mixer
        MainMixer.SetFloat("MusicVolume", dB);
        Debug.Log("Slider value: " + sliderValue);

        // Save preference
        PlayerPrefs.SetFloat("MusicVolume", sliderValue);

     ///   bool success = MainMixer.SetFloat("MusicVolume", dB);
     ///   Debug.Log("Trying to set MusicVolume to " + dB + " dB | Success: " + success);
    }
}
