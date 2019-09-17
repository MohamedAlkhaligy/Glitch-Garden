using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] private int baseHealth = 5;

    private float health;
    private Text healthText;

    public void DecreaseHealth(int amount) {
        health -= amount;
        if (health <= 0) {
            FindObjectOfType<LevelController>().HandleLoseCondition();
        }
        UpdateDisplay();
    }

    private void Start() {
        health = baseHealth - PlayerPrefsController.GetDifficulty();
        healthText = GetComponent<Text>();
        UpdateDisplay();
    }

    private void UpdateDisplay() {
        healthText.text = health.ToString();
    }
}
