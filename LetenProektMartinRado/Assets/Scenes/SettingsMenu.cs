using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] private AudioMixer MainMixer;   // Exposed parameter name must match ExposedParam
    [SerializeField] private Slider MusicSlider;

    [Header("UI")]
    [SerializeField] private GameObject SettingsMenuUI;
    [SerializeField] private Button CloseSettingsButton;
    [SerializeField] private Button SettingsButton;

    private const string ExposedParam = "MusicVolume";
    private const string PrefsKey = "MusicVolume";

    private void Awake()
    {
        // Hook up UI buttons (defensive)
        if (SettingsButton != null) SettingsButton.onClick.AddListener(OpenSettings);
        else Debug.LogWarning("SettingsMenu: SettingsButton is NOT assigned in inspector.");

        if (CloseSettingsButton != null) CloseSettingsButton.onClick.AddListener(CloseSettings);
        else Debug.LogWarning("SettingsMenu: CloseSettingsButton is NOT assigned in inspector.");

        // Hook up slider (float signature)
        if (MusicSlider != null)
        {
            UnityEngine.Events.UnityAction<float> cb = SetMusicVolume;
            // Remove previous listener to avoid duplicates if this script is reloaded
            //MusicSlider.onValueChanged.RemoveListener(cb);
            MusicSlider.onValueChanged.AddListener(cb);
        }
        else Debug.LogWarning("SettingsMenu: MusicSlider is NOT assigned in inspector.");
    }

    private void Start()
    {
        // Hide menu on start
        CloseSettings();

        // Load saved value (default 1)
        float savedValue = PlayerPrefs.GetFloat(PrefsKey, 1f);

        if (MusicSlider != null)
            MusicSlider.value = savedValue;

        // Apply immediately (this will also be invoked by the slider change, but we call it explicitly)
        ApplyMusicVolume(savedValue);
    }

    public void OpenSettings()
    {
        if (SettingsMenuUI != null) SettingsMenuUI.SetActive(true);
    }

    public void CloseSettings()
    {
        if (SettingsMenuUI != null) SettingsMenuUI.SetActive(false);
    }

    // Called by Slider (float)
    public void SetMusicVolume(float sliderValue)
    {
        ApplyMusicVolume(sliderValue);

        // Save preference
        PlayerPrefs.SetFloat(PrefsKey, sliderValue);
        PlayerPrefs.Save();
    }

    // Optional: parameterless overload if you hooked this method in the inspector
    public void SetMusicVolume()
    {
        if (MusicSlider != null) SetMusicVolume(MusicSlider.value);
    }

    private void ApplyMusicVolume(float sliderValue)
    {
        // clamp 0..1 and avoid log10(0)
        sliderValue = Mathf.Clamp01(sliderValue);
        float dB = (sliderValue <= 0.001f) ? -80f : Mathf.Log10(sliderValue) * 20f;

        if (MainMixer == null)
        {
            Debug.LogWarning("SettingsMenu: MainMixer is NOT assigned in inspector.");
            return;
        }

        bool success = MainMixer.SetFloat(ExposedParam, dB);
        Debug.Log($"ApplyMusicVolume: slider={sliderValue:F3} -> dB={dB:F2} | SetFloat success: {success}");

        if (!success)
        {
            Debug.LogWarning($"SetFloat failed — make sure AudioMixer has an exposed parameter named '{ExposedParam}' (case-sensitive) and that the AudioSource is routed to that group.");
        }
    }
}
