using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public float health, maxHealth;
    public string[] damageTag = { "tag", "tag", "tag", "tag" };
    public string[] dotDamageTag = { "tag", "tag", "tag", "tag" };
    bool checkDot = false;

    float immunityTimer = 0f;

    public Image healthBar;

    TranslateMovement playerMovementScript;

    bool speedSet = false;

    void Start()
    {
        playerMovementScript = GetComponent<TranslateMovement>();

        healthBar.fillAmount = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        immunityTimer -= Time.deltaTime;
        // print(immunityTimer);

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

            for (int index = 0; index < dotDamageTag.Length; index++)
            {
                if (collider.gameObject.tag == dotDamageTag[index])
                {
                    checkDot = true;
                    StartCoroutine(DamageOverTime());
                }
            }
        }
    }

    void OnTriggerExit(Collider collider)
    {
        for (int index = 0; index < dotDamageTag.Length; index++)
        {
            if (collider.gameObject.tag == dotDamageTag[index])
            {
                checkDot = false;
            }
        }
    }

    IEnumerator DamageOverTime()
    {
        // take off health
        health -= .25f;

        // reset our immunity timer
        immunityTimer = 1f;

        yield return new WaitForSeconds(immunityTimer);

        if (checkDot)
            StartCoroutine(DamageOverTime());
    }
}
