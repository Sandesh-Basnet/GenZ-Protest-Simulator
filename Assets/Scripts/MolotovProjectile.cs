using UnityEngine;

public class MolotovProjectile : MonoBehaviour
{
    [Header("Fire Settings")]
    public GameObject[] firePrefabs;
    public float fireSpawnRadius = 1.5f;
    public int fireSpawnCount = 3;

    bool hasExploded = false;

    void OnCollisionEnter(Collision collision)
    {
        if (hasExploded) return;
        hasExploded = true;

        Debug.Log("Molotov hit: " + collision.gameObject.name);

        Vector3 hitPoint = collision.contacts[0].point;
        SpawnFire(hitPoint);

        // Destroy bottle on impact
        Destroy(gameObject, 0.1f);
    }

    void SpawnFire(Vector3 hitPoint)
    {
        if (firePrefabs == null || firePrefabs.Length == 0)
        {
            Debug.Log("No fire prefabs assigned!");
            return;
        }

        for (int i = 0; i < fireSpawnCount; i++)
        {
            Vector3 randomOffset = new Vector3(
                Random.Range(-fireSpawnRadius, fireSpawnRadius),
                0,
                Random.Range(-fireSpawnRadius, fireSpawnRadius)
            );

            Vector3 spawnPos = hitPoint + randomOffset;
            int randomIndex = Random.Range(0, firePrefabs.Length);
            Instantiate(firePrefabs[randomIndex], spawnPos, Quaternion.identity);
        }

        Debug.Log("Fire spawned at: " + hitPoint);
    }
}