using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    TranslateMovement playerScript;

    public float projectileSpeed;

    public Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<TranslateMovement>();
        rigidbody.AddForce(projectileSpeed * playerScript.physicsComponent.velocity);
    }
}
