using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private AudioMixer MainMixer;  
    [SerializeField] private Slider MusicSlider;
    [SerializeField] private GameObject SettingsMenuUI;
    [SerializeField] private Button CloseSettingsButton;
    [SerializeField] private Button SettingsButton;

    public void OpenSettings()
    {
        SettingsMenuUI.gameObject.SetActive(true);
    }

    public void CloseSettings()
    {
        SettingsMenuUI.gameObject.SetActive(false);
    }

    private void Awake()
    {
        SettingsButton.onClick.AddListener(() =>
        {
            OpenSettings();
        });
        CloseSettingsButton.onClick.AddListener(() =>
        {
            CloseSettings();
        });
    }

    private const string exposedParam = "MusicVolume"; // must match name in AudioMixer
    private const string prefsKey = "MusicVolume";

    void Start()
    {
        CloseSettings();
        // Load saved slider value (default = 1 if not saved before)
        float savedValue = PlayerPrefs.GetFloat(prefsKey, 1f);

        // Apply to UI and AudioMixer
        MusicSlider.value = savedValue;
        SetMusicVolume(savedValue);

        // Subscribe to slider changes
        MusicSlider.onValueChanged.AddListener(SetMusicVolume);
    }

    public void SetMusicVolume(float sliderValue)
    {
        // Clamp value to avoid Log10(0)
        float dB;
        if (sliderValue <= 0.0001f)
            dB = -80f; // silence
        else
            dB = Mathf.Log10(sliderValue) * 20f;

        MainMixer.SetFloat(exposedParam, dB);

        // Save preference
        PlayerPrefs.SetFloat(prefsKey, sliderValue);
    }
}
