using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCMovement : MonoBehaviour
{
    public Camera cam;
    public CharacterController characterController;

    public float movementSpeed = 10f;
    public float mouseSensitivity = 1f;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();    
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    float xRot = 0f;

    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * mouseSensitivity;

        Vector2 mouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        transform.Rotate(new Vector3(0, mouseInput.x));

        characterController.Move((transform.right * input.x + transform.forward * input.y).normalized * movementSpeed * Time.deltaTime);

        // Camera Rotation
        xRot -= mouseInput.y;

        xRot = Mathf.Clamp(xRot, -90f, 90f);

        cam.transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
    }
}
