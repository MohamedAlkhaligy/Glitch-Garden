using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour
{
    [SerializeField] int stars = 100;

    private Text starText;

    public void AddingStars(int amount) {
        stars += amount;
        UpdateDisplay();
    }

    public void SpendingStars(int amount) {
        if (stars < amount) { return; }
        stars -= amount;
        UpdateDisplay();
    }

    public bool HaveEnoughStars(int amount) {
        return amount <= stars;
    }
    
    private void Start()
    {
        starText = GetComponent<Text>();
        UpdateDisplay();
    }

    private void UpdateDisplay() {
        starText.text = stars.ToString();
    }
}
