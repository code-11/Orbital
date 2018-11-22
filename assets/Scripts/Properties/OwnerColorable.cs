using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwnerColorable : MonoBehaviour {

	private OwnershipMaster ownership;

	bool colorSet=false;

	Color color= Color.white;

	// Use this for initialization
	void Start () {
		ownership=GameObject.FindObjectOfType<OwnershipMaster>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!colorSet){
			PlayerController owner=ownership.getOwnership(gameObject);
			if(owner!=null){
				color=owner.getColor();
				Debug.Log("Color not set for "+gameObject.name+ " setting to "+color);
			}
			colorSet=true;

			SpriteRenderer renderer=gameObject.GetComponent<SpriteRenderer>();

			if(renderer!=null){
				renderer.color=color;	
			}
		}
	}
}
