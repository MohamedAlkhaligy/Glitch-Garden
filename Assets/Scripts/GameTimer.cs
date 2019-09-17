using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Level Timer in SECONDS")]
    [SerializeField] private float levelTime = 10f;

    private bool triggeredLevelFinished = false;

    private void Update() {
        if (triggeredLevelFinished) { return; }

        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;
        bool isTimerFinished = (Time.timeSinceLevelLoad >= levelTime);
        if (isTimerFinished) {
            FindObjectOfType<LevelController>().LevelTimerFinised();
            triggeredLevelFinished = true;
        }
    }
}
