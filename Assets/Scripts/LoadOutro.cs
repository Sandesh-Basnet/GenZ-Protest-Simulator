using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadOutro : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SceneManager.LoadScene("Outro");
        }
    }
}