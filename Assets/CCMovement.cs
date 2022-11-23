using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCMovement : MonoBehaviour
{
    public Camera cam;
    public CharacterController characterController;
    public Transform groundCheckTransform;

    public LayerMask playerLayer;
    public float movementSpeed = 10f;
    public float mouseSensitivity = 1f;
    /// <summary>
    /// Amount of vertical force to add when jumping
    /// </summary>
    public float jumpForce = 5f;
    /// <summary>
    /// Amount the vertical force added by jumping is reduced every frame.
    /// </summary>
    public float jumpDecay = 0.1f;
    public float gravityForce = -9.7f;

    public bool enableCam = true; 

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();    
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    float xRot = 0f;
    bool jump = false;
    [SerializeField] bool grounded = false;
    float verticalForce;

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheckTransform.position, .5f);
    }

    void Update()
    {
        if(groundCheckTransform != null)
        {
            Collider[] hits = Physics.OverlapSphere(groundCheckTransform.position, 0.5f, ~playerLayer);
            if (hits.Length > 0)
            {   
                grounded = true;
            } else
            {
                grounded = false;
            }
        }

        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * mouseSensitivity;

        Vector2 mouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            jump = true;
            verticalForce = jumpForce;
        }

        if(jump)
        {
            verticalForce -= jumpDecay;
            if (verticalForce <= 0)
                jump = false;
        }
        else
        {
            if(verticalForce > gravityForce)
            {
                verticalForce -= jumpDecay;
            } else
            {
                verticalForce = gravityForce;
            }
        }

        //print(verticalForce);

        Vector3 movement = (transform.right * input.x + transform.forward * input.y).normalized * movementSpeed;
        
        characterController.Move(new Vector3(movement.x, verticalForce, movement.z) * Time.deltaTime);

        // Rotation
        if (enableCam)
        {
            transform.Rotate(new Vector3(0, mouseInput.x));

            xRot -= mouseInput.y;

            xRot = Mathf.Clamp(xRot, -90f, 90f);

            cam.transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
        }
        
    }
}
