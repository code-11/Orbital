using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GUIMaster : MonoBehaviour {

	public Camera theCamera;
	public Text nameLbl;

	public void setName(string name){
		nameLbl.text=name;
	}

	public void centerOn(GameObject obj){
		theCamera.transform.parent = obj.transform; 
		float zCoord=theCamera.transform.position.z;
		theCamera.transform.localPosition= new Vector3(0,0,zCoord);
	}
}
