using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spawnedObject;
    public GameObject[] spawnedObjectArray;
    public float xMin, xMax, zMin, zMax;

    int numberOfSpawnedObjects = 0;

    bool spawningInProgress = false;

    IEnumerator Spawn()
    {
        spawningInProgress = true;
        for (int index = 0; index < spawnedObjectArray.Length; index++)
        {
            yield return new WaitForSeconds(.5f);
            Instantiate(spawnedObjectArray[index], new Vector3(Random.Range(xMin, xMax), Random.Range(0, 0), Random.Range(zMin, zMax)), spawnedObject.transform.rotation);
        }
        yield return new WaitForSeconds(2f);
        spawningInProgress = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawningInProgress == false)
        {
            StartCoroutine(Spawn());
        }
    }
}
