using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float walkSpeed = 5f;
    [SerializeField] private float sprintSpeed = 15f;
    [SerializeField] private float jumpHeight = 3f;
    [SerializeField]private Rigidbody rb;
    private Vector3 movement;
    [SerializeField]private Transform playerBody;
    [SerializeField]private float mouseSensitivity;
    private float xRotation = 0f;
    [SerializeField] private Animator animator;
    private bool isGround = true;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.useGravity = true;
        Movement();
        Rotation();
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            Jump();
            
        }
        
    }

    public void Movement()
    {
     
        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : walkSpeed;
        float horizontal = Input.GetAxis("Horizontal")*currentSpeed;
        float vertical = Input.GetAxis("Vertical")*currentSpeed;
        bool isMoving = horizontal != 0 || vertical != 0;
        movement = transform.right * horizontal + transform.forward * vertical;
        transform.position += movement * Time.deltaTime;
        if (isMoving)
        {
            if (currentSpeed >= sprintSpeed)
            {
                animator.SetTrigger("RunTrigger");
                animator.ResetTrigger("WalkTrigger");
              
            }
            else
            {
                animator.SetTrigger("WalkTrigger");
                animator.ResetTrigger("RunTrigger");
             
            }
        }
        else
        {
            
            animator.ResetTrigger("WalkTrigger");
            animator.ResetTrigger("RunTrigger");
        }

    }

    public void Jump()
    {
       // rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
      
       float jumpVelocity = Mathf.Sqrt(2 * Mathf.Abs(Physics.gravity.y) * jumpHeight);
       rb.velocity = new Vector3(rb.velocity.x, jumpVelocity, rb.velocity.z);
       isGround = false;
       Debug.Log("Ground e nai");
       // playerBody.position += Vector3.up + jumpHeight;
    }

    public void BackToGround()
    {
        if (!isGround)
        {
            rb.AddForce(Vector3.up * Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y), ForceMode.Impulse);
            isGround = false;
        }
    }
    public void Rotation()
    {
        float mouseX = Input.GetAxis("Mouse X")*mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y")*mouseSensitivity;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Collision detected with: " + other.gameObject.name);
        if (other.gameObject.CompareTag("Ground"))
        {
            isGround = true;
            Debug.Log("Ground e ache");
        }
    }
}
