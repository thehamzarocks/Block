using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMovement : MonoBehaviour {

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
			LightUp ();
		}
	}

	void LightUp() {		
		GameObject lightGameObject = new GameObject("The Light");
		Light lightComp = lightGameObject.AddComponent<Light>();
		lightComp.color = Color.white;
		lightComp.intensity = 3;
		lightComp.areaSize = new Vector2 (7, 7);
		lightGameObject.transform.position = new Vector3(this.transform.position.x, 5, this.transform.position.z);
		Destroy (lightGameObject, 0.3f);
	}
}
