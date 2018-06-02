using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMScript : MonoBehaviour {

	GameObject previousParticle;
	GameObject currentParticle;
	public GameObject particle;

	Vector3 initialPosition;
	Quaternion initialRotation;

	float previousTime;
	float currentTime;
	float previousPos;
	float currentPos;
	float delay;
	float zVelocity;
	float xVelocity;

	float distance;
	GameObject DistanceText;
	float speed;

	bool first = true;

	// Use this for initialization
	void Start () {

		previousPos = -1000;

		distance = 0;
		DistanceText = GameObject.Find ("Canvas/Panel/DistanceText");


		initialPosition = new Vector3 (0, 0.5f, 20);
		initialRotation = new Quaternion (0, 0, 0, 0);

		zVelocity = 6f;
		xVelocity = 5f;

		Random.InitState ((int)Time.time);
		StartCoroutine (Generate ());




	}
	
	// Update is called once per frame
	void Update () {

		// gets the distance covered so far and updates the speed here and in the distancetext
		UpdateSpeed();
	}

	public double GetRandomNumber(double minimum, double maximum)
	{ 
		
		return Random.value * (maximum - minimum) + minimum;
	}

	int GetDirection() {
		float val = (float) GetRandomNumber (0, 100);
		if (val < 50) {
			return -1;
		} else {
			return 1;
		}
	}

	IEnumerator Generate() {
		float xDistance;
		int dir;
		if (previousPos == -1000) {
			previousPos = 0;
			xDistance = 0;
			dir = 1;
		} else {
			xDistance = (float) GetRandomNumber (0, xVelocity * 1);
			dir = GetDirection ();
			currentPos = previousPos + dir * xDistance;
			if (currentPos > 9 || currentPos < -8) {
				dir *= -1;
			}
		}
		currentPos = previousPos + dir * xDistance;


		currentParticle = Instantiate (particle, new Vector3 (currentPos, 0.5f, 30), initialRotation);
		//currentParticle.GetComponent<ParticleMovement> ().setSpeed (speed);
		previousPos = currentPos;
		yield return new WaitForSeconds (1);
		StartCoroutine (Generate ());
	}

	void UpdateSpeed() {
		float distance = DistanceText.GetComponent<DistanceTextScript> ().getDistance ();

		/*if (distance < 50) {
			speed = 5f;
		} else if (distance < 100) {
			speed = 7f;
		} else if (distance < 200) {
			speed = 8f;
		} else if (distance < 300) {
			speed = 9f;
		} else if (distance < 400) {
			speed = 10f;
		} else if (distance < 700) {
			speed = 12f;
		}*/

		speed = (distance / 100) + 5;

		DistanceText.GetComponent<DistanceTextScript> ().setSpeed (speed);
	}

	public float getSpeed() {
		return speed;
	}


}
