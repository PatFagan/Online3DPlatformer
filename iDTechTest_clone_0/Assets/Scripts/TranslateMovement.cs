using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class TranslateMovement : NetworkBehaviour
{
    // movement variables
    public float speed;
    public Rigidbody physicsComponent;

    // jump variables
    bool isGrounded;
    float distToGround, dashCooldown = 0;
    public float jumpForce, dashForce, dashTimeout;

    public AudioSource jumpSound;
    public AudioSource dashSound;

    // runs on start
    void Start()
    {
        physicsComponent = gameObject.GetComponent<Rigidbody>();
        distToGround = GetComponent<Collider>().bounds.extents.y;
    }

    // runs once per frame
    void Update()
    {
        if (isLocalPlayer)
        {
            Movement();

            Jump();

            Dash();
        }
    }

    void Jump()
    {
        // check if grounded
        isGrounded = Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.5f);
        
        // add jump force on button press
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            jumpSound.Play();
            physicsComponent.AddForce(Vector3.up * jumpForce);
        }
        else if (Input.GetButtonUp("Jump"))
        {
            physicsComponent.AddForce(Vector3.down * (jumpForce / 2));
        }

        // increase fall speed
        if (physicsComponent.velocity.y < -0.1 && dashCooldown <= 0)
        {
            physicsComponent.velocity += Vector3.up * Physics2D.gravity.y * (jumpForce / 400f) * Time.deltaTime;
        }
    }

    void Dash()
    {
        dashCooldown--;

        if (Input.GetButtonDown("Dash") && dashCooldown <= 0)
        {
            dashSound.Play();
            physicsComponent.AddForce(new Vector3(physicsComponent.velocity.x * dashForce, 0f, physicsComponent.velocity.z * dashForce));
            dashCooldown = dashTimeout;
            physicsComponent.velocity = new Vector3(0f, 0f, 0f);
        }
    }

    // contains movement code
    void Movement()
    {
        // x axis
        if (Input.GetAxis("Horizontal") > 0)
        {
            physicsComponent.AddForce(Vector3.right * speed);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            physicsComponent.AddForce(Vector3.left * speed);
        }

        // z axis
        if (Input.GetAxis("Vertical") > 0)
        {
            physicsComponent.AddForce(Vector3.forward * speed);
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            physicsComponent.AddForce(Vector3.back * speed);
        }

        transform.LookAt(Vector3.Lerp(transform.position, new Vector3(physicsComponent.velocity.x * dashForce, 0f, physicsComponent.velocity.z * dashForce), .1f));
    }

    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();
        gameObject.tag = "LocalPlayer";
    }
}
