using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class TranslateMovement : NetworkBehaviour
{
    // movement variables
    public float moveSpeed = 50f, rotLerp = 100f;
    public float speedScalar = 200f, defaultSpeedScalar = 200f;
    public Rigidbody physicsComponent;

    // jump variables
    bool isGrounded;
    float distToGround, dashCooldown = 0f;
    public float jumpForce = 2300f, dashForce = 800f, dashTimeout = 40f;
    public float wallClimbDistance = 2f, extraGravity = 20f;

    // wall jump variables
    bool nearWall = false;
    Vector3 wallDetectionDirection = Vector3.forward;
    bool pauseWallRaycast = false;

    // sword
    public GameObject sword;
    public float swordCooldownTime;
    float swordCooldownTimer;

    // sounds
    public AudioSource jumpSound;
    public AudioSource dashSound;

    // runs on start
    void Start()
    {
        physicsComponent = gameObject.GetComponent<Rigidbody>();
        distToGround = GetComponent<Collider>().bounds.extents.y;
        gameObject.name = "Player";
    }

    // runs once per frame
    void Update()
    {
        if (isLocalPlayer)
        {
            Movement();

            Jump();

            Dash();

            WallClimb();

            SwordSlash();
        }
    }

    void FixedUpdate()
    {
        FallSpeed();
    }

    void WallClimb()
    {
        if (!pauseWallRaycast)
            wallDetectionDirection = transform.forward;

        //print(wallDetectionDirection);
        //print(nearWall);
        nearWall = Physics.Raycast(transform.position, wallDetectionDirection, wallClimbDistance);

        // wall climb
        if (Input.GetButtonDown("Jump") && nearWall)
        {
            jumpSound.Play();
            StartCoroutine(WallClimbForce());
        }
    }

    IEnumerator WallClimbForce()
    {
        pauseWallRaycast = true;
        physicsComponent.AddForce(Vector3.up * jumpForce * speedScalar, ForceMode.Force);
        //physicsComponent.AddForce(-transform.forward * jumpForce * 2/3 * speedScalar, ForceMode.Force);
        yield return new WaitForSeconds(.15f);
        //physicsComponent.AddForce(-transform.forward * jumpForce * 2/3 * speedScalar, ForceMode.Force);
        pauseWallRaycast = false;
    }

    void Jump()
    {
        // check if grounded
        isGrounded = Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.5f);
        
        // add jump force on button press
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            jumpSound.Play();
            physicsComponent.AddForce(Vector3.up * jumpForce * speedScalar, ForceMode.Force);
        }
        else if (Input.GetButtonUp("Jump") && nearWall == false)
        {
            physicsComponent.AddForce(Vector3.down * (jumpForce / 5) * speedScalar, ForceMode.Force);
        }
    }

    void FallSpeed()
    {
        // increase fall speed
        if (physicsComponent.velocity.y < -0.1 && dashCooldown <= dashTimeout * 3/4)
        {
            physicsComponent.velocity += Vector3.up * Physics.gravity.y * extraGravity;
        }
    }

    void Dash()
    {
        dashCooldown--;

        if (Input.GetButtonDown("Dash") && dashCooldown <= 0)
        {
            dashSound.Play();
            physicsComponent.AddForce(new Vector3(physicsComponent.velocity.x * dashForce * speedScalar, 
                0f, physicsComponent.velocity.z * dashForce * speedScalar), ForceMode.Force);
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
            physicsComponent.AddForce(Vector3.right * moveSpeed * speedScalar * Time.deltaTime, ForceMode.Force);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            physicsComponent.AddForce(Vector3.left * moveSpeed * speedScalar * Time.deltaTime, ForceMode.Force);
        }

        // z axis
        if (Input.GetAxis("Vertical") > 0)
        {
            physicsComponent.AddForce(Vector3.forward * moveSpeed * speedScalar * Time.deltaTime, ForceMode.Force);
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            physicsComponent.AddForce(Vector3.back * moveSpeed * speedScalar * Time.deltaTime, ForceMode.Force);
        }

        // rotate player in movement direction
        if (new Vector3(physicsComponent.velocity.x, 0f, physicsComponent.velocity.z) != Vector3.zero && !nearWall)
        {
            transform.rotation = Quaternion.Slerp(gameObject.transform.rotation,
                Quaternion.LookRotation(new Vector3(physicsComponent.velocity.x, 0f, physicsComponent.velocity.z)), Time.deltaTime * rotLerp);
        }
    }

    void SwordSlash()
    {
        if (Input.GetButtonDown("Shoot") && swordCooldownTimer < 0f)
        {
            GameObject nextSpawn = Instantiate(sword, transform.position, sword.transform.rotation);
            NetworkServer.Spawn(nextSpawn);
            swordCooldownTimer = swordCooldownTime;
        }
        swordCooldownTimer -= Time.deltaTime;
    }

    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();
        gameObject.tag = "LocalPlayer";
    }
}
