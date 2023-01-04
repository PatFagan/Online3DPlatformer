using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnDeath : MonoBehaviour
{
    HealthManager healthScript;
    public GameObject[] spawnedObjectArray;

    // Start is called before the first frame update
    void Start()
    {
        healthScript = GetComponent<HealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // if the object in question is dead
        if (healthScript.health <= 0f)
        {
            // picks a random object from the array
            int rand = Random.Range(0, spawnedObjectArray.Length);
            // and spawns it
            GameObject nextSpawn = Instantiate(spawnedObjectArray[rand], transform.position, spawnedObjectArray[rand].transform.rotation);
            Instantiate(nextSpawn);
            Destroy(gameObject);
        }
    }
}