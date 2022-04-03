using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    [Header("camera")]
    public float sensX;
    public float sensY;

    public Transform camHolder;

    float xRot;
    float yRot;

    Rigidbody rb;
    [Header("movement")]
    public float moveSpeed;

    public float groundDrag;

    public float jumpForce;
    public float airMultiplier;

    float hInput;
    float vInput;

    Vector3 moveDir;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        rb = transform.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        hInput = Input.GetAxisRaw("Horizontal");
        vInput = Input.GetAxisRaw("Vertical");

        yRot += mouseX;
        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -90, 90);

        rb.rotation = Quaternion.Euler(0, yRot, 0);
        camHolder.localRotation = Quaternion.Euler(xRot, 0, 0);
        Physics.SyncTransforms();

        moveDir = transform.forward * vInput + transform.right * hInput;

        grounded = Physics.Raycast(transform.position,Vector3.down,playerHeight*.5f+.2f,whatIsGround);
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {

            
            rb.AddForce(transform.up * Mathf.Sqrt(jumpForce * -2f * Physics.gravity.y), ForceMode.VelocityChange);
        }
    }

    private void FixedUpdate()
    {
       

       
        

        if (grounded)
        {
            
            rb.AddForce(moveDir.normalized * moveSpeed * 10f, ForceMode.Acceleration);
            rb.drag = groundDrag;
            Physics.SyncTransforms();


        }
        else
        {
            rb.AddForce(moveDir.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Acceleration);
            rb.drag = 0;
            Physics.SyncTransforms();
        }

        

        Vector3 flatVel = new Vector3(rb.velocity.x, 0, rb.velocity.z);

        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
            Physics.SyncTransforms();
        }


        

    }

   
}
