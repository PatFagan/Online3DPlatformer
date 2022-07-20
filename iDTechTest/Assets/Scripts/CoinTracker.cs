using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Mirror;

public class CoinTracker : NetworkBehaviour
{
    public TMP_Text coinScore; // gets the text box component

    public Image coinUI;

    public int coinsCollected = 0; // creates the coin score
    int coinMax = 10;

    void Start()
    {
        coinUI.fillAmount = 0f;
    }

    void FixedUpdate()
    {
        coinScore.text = coinsCollected.ToString(); // change the coin ui text
        coinUI.fillAmount = coinsCollected / 10f;
    }

    // runs when a trigger has been triggered
    void OnTriggerEnter(Collider collider)
    {
        // check if the collider is the coin
        if (collider.gameObject.tag == "Coin" && coinsCollected < coinMax)
        {
            coinsCollected++; // add to the coin score
            NetworkServer.Destroy(collider.gameObject); // destroy the coin
        }
    }
}