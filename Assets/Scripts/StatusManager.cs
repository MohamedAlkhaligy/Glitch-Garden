using UnityEngine;

public class StatusManager : MonoBehaviour
{
    [SerializeField] float health = 100f;

    public GameObject deathVFXPrefab;

    public void DealDamage(float damage) {
        health -= damage;
        if (health <= 0) {
            TriggerDeathVFX();
            Destroy(gameObject);
        }
    }
    
    private void TriggerDeathVFX() {
        GameObject deathVFX = Instantiate(deathVFXPrefab, this.transform.position, Quaternion.identity) as GameObject;
        Destroy(deathVFX, 1f);
    }
}
