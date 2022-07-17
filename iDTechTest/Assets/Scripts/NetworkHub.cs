using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using TMPro;

public class NetworkHub : NetworkBehaviour
{
    // variables
    public NetworkManager networkManager;
    public TMP_InputField lobbyNameInput;
    public GameObject networkingInterface;

    // Start is called before the first frame update
    void Start()
    {
        //networkManager = transform.parent.gameObject.GetComponent<NetworkManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // if escape is pressed, open exit networking menu
        // make exit networking menu have an option to leave a lobby
        // or to exit the game entirely
    }

    public void StartLobbyAsHost()
    {
        networkManager.StartHost();
        networkManager.networkAddress = lobbyNameInput.text;
        networkingInterface.SetActive(false);
    }

    public void StartLobbyAsClient()
    {
        networkManager.StartClient();
        networkManager.networkAddress = lobbyNameInput.text;
        networkingInterface.SetActive(false);
    }

    public void ExitLobby()
    {
        // check if user is host or client, then exit accordingly
        if (networkManager.mode == NetworkManagerMode.Host)
            networkManager.StopHost();
        else
            networkManager.StopClient();
    }
}
