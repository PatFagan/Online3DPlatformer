using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPathfinding : MonoBehaviour
{
    public NavMeshAgent ai; // gets the ai component
    GameObject player1, player2, currentTarget; // player gameobject variable

    void Start()
    {
        player1 = GameObject.FindGameObjectWithTag("LocalPlayer"); // find the player
        player2 = GameObject.FindGameObjectWithTag("Player"); // find the player
        currentTarget = player1;

        if (player2)
            StartCoroutine(TargetSwap());
    }

    // Update is called once per frame
    void Update()
    {
        player1 = GameObject.FindGameObjectWithTag("LocalPlayer"); // find the player
        player2 = GameObject.FindGameObjectWithTag("Player"); // find the player
        ai.SetDestination(currentTarget.transform.position); // set the ai to chase the player
    }

    IEnumerator TargetSwap()
    {
        yield return new WaitForSeconds(3f);

        if (currentTarget == player1)
            currentTarget = player2;
        else if (currentTarget == player2)
            currentTarget = player1;

        print("swap");
        StartCoroutine(TargetSwap());
    }
}