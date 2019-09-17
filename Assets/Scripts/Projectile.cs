using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float projectileDamgae = 50f;
    [SerializeField] float projectileSpeed = 5f;
    [SerializeField] int projectilePenetrationCount = 1;

    private int penetrationCount = 0;

    void Update()
    {
        transform.Translate(Vector2.right * projectileSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.GetComponent<Attacker>()) {
            other.GetComponent<StatusManager>().DealDamage(projectileDamgae);
            penetrationCount++;
        }

        if (penetrationCount == projectilePenetrationCount) {
            Destroy(gameObject);
        }
    }
}
