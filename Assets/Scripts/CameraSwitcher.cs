using UnityEngine;
using Unity.Cinemachine;

public class CameraSwitcher : MonoBehaviour
{
    [Header("Cameras")]
    public CinemachineCamera thirdPersonCam;
    public CinemachineCamera firstPersonCam;

    bool isFirstPerson = false;

    void Start()
    {
        thirdPersonCam.Priority = 20;
        firstPersonCam.Priority = 5;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
            ToggleCamera();
    }

    void ToggleCamera()
    {
        isFirstPerson = !isFirstPerson;

        if (isFirstPerson)
        {
            thirdPersonCam.Priority = 5;
            firstPersonCam.Priority = 20;
        }
        else
        {
            thirdPersonCam.Priority = 20;
            firstPersonCam.Priority = 5;
        }
    }
}