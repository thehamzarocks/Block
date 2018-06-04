using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GMScript : MonoBehaviour {

	GameObject previousParticle;
	GameObject currentParticle;
	public GameObject particle;

	public GameObject wood;
	public GameObject coin;

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
		StartCoroutine (GenerateParticles ());
		StartCoroutine (GenerateWood ());
		//StartCoroutine (GenerateCoin ());
	}
	
	// Update is called once per frame
	void Update () {

		// gets the distance covered so far and updates the speed here and in the distancetext
		UpdateSpeed();
	}

	public float GetRandomNumber(float minimum, float maximum)
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

	IEnumerator GenerateParticles() {
		float xDistance;
		int dir;
		if (speed == 0) {
			speed = 5f;
		}

		float delay = 5 / speed;

		if (previousPos == -1000) {
			previousPos = 0;
			xDistance = 0;
			dir = 1;
		} else {
			xDistance = (float) GetRandomNumber (0, xVelocity * delay);
			dir = GetDirection ();
			currentPos = previousPos + dir * xDistance;
			if (currentPos > 9 || currentPos < -9) {
				dir *= -1;
			}
		}

		//padding
		if (xDistance > 8.5) {
			xDistance -= 1;
		}
		currentPos = previousPos + dir * xDistance;

		currentParticle = Instantiate (particle, new Vector3 (currentPos, 0.5f, 30), Quaternion.identity);
		//currentParticle.GetComponent<ParticleMovement> ().setSpeed (speed);
		yield return new WaitForSeconds (delay);
		previousPos = currentPos;
		StartCoroutine (GenerateParticles ());
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

	IEnumerator GenerateWood() {
		float xpos = GetRandomNumber (0f, 9f);
		int dir = GetDirection ();
		yield return new WaitForSeconds (5);
		Instantiate (wood, new Vector3 (xpos*dir, 0.5f, 30), Quaternion.identity);
		StartCoroutine (GenerateWood ());
	}

	IEnumerator GenerateCoin() {
		float xpos = GetRandomNumber (0f, 9f);
		int dir = GetDirection ();
		yield return new WaitForSeconds (3);
		Instantiate (coin, new Vector3 (xpos*dir, 0.5f, 30), Quaternion.identity);
		StartCoroutine (GenerateCoin ());
	}

	public float getCurrentPos() {
		return currentPos;
	}

	public float getPreviousPos() {
		return previousPos;
	}

}
