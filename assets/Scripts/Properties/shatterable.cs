using UnityEngine;
using System.Collections;

public class shatterable : MonoBehaviour {
	private Rigidbody2D myBody;
	int scale;
	// Use this for initialization
	void Start () {
		Rigidbody2D body=GetComponent<Rigidbody2D> ();
		if (body != null) {
			myBody = body;
		} else {
			Debug.LogError ("shatterable must have a RigidBody2D");
		}

	}
	
	// Update is called once per frame
	void Update () {

	}
	void OnCollisionEnter2D(Collision2D coll) {
		Rigidbody2D otherBody = coll.gameObject.GetComponent<Rigidbody2D> ();
		GameObject toShatter=null;
		if (otherBody != null) {
			Vector2 otherVel = otherBody.velocity;
			Vector2 myVel = myBody.velocity;
			if (myVel.sqrMagnitude > otherVel.sqrMagnitude) {
				toShatter = gameObject;
			}
		} else {
			toShatter = gameObject;
		}

		if (toShatter != null) {
			Debug.Log (toShatter.name);
		}
	}
}
