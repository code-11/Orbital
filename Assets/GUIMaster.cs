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

	private GameObject getBuildOptionPanel(){
		return GameObject.FindWithTag("BuildOptionsPanel");
	}

	private List<GameObject> getBuildOptionSlots(){
		List<GameObject> buildOptionSlots= new List<GameObject>();
		foreach(Transform childSlot in getBuildOptionPanel().transform){
			buildOptionSlots.Add(childSlot.gameObject);
		}
		return buildOptionSlots;
	}

	public Text getSlotText(GameObject obj){
		return obj.transform.GetChild(0).gameObject.GetComponent<Text>();
	}

	public void fillBuildSlots(HashSet<Building> toBuild){
		List<GameObject> buildOptionSlots=getBuildOptionSlots();
		int i=0;
		foreach(Building possibleBuilding in toBuild){
			GameObject slot= buildOptionSlots[i];
			getSlotText(slot).text=possibleBuilding.ToString();
			i+=1;
		}
	}

	public void resetBuildSlots(){
		List<GameObject> buildOptionSlots=getBuildOptionSlots();
		foreach(GameObject slot in buildOptionSlots){
			getSlotText(slot).text="Slot";
		}
	}
}
