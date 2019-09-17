using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public enum Scenes{
        SplashScreen = 0,
        StartMenu = 1,
    }
    private const float splashDelayTime = 3f;
    private int currentSceneIndex;


    private void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == (int)Scenes.SplashScreen) {
            StartCoroutine(LoadNextScene(splashDelayTime));
        }
    }

    public IEnumerator LoadNextScene(float delayTime) {
        yield return new WaitForSeconds(delayTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadNextScene() {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (currentSceneIndex < SceneManager.sceneCountInBuildSettings) {
            SceneManager.LoadScene(currentSceneIndex);
        }
    }

    public void RestartScene() {
        StartCoroutine(LoadScene(currentSceneIndex));
    }

    public void LoadMainMenu() {
        StartCoroutine(LoadScene((int)Scenes.StartMenu));
    }

    public void LoadOptionsScene() {
        SceneManager.LoadScene("Options Scene");
    }

    public IEnumerator LoadScene(int sceneIndex, float delayTime = 0) {
        Time.timeScale = 1;
        yield return new WaitForSeconds(delayTime);
        SceneManager.LoadScene(sceneIndex);
    }

    public void QuitGame() {
        Application.Quit();
    }

}
