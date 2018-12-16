using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util : Object {

	public static string[] splitCamelCase(string source) {
	    return Regex.Split(source, @"(?<!^)(?=[A-Z])");
	}

	public static string spaceOnCamel(string str){
		return string.Join(" ", splitCamelCase(str));
	}

}
