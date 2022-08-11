using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject mesh;
    Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider)
    {
        // if a projectile hits the enemy
        if (collider.gameObject.tag == "PlayerProjectile")
        {
            Knockback();
            StartCoroutine(Flash());
        }
    }

    void Knockback()
    {
        rigidbody.AddForce(new Vector3(Random.Range(0,200f), Random.Range(0,200f), Random.Range(0,200f)));
    }

    IEnumerator Flash()
    {
        print("flash");  
        
        Material mat = mesh.GetComponent<Renderer>().material;

        mat.SetColor("_EmissionColor", Color.white);

        yield return new WaitForSeconds(.2f); 
        mat.SetColor("_EmissionColor", Color.red);
    }

}
