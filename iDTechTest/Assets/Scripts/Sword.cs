using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.transform.parent.GetComponent<Animator>();

        int rand = Random.Range(0, 2);
        print(rand);
        if (rand == 1)
        {
            animator.SetBool("sword2", true);
        }
        else
        {            
            animator.SetBool("sword2", false);
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            StartCoroutine(PauseHit());
        }
    }

    IEnumerator PauseHit()
    {
        animator.enabled = false;
        yield return new WaitForSeconds(.1f);
        animator.enabled = true;
    }
}
