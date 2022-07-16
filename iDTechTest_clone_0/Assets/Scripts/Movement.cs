using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Variables
    Vector3 movement; // holds the movement direction given by the player
    float forward, sideways; // holds the x and z axes of player input
    public float moveSpeed; // customizable move speed
    float jumpForce = 10f;

    // access the rigidbody component
    Rigidbody physicsComponent;

    void Start()
    {
        // set the rigidbody variable to the gameObject's component
        physicsComponent = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // get player movement input
        forward = Input.GetAxis("Horizontal");
        sideways = Input.GetAxis("Vertical");
        // holds the complete player movement values
        movement = new Vector3(forward, jumpForce, sideways);
        // sets the player movement equal to the input
        transform.position += movement * Time.deltaTime * moveSpeed;
        physicsComponent.velocity = movement * Time.deltaTime * moveSpeed;

        // if jump is pressed 
        if (Input.GetButtonDown("Jump"))
        {
            // add jump force
            //physicsComponent.AddForce(Vector3.up * jumpForce * Time.deltaTime);
            jumpForce = 15f;
        }
        else if (!Input.GetButton("Jump"))
        {
            jumpForce = 0f;
        }

    }
}