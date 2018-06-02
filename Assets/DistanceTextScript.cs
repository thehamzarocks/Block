using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceTextScript : MonoBehaviour {

	float distance;
	float speed;
	Text DistanceText;

	// Use this for initialization
	void Start () {
		distance = 0;
		speed = 5f;
		DistanceText = this.GetComponent<Text> ();
		DistanceText.text = distance.ToString() + " m";
	}
	
	// Update is called once per frame
	void Update () {
		updateDistance ();
		setDistanceText ();
	}

	public void setDistanceText() {
		DistanceText.text = ((int)distance).ToString() + " m";
	}

	public float getDistance() {
		return distance;
	}

	public void updateDistance() {
		distance += speed * Time.deltaTime;
	}

	public void setSpeed(float s) {
		speed = s;
	}
}
