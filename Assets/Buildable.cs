using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buildable : MonoBehaviour {

	private HashSet<Building> buildings = new HashSet<Building>();

	public void Start(){
		buildings.Add(new Building.BasicInfrastructure());
	}

	public void addBuilding(Building building){
		buildings.Add(building);
	}
}
