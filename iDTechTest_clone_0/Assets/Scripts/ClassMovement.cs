using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassMovement : MonoBehaviour
{
    Vector3 direction;
    public float speed;
    float xForce, zForce;

    // Update is called once per frame
    void Update()
    {
        // get axis forces
        xForce = Input.GetAxis("Horizontal");
        zForce = Input.GetAxis("Vertical");

        // add axis forces to the vector
        direction = new Vector3(xForce, 0f, zForce);

        // adds force to the object
        transform.Translate(direction * speed * Time.deltaTime);

    }
}