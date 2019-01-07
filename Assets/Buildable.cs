using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buildable : MonoBehaviour {

	private HashSet<Building> buildings = new HashSet<Building>();
	private BuildMaster buildMaster = null;

	public void Start(){
		buildings.Add(new Building.BasicInfrastructure());
		buildMaster =GameObject.FindObjectOfType<BuildMaster>();
	}

	public void addBuilding(Building building){
		buildings.Add(building);
	}

	public HashSet<Building> possibleBuildings(){
		// return this.buildings;
		return buildMaster.possibleBuildings(this.buildings);
	}
}
