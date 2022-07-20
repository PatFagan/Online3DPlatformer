using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class DestroyOnCollision : NetworkBehaviour
{
    public string destroyTag;

    // destroy object if specified tag is detected on collision
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == destroyTag)
        {
            NetworkServer.Destroy(gameObject);
        }
    }
}