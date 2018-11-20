using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class OrbitalNetworkMaster : NetworkManager {
	
	int clientNum=0;

	public void Start(){          
        Time.timeScale = 0.0f;  
	}

    public override void OnClientConnect(NetworkConnection connection)
    {
    	clientNum+=1;
        //Change the text to show the connection on the client side
        Debug.Log(" " + connection.connectionId + " Connected!");
        if(clientNum==1){
        	Time.timeScale = 1.0f;
        }
    }

    // public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
    // {
    //     GameObject player = (GameObject)Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
    //     NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
    // }
}
