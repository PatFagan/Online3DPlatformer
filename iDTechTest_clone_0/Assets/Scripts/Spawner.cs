using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] spawnedObjectArray;
    public float xMin, xMax, zMin, zMax;

    bool spawningInProgress = false;
    bool spawnTriggered = false;

    LineRenderer line;
    void Start()
    {
        line = gameObject.GetComponent<LineRenderer>();
    }

    // start spawning
    IEnumerator Spawn()
    {
        spawningInProgress = true;
        yield return new WaitForSeconds(2f);
        // spawn one of each object from the array
        for (int index = 0; index < spawnedObjectArray.Length; index++)
        {
            yield return new WaitForSeconds(.5f);
            Instantiate(spawnedObjectArray[index]);
        }
        spawningInProgress = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawningInProgress == false && spawnTriggered == true)
        {
            StartCoroutine(Spawn());
            line.enabled = false;
        }

        if (!spawningInProgress)
        {
            line.enabled = true;
            GameObject player = GameObject.FindGameObjectWithTag("Player");

            if (player)
            {
                line.SetPosition(0, transform.position);
                line.SetPosition(1, player.transform.position);
            }
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        // starts spawning once a player enters the spawner

        // maybe change || to && so spawning requires both?
        if (collider.gameObject.tag == "Player" || collider.gameObject.tag == "LocalPlayer")
        {
            // int numOfConnectedPlayers = Network.connections.Length;
            spawnTriggered = true;
        }
    }
}