using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour {

	private Rigidbody2D rb;

	public string groundTag = "Ground";
	public bool checkGround = true;
	private bool canSwitchGrav = true;

	void Update() {
		if (canSwitchGrav && Input.GetKeyDown (KeyCode.LeftShift) && Physics2D.gravity.y == -9.81f) { // Gravity is pulling down
			Physics2D.gravity = new Vector2 (0f, 9.81f);
			canSwitchGrav = !checkGround;
			FindObjectOfType<AudioManager>().Play("Gravity Flip"); // Plays the audio clip
		} 
		if (canSwitchGrav && Input.GetKeyDown (KeyCode.LeftShift) && Physics2D.gravity.y == 9.81f) { // Gravity is pulling up
			Physics2D.gravity = new Vector2(0f, -9.81f);
			canSwitchGrav = !checkGround;
			FindObjectOfType<AudioManager>().Play("Gravity Flip"); // Plays the audio clip
		}
		if (canSwitchGrav && Input.GetKeyDown (KeyCode.LeftShift) && Physics2D.gravity.x == -9.81f) { // Gravity is pulling left
			Physics2D.gravity = new Vector2 (9.81f, 0f);
			canSwitchGrav = !checkGround;
			FindObjectOfType<AudioManager>().Play("Gravity Flip"); // Plays the audio clip
		} 
		if (canSwitchGrav && Input.GetKeyDown (KeyCode.LeftShift) && Physics2D.gravity.x == 9.81f) { // Gravity is pulling right
			Physics2D.gravity = new Vector2(-9.81f, 0f);
			canSwitchGrav = !checkGround;
			FindObjectOfType<AudioManager>().Play("Gravity Flip"); // Plays the audio clip
		}
		// These are for the orientation of the character sprite
		if (Physics2D.gravity.y == -9.81f)
			transform.eulerAngles = new Vector3 (0, 0, 0);
		if (Physics2D.gravity.y == 9.81f)
			transform.eulerAngles = new Vector3 (0, 0, 180);
		if (Physics2D.gravity.x == -9.81f)
			transform.eulerAngles = new Vector3 (0, 0, -90);
		if (Physics2D.gravity.x == 9.81f)
			transform.eulerAngles = new Vector3 (0, 0, 90);
	}

	private void OnCollisionEnter2D(Collision2D col)
	{
		if(checkGround && col.gameObject.CompareTag(groundTag)) {
			canSwitchGrav = true;
		}
	}
}
