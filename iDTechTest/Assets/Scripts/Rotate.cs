using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float xRotation, yRotation, zRotation;

    // Update is called once per frame
    void Update()
    {
        // rotation
        gameObject.transform.Rotate(xRotation, yRotation, zRotation, Space.Self);
    }
}