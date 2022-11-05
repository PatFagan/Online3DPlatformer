using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPathfinding : MonoBehaviour
{
    public NavMeshAgent ai; // gets the ai component
    GameObject player1; // player gameobject variable

    void Start()
    {
        player1 = GameObject.FindGameObjectWithTag("Player"); // find the player

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ai.SetDestination(player1.transform.position); // set the ai to chase the player
    }
}