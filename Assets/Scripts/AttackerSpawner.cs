using UnityEngine;
using System.Collections;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] float minSpawnDelay = 1f, maxSpawnDelay = 5f;
    public Attacker[] attackerPrefabs;

    private bool spawn = true;

    public void StopSpawning() {
        spawn = false;
    }

    private IEnumerator Start() {
        while (spawn) {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
        }
    }

    private void SpawnAttacker() {
        var index = Random.Range(0, attackerPrefabs.Length);
        Spawn(attackerPrefabs[index]);
    }

    private void Spawn(Attacker attacker) {
        Attacker newAttacker = Instantiate
            (attacker, this.transform.position, transform.rotation)
            as Attacker;
        newAttacker.transform.parent = transform;
    }
}
