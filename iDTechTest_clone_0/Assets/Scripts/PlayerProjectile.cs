using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    Transform playerTransform;

    public float projectileSpeed, lifetime;
    public GameObject firePuddle;

    public Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
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
            Instantiate(nextSpawn);
            Destroy(gameObject);
        }
    }

    IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(lifetime);
        Destroy(gameObject);
    }
}
