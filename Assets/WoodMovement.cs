using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodMovement : MonoBehaviour {

	float speed;
	GMScript gmScript;
	GameObject player;
	// Use this for initialization
	void Start () {
		speed = 5f;
		player = GameObject.Find ("Player");
		gmScript = GameObject.Find ("GM").GetComponent<GMScript> ();
	}
	
	// Update is called once per frame
	void Update () {
		speed = gmScript.getSpeed ();
		transform.Translate (0, 0, -speed * Time.deltaTime);
		if (transform.position.z <= (player.transform.position.z - 0.5)) {
			Destroy (gameObject);
		}
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.name == "Player") {			
			gmScript.TriggerGameOver ();	
		}
	}
}
