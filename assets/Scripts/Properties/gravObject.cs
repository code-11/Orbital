using UnityEngine;
using System.Collections;
using System;

public class gravObject : MonoBehaviour {

	public bool immobile;
	public float gravCutoff;
	private Rigidbody2D myBody{ get; set;}
	public static readonly float G = 7; 
	public Vector2 initialVelocity;
	//public bool autoLock;
	//private bool locked=false;

	public void setInitalVelocity(Vector2 vel){
		initialVelocity=vel;
	}

	// Use this for initialization
	void Start () {
		Rigidbody2D body=GetComponent<Rigidbody2D> ();
		if (body != null) {
			immobile = (body.constraints == RigidbodyConstraints2D.FreezePositionX && body.constraints == RigidbodyConstraints2D.FreezePositionY);
			myBody = body;
		} else {
			Debug.LogError ("gravObject must have a RigidBody2D");
		}

		myBody.velocity = initialVelocity;
	}
	
	// Update is called once per frame
	void Update () {
		evalAndApplyGravity ();
	}

	private Collider2D[] evalAndApplyGravity(){
		float x= gameObject.transform.position.x;
		float y = gameObject.transform.position.y;
		Collider2D[] allInRange= Physics2D.OverlapCircleAll (new Vector2(x,y), gravCutoff);
		Vector2 totalForce = new Vector2 (0, 0);
		foreach (Collider2D col in allInRange) {
			try{
			//Ignore yourself. No self acting gravity
			if (col.gameObject.GetInstanceID () != gameObject.GetInstanceID ()) {
				gravObject otherGrav = col.gameObject.GetComponent<gravObject> ();
				Vector2 myPos = gameObject.transform.position;
				Vector2 otherPos = col.gameObject.transform.position;
				//TODO: replace with mask at some point
				if (otherGrav != null) {
					float otherMass = otherGrav.myBody.mass;
					float myMass = myBody.mass;
					Vector2 towards = (otherPos-myPos);
					float r3 = towards.sqrMagnitude * towards.magnitude;
					float gravMag = (G * otherMass * myMass / r3);
					totalForce += gravMag * towards;
					//Debug.Log (totalForce);
				}
			}
			}catch(Exception e){
				continue;
			}
		}
		myBody.AddForce (totalForce);
		return allInRange;
	}		
}
