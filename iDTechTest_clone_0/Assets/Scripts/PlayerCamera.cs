using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerCamera : MonoBehaviour
{
    CinemachineVirtualCamera vCam;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        vCam = GetComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("LocalPlayer");

        if (player)
        {
            // print(player);
            vCam.Follow = player.transform;
            vCam.LookAt = player.transform;
        }
    }
}
