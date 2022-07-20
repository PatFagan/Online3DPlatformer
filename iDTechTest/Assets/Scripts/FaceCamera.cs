using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    Transform camera;
    Vector3 faceDirection;

    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        faceDirection = transform.position - camera.position;
        transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, Quaternion.LookRotation(new Vector3(faceDirection.x, 0f, faceDirection.z)), Time.deltaTime * 40f);
    }
}