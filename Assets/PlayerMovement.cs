using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	
	public float hspeed;
	public float vspeed;

	private Rigidbody rb;

	void Start ()
	{	
		hspeed = 5f;
		vspeed = 5f;
		rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, 1f);
		this.transform.Translate (moveHorizontal*hspeed*Time.deltaTime,0,vspeed*Time.deltaTime);
	}
}
