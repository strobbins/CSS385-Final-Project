using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour {

	private Rigidbody2D rb;
	private bool top; // For flipping the orientation of the character when gravity is flipped

	public string groundTag = "Ground";
	public bool checkGround = true;
	private bool canSwitchGrav = true;


	void Start() {
		rb = GetComponent<Rigidbody2D> (); // Initialize rigidbody
	}

	void Update() {
		if (canSwitchGrav && Input.GetKeyDown (KeyCode.LeftShift)) {
			rb.gravityScale *= -1;
			Rotation (); // Calls rotation method
			canSwitchGrav = !checkGround;
		}
	}

	private void OnCollisionEnter2D(Collision2D col)
	{
		if(checkGround && col.gameObject.CompareTag(groundTag)) {
			canSwitchGrav = true;
		}
	}

	void Rotation() { 
		if (top == false) { // If gravity is flipped, rotate 180 degrees
			transform.eulerAngles = new Vector3 (0, 0, 180);
		} else {
			transform.eulerAngles = Vector3.zero;
		}
		top = !top; // Sets it to the opposite of the initial value when function is called
	}
}
