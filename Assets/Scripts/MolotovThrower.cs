using UnityEngine;

public class MolotovThrower : MonoBehaviour
{
    [Header("Molotov Settings")]
    public GameObject molotovPrefab;
    public Transform throwPoint;
    public float throwForce = 15f;
    public float throwUpwardForce = 5f;

    [Header("Fire Settings")]
    public GameObject[] firePrefabs;
    public float fireSpawnRadius = 1.5f;
    public int fireSpawnCount = 3;

    [Header("Animation")]
    public Animator animator;

    bool isThrown = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Left click detected!");
            if (!isThrown)
                StartThrow();
            else
                Debug.Log("Already thrown, waiting...");
        }
    }

    void StartThrow()
    {
        Debug.Log("StartThrow called!");
        isThrown = true;

        if (animator != null)
            animator.SetTrigger("Throw");
        else
            Debug.Log("Animator is NULL!");

        if (molotovPrefab == null)
            Debug.Log("Molotov Prefab is NULL!");

        if (throwPoint == null)
            Debug.Log("ThrowPoint is NULL!");

        Invoke(nameof(SpawnAndThrow), 0.4f);
        Invoke(nameof(ResetThrow), 1.5f);
    }

    void SpawnAndThrow()
    {
        Debug.Log("SpawnAndThrow called!");
        if (molotovPrefab == null || throwPoint == null) return;

        GameObject molotov = Instantiate(molotovPrefab,
            throwPoint.position, throwPoint.rotation);

        Rigidbody rb = molotov.GetComponent<Rigidbody>();
        if (rb == null)
            rb = molotov.AddComponent<Rigidbody>();

        // Ignore collision between molotov and player
        Collider molotovCollider = molotov.GetComponent<Collider>();
        Collider playerCollider = GetComponent<Collider>();
        if (molotovCollider != null && playerCollider != null)
            Physics.IgnoreCollision(molotovCollider, playerCollider);

        Vector3 throwDirection = Camera.main.transform.forward;
        rb.AddForce(throwDirection * throwForce +
            Vector3.up * throwUpwardForce, ForceMode.Impulse);

        MolotovProjectile projectile = molotov.GetComponent<MolotovProjectile>();
        if (projectile == null)
            projectile = molotov.AddComponent<MolotovProjectile>();

        projectile.firePrefabs = firePrefabs;
        projectile.fireSpawnRadius = fireSpawnRadius;
        projectile.fireSpawnCount = fireSpawnCount;

        Debug.Log("Molotov spawned and thrown!");
    }

    void ResetThrow()
    {
        isThrown = false;
        Debug.Log("Reset - ready to throw again");
    }
}