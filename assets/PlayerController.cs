using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : NetworkBehaviour
{
	private GameObject planetPrefab;
	private OwnershipMaster ownership;

	void Start(){
		Debug.Log("Starting Player "+this);
		ownership=GameObject.FindObjectOfType<OwnershipMaster>();

		planetPrefab = Resources.Load ("Prefabs/planet") as GameObject;
		GameObject startPlanet=GameObject.FindWithTag("StartPlanet");
		ownership.setOwnership(startPlanet,this);
	}

	void Update()
	{
		if (!isLocalPlayer) {
			return;
		}

		var x = Input.GetAxis("Horizontal") * Time.deltaTime * 3.0f;
		var y = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

		transform.Translate(x, y, 0);

		/*
		if (Input.GetKeyDown (KeyCode.Space)) {
			CmdMakePlanet ();
		}
		*/
	}
	[Command]
	public void CmdMakePlanet(){
		var planet = (GameObject)Instantiate (
			            planetPrefab,
			            gameObject.transform.position,
			            Quaternion.identity);
		NetworkServer.Spawn (planet);
	}
	public override void OnStartLocalPlayer()
	{
		GetComponent<SpriteRenderer>().material.color = Color.blue;
	}
}
