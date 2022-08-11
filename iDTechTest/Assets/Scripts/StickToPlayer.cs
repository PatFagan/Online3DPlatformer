using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickToPlayer : MonoBehaviour
{
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("LocalPlayer");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position;
    }
}
