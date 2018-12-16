﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Building : Object {


	public static List<Building> allBuildings= new List<Building>{
		new MiningNetwork(),
		new SensorNetwork(),
		new InitialLaunchFacilities(),
		new AsteroidMiningFacility(),
		new SurviellanceSatilite(),
		new LaunchFacilities(),
		new ColonyShipBerth(),
		new AdvancedLaunchFacilities(),
		new OrbitalSheild(),
		new AsteroidBoosterFactory()
	}

	public string toDisplayStringCached =""; 
	public string ToString(){
		if (!toDisplayStringCached.equals("")){
			return toDisplayStringCached;
		}else{
			string crushed=this.GetType().Name;
			return Util.spaceOnCamel(crushed);
		}
	}

	public class MiningNetwork : Building{}
	public class SensorNetwork : Building{}
	public class InitialLaunchFacilities : Building{}
	public class AsteroidMiningFacility : Building{}
	public class SurviellanceSatilite : Building{}
	public class LaunchFacilities : Building{}
	public class ColonyShipBerth : Building{}
	public class AdvancedLaunchFacilities : Building{}
	public class OrbitalSheild : Building{}
	public class AsteroidBoosterFactory : Building{}
}