using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class MasterGravity : NetworkBehaviour {

	private List<Gravable> allGravs= new List<Gravable>();
	private static Pair<Gravable,Gravable>[] gravCombos;
	public static readonly float G = 9; 

	public static T[] Concat<T>(T[] x, T[] y)
	{
		var z = new T[x.Length + y.Length];
		x.CopyTo(z, 0);
		y.CopyTo(z, x.Length);
		return z;
	}

	public void addGrav(Gravable newGrav){
		Pair<Gravable,Gravable>[] toAdd = new Pair<Gravable, Gravable>[allGravs.Count];
		for(int i=0; i<allGravs.Count; i+=1){
			if (allGravs [i] == newGrav) {
				Debug.Log ("Tried to an an already existing grav");
			}
				toAdd [i] = new Pair<Gravable,Gravable> (allGravs [i], newGrav);
		}
		allGravs.Add(newGrav);
		gravCombos = Concat (gravCombos, toAdd);
//		printGravs ("Add");
	}

	public void printGravs(string forward){
		string str2=forward+"[";
		foreach (Gravable grav  in allGravs) {
			str2+=grav.id+",";
		}
		str2+="]";
		string str=" [";
		foreach (Pair<Gravable,Gravable> curPair in gravCombos) {
			str+=curPair.ToString ();
		}
		str+="]";
		string str3 = "";
		if (allGravs.Count > 2) {
			str3 += (allGravs [0] == allGravs [2]).ToString();
		}
		Debug.Log (str2+" "+str3+" "+str);
	}

	public void removeGrav(Gravable toRemove){
//		printGravs ("remove1");
		allGravs.Remove(toRemove);
		List<Pair<Gravable,Gravable>> reorg = new List<Pair<Gravable, Gravable>> (gravCombos);
		foreach (var pair in reorg.ToList()) {
			if ((pair.First == toRemove) || (pair.Second == toRemove)) {
				reorg.Remove (pair);
			}
		}
		gravCombos=reorg.ToArray ();
//		printGravs("remove2");
	}

	// Use this for initialization
	void Start () {
		Debug.Log ("Starting");
		allGravs.AddRange( FindObjectsOfType<Gravable> ());
		gravCombos = (allGravs.Select((value, index) => new { value, index })
			.SelectMany(x => allGravs.Skip(x.index + 1),
				(x, y) => new Pair<Gravable,Gravable>(x.value, y))).ToArray();
	}

	void applyGravity(Gravable grav1,Gravable grav2){
		if (grav1 == grav2) {
			Debug.Log ("whaa");
		}
		Vector2 totalForce1=new Vector2(0,0);
		Vector2 totalForce2=new Vector2(0,0);

		Vector2 myPos = grav1.gameObject.transform.position;
		Vector2 otherPos = grav2.gameObject.transform.position;
		float otherMass = grav1.GetComponent<Rigidbody2D> ().mass;
		float myMass = grav2.GetComponent<Rigidbody2D> ().mass;
		Vector2 towards = (myPos-otherPos);
		float r3 = towards.sqrMagnitude * towards.magnitude;
		float gravMag = (G * otherMass * myMass / r3);
		totalForce1 += gravMag * -towards;
		totalForce2 += gravMag * towards;
		grav1.GetComponent<Rigidbody2D> ().AddForce (totalForce1);
		grav2.GetComponent<Rigidbody2D> ().AddForce (totalForce2);
	}
	// Update is called once per frame
	void FixedUpdate () {
//		printGravs ("fixed");
		foreach (Pair<Gravable,Gravable> curPair in gravCombos) {
			applyGravity (curPair.First, curPair.Second);
		}
	}

}
