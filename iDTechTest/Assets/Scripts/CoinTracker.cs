using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CoinTracker : MonoBehaviour
{
    public TMP_Text coinScore; // gets the text box component

    public Image coinUI;

    int coinsCollected = 0; // creates the coin score

    void Start()
    {
        coinUI.fillAmount = 0f;
    }

    // runs when a trigger has been triggered
    void OnTriggerEnter(Collider collider)
    {
        // check if the collider is the coin
        if (collider.gameObject.tag == "Coin")
        {
            coinsCollected++; // add to the coin score
            coinScore.text = coinsCollected.ToString(); // change the coin ui text
            coinUI.fillAmount = coinsCollected / 10f;
            Destroy(collider.gameObject); // destroy the coin
        }
    }
}