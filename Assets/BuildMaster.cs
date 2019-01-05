using System.Collections;
using System.Collections.Generic;
// using static Building;
using UnityEngine;




public class BuildMaster : MonoBehaviour {

	private Util.MultiMap<Building,Building> buildChain= new Util.MultiMap<Building,Building>();

	private void setupBuildChain (){
						//This VV building is allowed if you have this one VV
		buildChain.put(new Building.MiningNetwork(),new Building.BasicInfrastructure());
		buildChain.put(new Building.SensorNetwork(),new Building.BasicInfrastructure());
		buildChain.put(new Building.InitialLaunchFacilities(),new Building.BasicInfrastructure());

		buildChain.put(new Building.AsteroidMiningFacility(),new Building.MiningNetwork());
		buildChain.put(new Building.SurviellanceSatilite(),new Building.SensorNetwork());

		buildChain.put(new Building.LaunchFacilities(),new Building.InitialLaunchFacilities());
		buildChain.put(new Building.ColonyShipBerth(),new Building.LaunchFacilities());

		buildChain.put(new Building.AdvancedLaunchFacilities(),new Building.LaunchFacilities());
		buildChain.put(new Building.AsteroidBoosterFactory(),new Building.AdvancedLaunchFacilities());
		buildChain.put(new Building.OrbitalSheild(),new Building.AdvancedLaunchFacilities());

	}

	//Given this set of buildings, what new buildings can be built?
	public HashSet<Building> possibleNewBuildings(HashSet<Building> currentBuildings){
		HashSet<Building> toReturn= new HashSet<Building>();
		foreach(Building possibleBuild in buildChain.Keys()){
			HashSet<Building> needBuildings=buildChain.getVal(possibleBuild);
			if (needBuildings.IsSubsetOf(currentBuildings)){
				toReturn.Add(possibleBuild);
			}
		}
		return toReturn;
	}
}
