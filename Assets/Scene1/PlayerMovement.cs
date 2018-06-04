using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	
	public float hspeed;
	public float vspeed;

	private Rigidbody rb;

	void Start ()
	{	
		hspeed = 10f;
	}

	void FixedUpdate ()
	{
		// the 0.03f s to prevent the collision optimization and nullify the backward movement due to collisions
		MovePlayer();

	}

	void MovePlayer() {
		float moveHorizontal = 0;
		if (SystemInfo.deviceType == DeviceType.Desktop) {
			moveHorizontal = Input.GetAxis ("Horizontal");
		} else if (SystemInfo.deviceType == DeviceType.Handheld) {
			if (Input.touchCount > 0) {
				Touch touch = Input.GetTouch (0);
				if (touch.position.x > (Screen.width / 2)) {
					moveHorizontal = 1;
				}
				if (touch.position.x < (Screen.width / 2)) {
					moveHorizontal = -1;
				}
			}
		}

		this.transform.Translate (moveHorizontal*hspeed*Time.deltaTime,0,0.03f*Time.deltaTime);
	}

		
}
