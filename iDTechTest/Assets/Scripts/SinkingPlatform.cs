using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinkingPlatform : MonoBehaviour
{
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider collider)
    {
        // if player stands on platform, trigger sinking
        if (collider.gameObject.tag == "Player" || collider.gameObject.tag == "LocalPlayer")
        {
            animator.SetTrigger("Sinking");
            StartCoroutine(RisingPlatform()); // then start timer for rising again
        }
    }

    IEnumerator RisingPlatform()
    {
        yield return new WaitForSeconds(5f);
        animator.SetTrigger("Rising");
    }
}