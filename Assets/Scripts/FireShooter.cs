using UnityEngine;

public class FireShooter : MonoBehaviour
{
    [Header("Fire Prefabs")]
    public GameObject[] firePrefabs;

    [Header("Settings")]
    public Camera playerCamera;
    public float fireRange = 50f;
    public float fireSpawnOffset = 0.5f;

    [Header("Burn Tracking")]
    public int requiredBurnCount = 10;
    public GameObject endPrompt;

    int burnCount = 0;
    bool canEnd = false;

    void Start()
    {
        if (endPrompt != null)
            endPrompt.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            ShootFire();

        if (canEnd && Input.GetKeyDown(KeyCode.E))
            LoadOutro();
    }

    void ShootFire()
    {
        if (playerCamera == null) return;

        Ray ray = playerCamera.ScreenPointToRay(
            new Vector3(Screen.width / 2, Screen.height / 2, 0));

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, fireRange))
        {
            int randomIndex = Random.Range(0, firePrefabs.Length);
            GameObject firePrefab = firePrefabs[randomIndex];

            Vector3 spawnPos = hit.point + hit.normal * fireSpawnOffset;
            Quaternion spawnRot = Quaternion.LookRotation(hit.normal);
            GameObject fire = Instantiate(firePrefab, spawnPos, spawnRot);

            burnCount++;
            Debug.Log("Burn count: " + burnCount);

            CheckBurnComplete();
        }
    }

    void CheckBurnComplete()
    {
        if (burnCount >= requiredBurnCount && !canEnd)
        {
            canEnd = true;
            if (endPrompt != null)
                endPrompt.SetActive(true);
        }
    }

    void LoadOutro()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("EndOutro");
    }
}