using UnityEngine;
using System.Collections;

public class Gravable : MonoBehaviour {
	public Vector2 initialVelocity;
	private Rigidbody2D myBody{ get; set;}
	public int id {get; set;}

	public void setInitalVelocity(Vector2 vel){
		initialVelocity=vel;
	}

	void Start () {
		id = gameObject.GetInstanceID ();
		Rigidbody2D body=GetComponent<Rigidbody2D> ();
		if (body != null) {
			myBody = body;
		} else {
			Debug.LogError ("gravObject must have a RigidBody2D");
		}
		myBody.velocity = initialVelocity;
	}

	public override string ToString(){
		return gameObject.name;
	}
}
