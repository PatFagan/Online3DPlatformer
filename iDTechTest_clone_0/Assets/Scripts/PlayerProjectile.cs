using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerProjectile : NetworkBehaviour
{
    Transform playerTransform;

    public float projectileSpeed, lifetime;
    public GameObject firePuddle;

    public Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("LocalPlayer").GetComponent<Transform>();
        rigidbody.AddForce(projectileSpeed * Vector3.up);
        rigidbody.AddForce(projectileSpeed * playerTransform.forward);
        StartCoroutine(DestroyAfterTime());
    }

    void Update()
    {
        // subtle tracking
        if (GameObject.FindGameObjectWithTag("Enemy"))
            transform.position = Vector3.MoveTowards(transform.position, GameObject.FindGameObjectWithTag("Enemy").GetComponent<Transform>().position, .02f);
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Ground")
        {
            GameObject nextSpawn = Instantiate(firePuddle, transform.position, Quaternion.identity);
            NetworkServer.Spawn(nextSpawn);
            NetworkServer.Destroy(gameObject);
        }
    }

    IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(lifetime);
        NetworkServer.Destroy(gameObject);
    }
}
