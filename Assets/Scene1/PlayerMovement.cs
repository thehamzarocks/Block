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
		// the 0.03f is to prevent the collision optimization and nullify the backward movement due to collisions
		float moveHorizontal = Input.GetAxis ("Horizontal");
		this.transform.Translate (moveHorizontal*hspeed*Time.deltaTime,0,0.03f*Time.deltaTime);

	}
}
