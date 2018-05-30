using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleMovement : MonoBehaviour {

	int impactPosition;
	float speed;
	// Use this for initialization
	void Start () {
		speed = 2f;
		impactPosition = 2;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Translate(speed*Time.deltaTime,0,0);
		if (this.transform.position.x >= impactPosition) {
			Debug.Log ("Impact!");
			Destroy (this.gameObject);
		}
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.name == "Player") {
			Debug.Log ("Collided!");
			Destroy (this.gameObject, 0.3f);
		}
	}
}
