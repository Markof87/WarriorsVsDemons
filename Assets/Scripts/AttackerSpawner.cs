using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField]
    private Attacker attackerPrefab;

    [SerializeField]
    private float minSpawnDelay = 1f;

    [SerializeField]
    private float maxSpawnDelay = 5f;

    private bool spawn = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartSpawning());
    }

    private IEnumerator StartSpawning()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
        }
    }

    private void SpawnAttacker()
    {
        Attacker newAttacker = Instantiate(attackerPrefab, transform.position, transform.rotation);
        newAttacker.transform.parent = transform;
    }
}
