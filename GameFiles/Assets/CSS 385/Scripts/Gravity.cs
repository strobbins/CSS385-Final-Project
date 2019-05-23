using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour {

	private Rigidbody2D rb;
	private bool top; // For flipping the orientation of the character when gravity is flipped

	public string groundTag = "Ground";
	public bool checkGround = true;
	private bool canSwitchGrav = true;

	void Update() {
		if (canSwitchGrav && Input.GetKeyDown (KeyCode.LeftShift) && Physics2D.gravity.y == -9.81f) { // Gravity is pulling down
			Physics2D.gravity = new Vector2 (0f, 9.81f);
			Rotation (); // Calls rotation method
			canSwitchGrav = !checkGround;
			FindObjectOfType<AudioManager>().Play("Gravity Flip"); // Plays the audio clip
		} 
		if (canSwitchGrav && Input.GetKeyDown (KeyCode.LeftShift) && Physics2D.gravity.y == 9.81f) { // Gravity is pulling up
			Physics2D.gravity = new Vector2(0f, -9.81f);
			Rotation (); // Calls rotation method
			canSwitchGrav = !checkGround;
			FindObjectOfType<AudioManager>().Play("Gravity Flip"); // Plays the audio clip
		}
		if (canSwitchGrav && Input.GetKeyDown (KeyCode.LeftShift) && Physics2D.gravity.x == -9.81f) { // Gravity is pulling left
			Physics2D.gravity = new Vector2 (9.81f, 0f);
			Rotation (); // Calls rotation method
			canSwitchGrav = !checkGround;
			FindObjectOfType<AudioManager>().Play("Gravity Flip"); // Plays the audio clip
		} 
		if (canSwitchGrav && Input.GetKeyDown (KeyCode.LeftShift) && Physics2D.gravity.x == 9.81f) { // Gravity is pulling right
			Physics2D.gravity = new Vector2(-9.81f, 0f);
			Rotation (); // Calls rotation method
			canSwitchGrav = !checkGround;
			FindObjectOfType<AudioManager>().Play("Gravity Flip"); // Plays the audio clip
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
		} 
		else {
			transform.eulerAngles = Vector3.zero;
		}
		top = !top; // Sets it to the opposite of the initial value when function is called
	}
}
