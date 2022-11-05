using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    public string destroyTag;

    // destroy object if specified tag is detected on collision
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == destroyTag)
        {
            Destroy(gameObject);
        }
    }
}