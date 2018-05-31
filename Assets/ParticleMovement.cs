using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleMovement : MonoBehaviour {

	float impactPosition;
	float speed;

	// Use this for initialization
	void Start () {
		speed = 2f;
		impactPosition = -2.5f;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Translate(0,0,-speed*Time.deltaTime);
		if (this.transform.position.z <= impactPosition) {			
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
}
