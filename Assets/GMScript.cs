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

	bool first = true;

	// Use this for initialization
	void Start () {
		initialPosition = new Vector3 (0, 0.5f, 20);
		initialRotation = new Quaternion (0, 0, 0, 0);

		zVelocity = 6f;
		xVelocity = 5f;

		Random.InitState ((int)Time.time);
		StartCoroutine (Generate ());



	}
	
	// Update is called once per frame
	void Update () {
		
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
		if (previousPos == null) {
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


		Instantiate (particle, new Vector3 (currentPos, 0.5f, 10), initialRotation);
		previousPos = currentPos;
		yield return new WaitForSeconds (1);
		StartCoroutine (Generate ());
	}




}
