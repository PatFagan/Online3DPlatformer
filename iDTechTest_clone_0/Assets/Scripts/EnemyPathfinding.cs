using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Mirror;

public class EnemyPathfinding : NetworkBehaviour
{
    public NavMeshAgent ai; // gets the ai component
    GameObject player1, player2, currentTarget; // player gameobject variable

    void Start()
    {
        player1 = GameObject.FindGameObjectWithTag("LocalPlayer"); // find the player
        player2 = GameObject.FindGameObjectWithTag("Player"); // find the player

        int rand = Random.Range(0,2);
        print(rand);

        // choose to chase player 1 or player 2
        switch (rand) 
        {
            case 0:
                if (player2)
                    currentTarget = player2;
                else
                    currentTarget = player1;
                break;
            default:
                currentTarget = player1;
                break;
        }

        /*
        if (player2)
            StartCoroutine(TargetSwap());
        */
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*
        if (currentTarget)
            ai.SetDestination(currentTarget.transform.position); // set the ai to chase the player
        */

        ai.SetDestination(player1.transform.position); // set the ai to chase the player
    }

    IEnumerator TargetSwap()
    {
        yield return new WaitForSeconds(3f);

        if (currentTarget == player1)
            currentTarget = player2;
        else if (currentTarget == player2)
            currentTarget = player1;

        print("swap"); 
        
        if (player1 || player2)
            StartCoroutine(TargetSwap());
    }
}