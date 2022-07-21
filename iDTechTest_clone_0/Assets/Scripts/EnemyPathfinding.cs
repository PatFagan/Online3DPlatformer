using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Mirror;

public class EnemyPathfinding : NetworkBehaviour
{
    public NavMeshAgent ai; // gets the ai component
    GameObject player1; // player gameobject variable

    // Update is called once per frame
    void Update()
    {
        player1 = GameObject.FindGameObjectWithTag("LocalPlayer"); // find the player

        if (player1)
            ai.SetDestination(player1.transform.position); // set the ai to chase the player
    }
}