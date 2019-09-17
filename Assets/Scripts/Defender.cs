using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] int starCost = 100;

    public void AddingStars(int amount) {
        FindObjectOfType<StarDisplay>().AddingStars(amount);
    }

    public int GetStarCost() {
        return starCost;
    }
}
