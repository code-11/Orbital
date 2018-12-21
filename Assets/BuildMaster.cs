using System.Collections;
using System.Collections.Generic;
// using static Building;
using UnityEngine;




public class BuildMaster : MonoBehaviour {

	private Util.MultiMap<Building,Building> buildChain= new Util.MultiMap<Building,Building>();

	private void setupBuildChain (){
		buildChain.put(new Building.BasicInfrastructure(),new Building.MiningNetwork());
		buildChain.put(new Building.BasicInfrastructure(),new Building.SensorNetwork());
		buildChain.put(new Building.BasicInfrastructure(),new Building.InitialLaunchFacilities());

		buildChain.put(new Building.MiningNetwork(),new Building.AsteroidMiningFacility());
		buildChain.put(new Building.SensorNetwork(),new Building.SurviellanceSatilite());

		buildChain.put(new Building.InitialLaunchFacilities(),new Building.LaunchFacilities());
		buildChain.put(new Building.LaunchFacilities(),new Building.ColonyShipBerth());

		buildChain.put(new Building.LaunchFacilities(),new Building.AdvancedLaunchFacilities());
		buildChain.put(new Building.AdvancedLaunchFacilities(),new Building.AsteroidBoosterFactory());
		buildChain.put(new Building.AdvancedLaunchFacilities(),new Building.OrbitalSheild());

	}

	//Given this set of buildings, what new buildings can be built?
	public HashSet<Building> possibleNewBuildings(HashSet<Building> currentBuildings){
		HashSet<Building> toReturn= new HashSet<Building>();
		foreach(Building curBuild in currentBuildings){
			HashSet<Building> allowed = buildChain.getVal(curBuild);
			toReturn.UnionWith(allowed);
		}
		return toReturn;
	}
}
