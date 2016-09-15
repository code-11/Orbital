using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

using UnityEngine;

public class PlayerController : NetworkBehaviour
{
	private GameObject planetPrefab;
	void Start(){
		planetPrefab = Resources.Load ("Prefabs/planet") as GameObject;
	}
	void Update()
	{
		if (!isLocalPlayer) {
			return;
		}

		var x = Input.GetAxis("Horizontal") * Time.deltaTime * 3.0f;
		var y = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

		transform.Translate(x, y, 0);

		if (Input.GetKeyDown (KeyCode.Space)) {
			CmdMakePlanet ();
		}
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
