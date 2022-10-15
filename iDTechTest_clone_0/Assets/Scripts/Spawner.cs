using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Spawner : NetworkBehaviour
{
    public GameObject[] spawnedObjectArray;
    public float xMin, xMax, zMin, zMax;

    int numberOfSpawnedObjects = 0;

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
            GameObject nextSpawn = Instantiate(spawnedObjectArray[index], new Vector3(Random.Range(xMin, xMax), Random.Range(0, 0), Random.Range(zMin, zMax)), spawnedObjectArray[index].transform.rotation);
            NetworkServer.Spawn(nextSpawn);
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
            GameObject player = GameObject.FindGameObjectWithTag("LocalPlayer");

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
