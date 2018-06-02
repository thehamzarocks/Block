using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

	float xVelocity;

	float distance;
	GameObject DistanceText;
	float speed;

	GameObject GameOverPanel;
	bool gameOver;

	bool first = true;

	// Use this for initialization
	void Start () {

		GameOverPanel = GameObject.Find ("Canvas/GameOverPanel");
		GameOverPanel.SetActive (false);
		gameOver = false;

		previousPos = -1000;

		speed = 5f;
		distance = 0;
		DistanceText = GameObject.Find ("Canvas/Panel/DistanceText");


		initialPosition = new Vector3 (0, 0.5f, 20);
		initialRotation = new Quaternion (0, 0, 0, 0);


		xVelocity = 10f;

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
		float delay = 5 / speed;
		if (previousPos == -1000) {
			previousPos = 0;
			xDistance = 0;
			dir = 1;
		} else {
			xDistance = (float) GetRandomNumber (0, xVelocity * delay);
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
		yield return new WaitForSeconds (delay);
		StartCoroutine (Generate ());
	}

	void UpdateSpeed() {
		if (gameOver) {
			speed = 0;
			return;
		}

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
		if (distance > 1000) {
			speed = 15f;
		}

		DistanceText.GetComponent<DistanceTextScript> ().setSpeed (speed);
	}

	public float getSpeed() {
		return speed;
	}

	public void TriggerGameOver() {
		GameOverPanel.SetActive (true);
		gameOver = true;
		StartCoroutine (Restart ());
	}

	IEnumerator Restart() {
		yield return new WaitForSeconds (2);
		SceneManager.LoadScene ("scene1");
	}


}
