using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMaster : MonoBehaviour {

	Util.MultiMap<Building,Building> buildChain= new Util.MultiMap<Building,Building>();

	//Given this set of buildings, what new buildings can be built?
	public HashSet<Building> possibleNewBuildings(HashSet<Building> currentBuildings){
		return null;
	}
}
