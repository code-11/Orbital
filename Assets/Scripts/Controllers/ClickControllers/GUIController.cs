using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIController : MonoBehaviour {
	GUIMaster master;

	// Use this for initialization
	void Start () {
		master=GameObject.FindObjectOfType<GUIMaster>();
	}
	
	void OnMouseDown(){
		GameObject me = gameObject;
		master.setName(me.name);
		master.centerOn(me);
		evalPossibleBuildings();
	}

	void evalPossibleBuildings(){
		Buildable buildable= gameObject.GetComponent<Buildable>();
		if (buildable!=null){
			master.fillBuildSlots(buildable.possibleBuildings());
		}else{
			Debug.Log(gameObject.name+" is not buildable");
		}
	}
}
