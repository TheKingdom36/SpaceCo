using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vertex : MonoBehaviour {

	public string label;
	public bool isInTree;

	public Vertex(string lab){
		label = lab;
		isInTree = false;
	}
}
