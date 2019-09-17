using UnityEngine;
using UnityEngine.UI;

public class DefenderButton : MonoBehaviour
{
    [SerializeField] public Defender defenderPrefab;

    private Color defaultColor;

    private void Start() {
        defaultColor = this.gameObject.GetComponent<SpriteRenderer>().color;
        LabelButtonWithCost();
    }

    private void LabelButtonWithCost() {
        Text costText = GetComponentInChildren<Text>();
        if (costText) {
            costText.text = defenderPrefab.GetStarCost().ToString();
        } else {
            Debug.LogError(name + " has no cost text, add cost");
        }
    }

    private void OnMouseDown() {
        var buttons = FindObjectsOfType<DefenderButton>();
        foreach (DefenderButton button in buttons) {
            button.ResetDefault();
        }
        GetComponent<SpriteRenderer>().color = Color.white;
        FindObjectOfType<DefenderSpawner>().setSelectedDefender(defenderPrefab);
    }

    public void ResetDefault() {
        this.GetComponent<SpriteRenderer>().color = defaultColor;
    }
}
