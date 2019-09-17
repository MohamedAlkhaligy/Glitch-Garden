using UnityEngine;

public class BaseShredder : MonoBehaviour
{
    private HealthDisplay healthDisplay;
    void Start()
    {
        healthDisplay = FindObjectOfType<HealthDisplay>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Attacker attacker = other.GetComponent<Attacker>();
        if (attacker) {
            healthDisplay.DecreaseHealth(attacker.GetAttackerBaseDamage());
            Destroy(other.gameObject);
        }
    }

}
