using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbiter : MonoBehaviour {

	public GameObject focus;
	private float angle;
	private float orbitRadius;
	public int speed=0;

	// Use this for initialization
	void Start () {
		if (focus!=null){
			float curX=transform.position.x;
			float curY=transform.position.y;
			Vector2 displacement=transform.position-focus.transform.position;
			orbitRadius=displacement.magnitude;
			angle = Mathf.Atan(displacement.y/displacement.x);
		}
	}
	
	// Update is called once per frame
	void Update () {
		float angleDelta = speed * Time.deltaTime; 
		angle+=angleDelta;
		float focusX = focus.transform.position.x;
		float focusY = focus.transform.position.y;
		float newX = focusX + orbitRadius * Mathf.Cos(angle);
		float newY = focusY + orbitRadius * Mathf.Sin(angle);
		transform.position = new Vector2(newX,newY);
	}
}
