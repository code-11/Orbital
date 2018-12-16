using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buildable : MonoBehaviour {

	HashSet<Building> buildings = new HashSet<Building>();

	public void addBuilding(Building building){
		buildings.Add(building);
	}
}
