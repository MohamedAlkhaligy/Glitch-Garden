using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour
{

    [SerializeField] public GameObject winLabel;
    [SerializeField] public GameObject loseLabel;
    
    [Tooltip("Win Label show time in Seconds")]
    [SerializeField] private float winDelayTime = 1.5f;

    private int numberOfAttackers = 0;
    private bool levelTimerFinished = false;

    public void AttackerSpawned() {
        numberOfAttackers++;
    }

    public void AttackerDestroyed() {
        numberOfAttackers--;
        if (numberOfAttackers <= 0 && levelTimerFinished) {
            StartCoroutine(HandleWinCondition());
        }
    }

    public void LevelTimerFinised() {
        levelTimerFinished = true;
        StopSpawners();
    }

    public void HandleLoseCondition() {
        loseLabel.SetActive(true);
        Time.timeScale = 0;
    }

    private void Start() {
        winLabel.SetActive(false);
        loseLabel.SetActive(false);
    }

    private void StopSpawners() {
        AttackerSpawner[] attackerSpawners = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner attackerSpawner in attackerSpawners) {
            attackerSpawner.StopSpawning();
        }
    }

    private IEnumerator HandleWinCondition() {
        winLabel.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(winDelayTime);
        FindObjectOfType<LevelManager>().LoadNextScene();
    }
}
