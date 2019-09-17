using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] public Slider volumeSlider;
    [SerializeField] private float defaultVolume = 0.75f;
    [SerializeField] public Slider difficultySlider;
    [SerializeField] private float defaultDifficulty = 1f;

    private void Start() {
        volumeSlider.value = PlayerPrefsController.GetMasterVolume();
        difficultySlider.value = PlayerPrefsController.GetDifficulty();
    }

    private void Update() {
        var musicPlayer = FindObjectOfType<MusicPlayer>();
        if (musicPlayer) {
            musicPlayer.SetVolume(volumeSlider.value);
        } else {
            Debug.LogError("No MusicPlayer GameObject Found In Scene");
        }
    }

    public void SaveAndExit() {
        PlayerPrefsController.SetMasterVolume(volumeSlider.value);
        PlayerPrefsController.SetDifficulty(difficultySlider.value);
        FindObjectOfType<LevelManager>().LoadMainMenu();
    }

    public void SetDefaults() {
        volumeSlider.value = defaultVolume;
        PlayerPrefsController.SetMasterVolume(defaultVolume);
        difficultySlider.value = defaultDifficulty;
        PlayerPrefsController.SetDifficulty(defaultDifficulty);
    }
}
