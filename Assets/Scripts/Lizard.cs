using UnityEngine;

public class Lizard : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        GameObject gameObject = other.gameObject;
        if (gameObject.GetComponent<Defender>()) {
            GetComponent<Attacker>().Attack(gameObject);
        }
    }
}
