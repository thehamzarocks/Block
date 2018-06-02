using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleMovement : MonoBehaviour {

	float impactPosition;
	float speed;

	// Use this for initialization
	void Awake () {
		speed = 5f;
	}
	
	// Update is called once per frame
	void Update () {
		speed = GameObject.Find ("GM").GetComponent<GMScript> ().getSpeed ();
		this.gameObject.transform.Translate(new Vector3(0,0,-speed*Time.deltaTime));
		if (this.transform.position.z <= (GameObject.Find("Player").transform.position.z)) {			
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


}
