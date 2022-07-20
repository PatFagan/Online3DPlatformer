using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRevives : MonoBehaviour
{
    public HealthManager playerHealthScript;

    void OnTriggerEnter(Collider collider)
    {
        // revive if you are dead and another player collides w you
        if (collider.gameObject.tag == "Player" && playerHealthScript.health <= 0f)
        {
            playerHealthScript.health = playerHealthScript.maxHealth;
        }
    }
}