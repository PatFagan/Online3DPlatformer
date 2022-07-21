using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Mirror;

public class PlayerHealth : NetworkBehaviour
{
    public int health, maxHealth;
    public string[] damageTag = { "tag", "tag", "tag", "tag" };

    float immunityTimer = 0f;

    public Image healthBar;

    TranslateMovement playerMovementScript;

    bool speedSet = false;

    void Start()
    {
        playerMovementScript = GetComponent<TranslateMovement>();

        if (!isLocalPlayer)
        {
            healthBar.fillAmount = 0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        immunityTimer -= Time.deltaTime;
        // print(immunityTimer);

        if (isLocalPlayer)
            HealthCheck();
    }

    void HealthCheck()
    {
        // update health bar if there is one
        if (healthBar)
            healthBar.fillAmount = health / 10f;

        // if dead
        if (health <= 0f)
        {
            playerMovementScript.speedScalar = .5f;
            speedSet = false;
        }
        else if (health > 0f && speedSet == false)
        {
            playerMovementScript.speedScalar = playerMovementScript.defaultSpeedScalar;
            speedSet = true;
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (isLocalPlayer)
        {
            if (immunityTimer < 0)
            {
                for (int index = 0; index < damageTag.Length; index++)
                {
                    if (collider.gameObject.tag == damageTag[index])
                    {
                        // take off health
                        health--;

                        // reset our immunity timer
                        immunityTimer = 1f;
                    }
                }
            }
        } 

    }
}
