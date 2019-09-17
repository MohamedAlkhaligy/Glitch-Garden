using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private int attackerBaseDamage = 1;

    private float currentSpeed = 1f;
    private GameObject currentTarget;
    private Animator animator;

    private void Awake() {
        animator = GetComponent<Animator>();
        FindObjectOfType<LevelController>().AttackerSpawned();
    }

    private void OnDestroy() {
        var levelController = FindObjectOfType<LevelController>();
        if (levelController) {
            levelController.AttackerDestroyed();
        }
    }

    private void Update()
    {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        if (!currentTarget) {
            animator.SetBool("isAttacking", false);
        }
    }

    public void SetMovementSpeed(float speed) {
        currentSpeed = speed;
    }

    public void Attack(GameObject target) {
        animator.SetBool("isAttacking", true);
        currentTarget = target;
    }

    public void StrikeCurrentTarget(float damage) {
        if (!currentTarget) { return; }
        StatusManager statusManager = currentTarget.GetComponent<StatusManager>();
        if (statusManager) {
            statusManager.DealDamage(damage);
        }
    }

    public int GetAttackerBaseDamage() {
        return attackerBaseDamage;
    }
}
