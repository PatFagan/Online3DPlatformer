using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider)
    {
        // if a projectile hits the enemy
        if (collider.gameObject.tag == "PlayerProjectile")
        {
            print("enemy hit");
            Destroy(collider.gameObject);
        }
    }

}
