using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceTextScript : MonoBehaviour {



	// Use this for initialization
	void Start () {
		this.GetComponent<Text> ().text = "0 m";
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setDistanceText(float Distance) {
		this.GetComponent<Text> ().text = ((int)Distance).ToString() + " m";
	}
}
