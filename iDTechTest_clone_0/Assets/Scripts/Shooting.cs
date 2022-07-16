using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject projectile;

    // Update is called once per frame
    void Update()
    {
        // spawn projectiles on button press
        if (Input.GetButtonDown("Shoot"))
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
        }
    }
}