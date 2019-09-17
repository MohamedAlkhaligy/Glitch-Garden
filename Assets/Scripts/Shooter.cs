using UnityEngine;

public class Shooter : MonoBehaviour
{

    public GameObject projectileLaunchPoint;
    public Projectile  projectile;

    private AttackerSpawner myLaneSpawner;
    private Animator animator;
    private GameObject projectileParent;

    private const string PROJECTILE_PARENT_NAME = "Projectiles";

    public void Fire() {
        Projectile newProjectile =
            Instantiate(projectile, projectileLaunchPoint.transform.position, transform.rotation)
            as Projectile;
        newProjectile.transform.parent = projectileParent.transform;
    }

    private void Start() {
        SetLaneSpawner();
        CreateProjectileParent();
        animator = GetComponent<Animator>();
    }

    private void CreateProjectileParent() {
        projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);
        if (!projectileParent) {
            projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
        }
    }

    private void Update() {
        if(IsAttackerInLane()) {
            animator.SetBool("isAttacking", true);
        } else {
            animator.SetBool("isAttacking", false);
        }
    }

    private void SetLaneSpawner() {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();

        foreach (AttackerSpawner spawner in spawners) {
            bool isCloseEnough = 
                (Mathf.Abs(spawner.transform.position.y - transform.position.y)
                <= Mathf.Epsilon);

            if (isCloseEnough) {
                myLaneSpawner = spawner;
            }
        }
    }

    private bool IsAttackerInLane() {
        return myLaneSpawner.transform.childCount > 0;
    }
}
