using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{

    private Defender defender;
    private GameObject defenderParent;
    private const string DEFENDER_PARENT_NAME = "Defenders";

    private void Start() {
        CreateDefenderParent();
    }

    private void CreateDefenderParent() {
        defenderParent = GameObject.Find(DEFENDER_PARENT_NAME);
        if (!defenderParent) {
            defenderParent = new GameObject(DEFENDER_PARENT_NAME);
        }
    }

    public void setSelectedDefender(Defender selectedDefender){
        this.defender = selectedDefender;
    }

    private void OnMouseDown() {
        if (!defender) return;
        AttemptToPlaceDefenderAt(GetSquareClicked());
    }

    private Vector2 GetSquareClicked() {
        var clickPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        var worldPosition = Camera.main.ScreenToWorldPoint(clickPosition);
        return SnapToGrid(worldPosition);
    }

    private Vector2 SnapToGrid(Vector2 position) {
        var newX = Mathf.RoundToInt(position.x);
        var newY = Mathf.RoundToInt(position.y);
        return new Vector2(newX, newY);
    }

    private void SpawnDefender(Vector2 position) {
        Defender newDefender = Instantiate(defender, position, Quaternion.identity) as Defender;
        newDefender.transform.parent = defenderParent.transform;
    }

    private void AttemptToPlaceDefenderAt(Vector2 position) {
        var starDisplay = FindObjectOfType<StarDisplay>();
        var defenderCost = defender.GetStarCost();
        if (starDisplay.HaveEnoughStars(defenderCost)) {
            SpawnDefender(position);
            starDisplay.SpendingStars(defenderCost);
        }
    }
}
