using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject projectile;
    public PlayerAbilityTracker playerAbilitiesScript;

    // Update is called once per frame
    void Update()
    {
        // spawn projectiles on button press
        if (Input.GetButtonDown("Shoot"))
        {
            if (playerAbilitiesScript.abilities["Fireball"] == true)
                Instantiate(projectile, transform.position, Quaternion.identity);
        }
    }
}