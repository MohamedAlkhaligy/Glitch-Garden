using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private AudioSource audioSource;

    private static MusicPlayer myMusicPlayer = null;

    private void Start() {
        if (myMusicPlayer != null && myMusicPlayer != this) {
            Destroy(gameObject);
        } else {
            myMusicPlayer = this;
            DontDestroyOnLoad(gameObject);
            audioSource = GetComponent<AudioSource>();
            audioSource.volume = PlayerPrefsController.GetMasterVolume();
        } 
    }

    public void SetVolume(float volume) {
        audioSource.volume = volume;
    }
}
