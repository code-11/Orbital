using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class Util : object {

	public static string[] splitCamelCase(string source) {
	    return Regex.Split(source, @"(?<!^)(?=[A-Z])");
	}

	public static string spaceOnCamel(string str){
		return string.Join(" ", splitCamelCase(str));
	}

	public static string hashSetToString <K> (HashSet<K> theSet){
		string toReturn="";
		toReturn +="{";
		int i=0;
		foreach(K obj in theSet){
			toReturn += obj.ToString();
			i+=1;
			if(i<theSet.Count){
				toReturn +=", ";
			}
		}
		toReturn += "}";
		return toReturn;
	}

	public class MultiMap<K,V> : object{
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

		public HashSet<K> Keys(){
			HashSet<K> toReturn = new HashSet<K>();
			foreach(K key in data.Keys){
				toReturn.Add(key);
			}
			return toReturn;
		}

		public override string ToString(){
			string toReturn="{";
			int i=0;
			foreach(K key in data.Keys){
				toReturn += key + " : "+hashSetToString(this.getVal(key));
				i+=1;
				if (i<data.Keys.Count){
					toReturn += ", ";
				}

			}
			toReturn += "}";
			return toReturn;
		}

	}

}
