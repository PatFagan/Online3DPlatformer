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

    //public TMP_Text healthText;
    public Image healthBar;

    TranslateMovement playerMovementScript;

    void Start()
    {
        playerMovementScript = GetComponent<TranslateMovement>();
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
        // if dead
        if (health <= 0f)
        {
            playerMovementScript.speedScalar = 0.01f;
        }
        // if alive
        else if (health > 0f)
        {
            playerMovementScript.speedScalar = 3f;
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

                        // update health bar if there is one
                        if (healthBar)
                            healthBar.fillAmount = health / 10f;

                        // reset our immunity timer
                        immunityTimer = 1f;
                    }
                }
            }
        } 

    }
}
