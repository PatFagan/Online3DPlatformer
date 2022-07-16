using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthManager : MonoBehaviour
{
    public int health;
    public string[] damageTag = { "tag", "tag", "tag", "tag" };

    float timer = 0f;

    public TMP_Text healthText;
    public Image healthBar;

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        // print(timer);
    }

    void OnTriggerEnter(Collider collider)
    {
        // print("collided");

        if (timer < 0)
        {
            for (int index = 0; index < damageTag.Length; index++)
            {
                if (collider.gameObject.tag == damageTag[index])
                {
                    // print(index);
                    health--;
                    // print("health: " + health);
                    healthText.text = "Health: " + health;
                    healthBar.fillAmount = health / 10f;

                    // reset our immunity timer
                    timer = 1f;
                }
            }
        }

    }
}
