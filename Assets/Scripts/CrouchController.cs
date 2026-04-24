using UnityEngine;
using StarterAssets;

public class CrouchController : MonoBehaviour
{
    [Header("Crouch Settings")]
    public float crouchHeight = 1.0f;
    public float standHeight = 1.8f;
    public float crouchSpeed = 1.5f;
    public float standSpeed = 5.335f;
    public float crouchTransitionSpeed = 10f;

    [Header("Camera Settings")]
    public Transform cameraRoot;
    public float crouchCameraY = 0.8f;
    public float standCameraY = 1.375f;

    CharacterController characterController;
    ThirdPersonController thirdPersonController;
    Animator animator;

    bool isCrouching = false;
    float targetHeight;
    float targetCameraY;

    static readonly int CrouchParam = Animator.StringToHash("Crouch");

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        thirdPersonController = GetComponent<ThirdPersonController>();
        animator = GetComponent<Animator>();

        targetHeight = standHeight;
        targetCameraY = standCameraY;
    }

    void Update()
    {
        HandleCrouchInput();
        SmoothCrouch();
    }

    void HandleCrouchInput()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            isCrouching = !isCrouching;

            if (isCrouching)
            {
                targetHeight = crouchHeight;
                targetCameraY = crouchCameraY;
                thirdPersonController.MoveSpeed = crouchSpeed;
                thirdPersonController.SprintSpeed = crouchSpeed;
            }
            else
            {
                // Check there's room to stand up
                if (!Physics.SphereCast(transform.position, 0.3f, Vector3.up, out _, standHeight))
                {
                    targetHeight = standHeight;
                    targetCameraY = standCameraY;
                    thirdPersonController.MoveSpeed = standSpeed;
                    thirdPersonController.SprintSpeed = 5.335f;
                }
                else
                {
                    // Cant stand up, stay crouched
                    isCrouching = true;
                }
            }

            animator.SetBool(CrouchParam, isCrouching);
        }
    }

    void SmoothCrouch()
    {
        // Smoothly adjust collider height
        float newHeight = Mathf.Lerp(
            characterController.height,
            targetHeight,
            Time.deltaTime * crouchTransitionSpeed
        );
        characterController.height = newHeight;

        // Keep collider centered
        Vector3 center = characterController.center;
        center.y = newHeight / 2f;
        characterController.center = center;

        // Smoothly move camera root down
        if (cameraRoot != null)
        {
            Vector3 camPos = cameraRoot.localPosition;
            camPos.y = Mathf.Lerp(camPos.y, targetCameraY, Time.deltaTime * crouchTransitionSpeed);
            cameraRoot.localPosition = camPos;
        }
    }

    public bool IsCrouching() => isCrouching;
}