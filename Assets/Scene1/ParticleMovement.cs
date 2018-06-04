using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleMovement : MonoBehaviour {

	float impactPosition;
	float speed;

	GMScript gmScript;

	// Use this for initialization
	void Awake () {
		speed = 5f;
		gmScript = GameObject.Find ("GM").GetComponent<GMScript> ();
	}
	
	// Update is called once per frame
	void Update () {
		checkWoodAhead ();
		checkWoodBetween ();
		speed = gmScript.getSpeed ();
		this.gameObject.transform.Translate(new Vector3(0,0,-speed*Time.deltaTime));
		if (this.transform.position.z <= (GameObject.Find("Player").transform.position.z-0.5f)) {			
			GameObject.Find ("GM").GetComponent<GMScript> ().TriggerGameOver ();
			Destroy (this.gameObject);
		}
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.name == "Player") {
			LightUp ();
			Destroy (this.gameObject);	
		}
	}

	void LightUp() {		
		GameObject lightGameObject = new GameObject("The Light");
		Light lightComp = lightGameObject.AddComponent<Light>();
		lightComp.color = Color.yellow;
		lightComp.intensity = 3;
		lightComp.areaSize = new Vector2 (7, 7);
		lightGameObject.transform.position = new Vector3(this.transform.position.x, 5, this.transform.position.z);
		Destroy (lightGameObject, 0.3f);
	}

	public void setSpeed(float s) {
		speed = s;
	}

	void checkWoodAhead() {
		RaycastHit hit;
		if(Physics.Raycast(transform.position, Vector3.back, out hit)) {
			GameObject[] WoodGameObjects = GameObject.FindGameObjectsWithTag ("Woods");
			Collider WoodCollider;
			for(int i=0; i<WoodGameObjects.Length; i++) {
				WoodCollider = WoodGameObjects [i].GetComponent<Collider> ();
				if (hit.collider == WoodCollider) {
					Destroy (this.gameObject);
				}
			}		
		}
	}

	void checkWoodBetween() {
		float currentPos = gmScript.getCurrentPos ();
		float previousPos = gmScript.getPreviousPos ();
		RaycastHit hit;
		Debug.DrawRay (transform.position, new Vector3(previousPos-currentPos,0,-5) * 3, Color.yellow);
		if(Physics.Raycast(transform.position, new Vector3(previousPos-currentPos,0,-5), out hit)) {
			GameObject[] WoodGameObjects = GameObject.FindGameObjectsWithTag ("Woods");
			Collider WoodCollider;
			for(int i=0; i<WoodGameObjects.Length; i++) {
				WoodCollider = WoodGameObjects [i].GetComponent<Collider> ();
				if (hit.collider == WoodCollider) {
					Destroy (this.gameObject);
				}
			}		
		}
	}


}
