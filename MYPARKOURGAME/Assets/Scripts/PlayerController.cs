using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 0.1f; // Topun hareket hızı
    public float jumpForce = 15f; // Zıplama gücü
    private Rigidbody rb;
    private bool isGrounded;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // Topun dönmesini engelle
    }

    void Update()
    {
        Move();
        Jump();

         if (!isGrounded)
        {
            rb.AddForce(Physics.gravity * 2 , ForceMode.Acceleration);
        }
    }

    void Move()
    {
        Camera camera = Camera.main;
        Vector3 forward = camera.transform.forward;
        Vector3 right = camera.transform.right;

        forward.y = 0;
        right.y = 0;

        Vector3 movement = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            movement += forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            movement -= forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            movement -= right;
        }
        if (Input.GetKey(KeyCode.D))
        {
            movement += right;
        }

        rb.AddForce(movement.normalized * speed, ForceMode.VelocityChange);
       
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            isGrounded = false;
        }
    }

}
