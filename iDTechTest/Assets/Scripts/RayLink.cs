using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayLink : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LineRenderer line = gameObject.GetComponent<LineRenderer>();
        GameObject player = GameObject.FindGameObjectWithTag("LocalPlayer");
 
        if (player)
        {
            line.SetPosition(0, transform.position);
            line.SetPosition(1, player.transform.position);
        }
        //Debug.DrawRay(transform.position, player.transform.position, Color.red, 10.0f);
    }
}
