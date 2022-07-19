using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Spawner : NetworkBehaviour
{
    public GameObject spawnedObject;
    public GameObject[] spawnedObjectArray;
    public float xMin, xMax, zMin, zMax;

    int numberOfSpawnedObjects = 0;

    bool spawningInProgress = false;
    bool spawnTriggered = false;

    IEnumerator Spawn()
    {
        spawningInProgress = true;
        yield return new WaitForSeconds(2f);
        for (int index = 0; index < spawnedObjectArray.Length; index++)
        {
            yield return new WaitForSeconds(.5f);
            GameObject nextSpawn = Instantiate(spawnedObjectArray[index], new Vector3(Random.Range(xMin, xMax), Random.Range(0, 0), Random.Range(zMin, zMax)), spawnedObject.transform.rotation);
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
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        // maybe change || to && so spawning requires both?
        if (collider.gameObject.tag == "Player" || collider.gameObject.tag == "LocalPlayer")
        {
            // int numOfConnectedPlayers = Network.connections.Length;
            spawnTriggered = true;
        }
    }
}
