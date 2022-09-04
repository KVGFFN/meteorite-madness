using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cam : MonoBehaviour
{
    
    // Movement
    private float yaw = 0.0f, pitch = 0.0f;
    private Rigidbody rb;

    private float walkSpeed = 5.0f, sensitivty = 5.0f;
    private Vector3 jump = new Vector3(0, 250, 0);
    private bool isGrounded = true;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = gameObject.GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        Look();
        checkJumpState();
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(jump);
        }
    }

    private void FixedUpdate()
    {
        Movement();
    }
    

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Collider name: {collision.collider.name}");
        if (collision.collider.name.Contains("Meteorite"))
        {
            Debug.Log($"Player hit a meteorite!");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene(2);
        }
    }

    void checkJumpState()
    {
        if (rb.velocity.y != 0)
        {
            isGrounded = false;
        }
        else
        {
            isGrounded = true;
        }
    }
    

    void Look()
    {
        pitch -= Input.GetAxisRaw("Mouse Y") * sensitivty;
        pitch = Mathf.Clamp(pitch, -90.0f, 90.0f);
        yaw += Input.GetAxisRaw("Mouse X") * sensitivty;
        
        Camera.main.transform.localRotation = Quaternion.Euler(pitch, yaw, 0);
    }
    
    
    void Movement()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        Vector3 move = new Vector3(x, 0, z);
        move = Camera.main.transform.TransformDirection(move);
        move.y = 0;
        move.Normalize();

        var xMovement = move.x * walkSpeed;
        var zMovement = move.z * walkSpeed;
        
        rb.velocity = new Vector3(xMovement, rb.velocity.y, zMovement);
        if (Input.GetKey(KeyCode.LeftShift))
        {
            walkSpeed = 15.0f;
        }

        if (!Input.GetKey(KeyCode.LeftShift))
        {
            walkSpeed = 5.0f;
        }
    }
}
