using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthManager : MonoBehaviour
{
    public int health, maxHealth;
    public string[] damageTag = { "tag", "tag", "tag", "tag" };
    public bool destroyOnDeath;

    float timer = 0f;

    //public TMP_Text healthText;
    public Image healthBar;

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        // print(timer);

        HealthCheck();
    }

    void HealthCheck()
    {
        // if dead
        if (health <= 0f)
        {
            // if enemy, etc. destroy
            if (destroyOnDeath)
            {
                StartCoroutine(Die());
            }
        }
    }

    IEnumerator Die()
    {
        yield return new WaitForSeconds(.1f);
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider collider)
    {
        if (timer < 0)
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
                    timer = 1f;
                }
            }
        }

    }
}
