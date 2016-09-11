using UnityEngine;
using System.Collections;

public class Shatterable : MonoBehaviour {
	private Rigidbody2D myBody;
	public int scale;
	private GameObject planetPrefab;
	private float velCutoff=8;
	MasterGravity theGravity;

	// Use this for initialization
	void Start () {
		planetPrefab = Resources.Load ("Prefabs/planet") as GameObject;
		Rigidbody2D body=GetComponent<Rigidbody2D> ();
		if (body != null) {
			myBody = body;
		} else {
			Debug.LogError ("shatterable must have a RigidBody2D");
		}
		theGravity = FindObjectOfType<MasterGravity> ();

	}
	void OnCollisionEnter2D(Collision2D coll) {
		if (scale>1) {

			//Collision of two circles is always one point
			ContactPoint2D firstContact = coll.contacts [0]; 
			Vector2 pos = firstContact.point;
			Vector2 normal = firstContact.normal;
			Vector2 pen1 = (new Vector2 (-normal.y, normal.x)).normalized;
			Vector2 pen2 = (new Vector2 (normal.y, -normal.x)).normalized;
			Rigidbody2D otherBody = coll.gameObject.GetComponent<Rigidbody2D> ();
			GameObject toShatter = null;
			Vector2 myVel = myBody.velocity;
			if (otherBody != null) {
				Vector2 otherVel = otherBody.velocity;

				if (myVel.sqrMagnitude > otherVel.sqrMagnitude) {
					toShatter = gameObject;
				}
			} else {
				toShatter = gameObject;
			}

			//Only one object involved in the collision should evaluate this
			if (toShatter != null && myVel.sqrMagnitude>velCutoff) {
				GameObject shard1 = (GameObject)Instantiate (planetPrefab, new Vector2 (pos.x, pos.y)+pen1/2, Quaternion.identity);
				theGravity.addGrav (shard1.GetComponent<Gravable> ());
				GameObject shard2 = (GameObject)Instantiate (planetPrefab, new Vector2 (pos.x, pos.y)+pen2/2, Quaternion.identity);
				theGravity.addGrav (shard2.GetComponent<Gravable> ());
				shard1.GetComponent<Gravable>().setInitalVelocity(pen1+myVel);
				shard2.GetComponent<Gravable>().setInitalVelocity(pen2+myVel);
				theGravity.removeGrav (gameObject.GetComponent<Gravable> ());
				Destroy (gameObject);
			}
		}
	}
}
