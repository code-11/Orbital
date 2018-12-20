using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class Util : Object {

	public static string[] splitCamelCase(string source) {
	    return Regex.Split(source, @"(?<!^)(?=[A-Z])");
	}

	public static string spaceOnCamel(string str){
		return string.Join(" ", splitCamelCase(str));
	}

	public class MultiMap<K,V> : Object{
		private Dictionary<K,HashSet<V>> data= new Dictionary<K,HashSet<V>>();

		public void put(K key, V value){
			if(data.ContainsKey(key)){
				data[key].Add(value);
			}else{
				HashSet<V> toAdd= new HashSet<V>();
				toAdd.Add(value);
				data[key]=toAdd;
			}
		}

		public HashSet<V> getVal(K key){
			if (data.ContainsKey(key)){
				return data[key];
			}else{
				return null;
			}
		}
	}

}
