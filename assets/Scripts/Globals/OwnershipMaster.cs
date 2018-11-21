using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwnershipMaster : MonoBehaviour {

	private Dictionary<PlayerController, HashSet<GameObject>> playerToObjs = new Dictionary<PlayerController, HashSet<GameObject>>();
	private Dictionary<GameObject,PlayerController> objToPlayer = new Dictionary<GameObject,PlayerController>();

	public void setOwnership(GameObject obj,PlayerController owner){
		Debug.Log("Setting ownership of "+obj+" to "+owner);

		//Make sure there is an inner set for the player in question first.
		HashSet<GameObject> playerObjs;
		if (playerToObjs.ContainsKey(owner)){
			playerObjs= playerToObjs[owner];
		}else{
			playerToObjs[owner] = new HashSet<GameObject>();
			playerObjs=playerToObjs[owner];
		}

		//Add object to the player
		playerObjs.Add(obj);

		//Add player to the object
		objToPlayer[obj]=owner;
	}

	public PlayerController getOwnership(GameObject obj){
		return objToPlayer[obj];
	}

	public HashSet<GameObject> getAllOwnedObjs(PlayerController player){
		return playerToObjs[player];
	}
}
