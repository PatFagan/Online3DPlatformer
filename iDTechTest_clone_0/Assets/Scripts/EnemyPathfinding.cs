using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPathfinding : MonoBehaviour
{
    public NavMeshAgent ai; // gets the ai component
    GameObject player; // player gameobject variable

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player"); // find the player
        ai.SetDestination(player.transform.position); // set the ai to chase the player
    }
}