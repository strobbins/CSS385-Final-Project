using UnityEngine;
using System.Collections;

[AddComponentMenu("Playground/Movement/Jump")]
[RequireComponent(typeof(Rigidbody2D))]
public class Jump : Physics2DObject
{	
	[Header("Jump setup")]
	// the key used to activate the push
	public KeyCode key = KeyCode.Space;

	// strength of the push
	public float jumpStrength = 10f;

	[Header("Ground setup")]
	//if the object collides with another object tagged as this, it can jump again
	public string groundTag = "Ground";

	//this determines if the script has to check for when the player touches the ground to enable him to jump again
	//if not, the player can jump even while in the air
	public bool checkGround = true;

	private bool canJump = true;

	// Read the input from the player
	void Update() {
		if(canJump && Input.GetKeyDown(key)) {
			// Apply an instantaneous force depending on direction of gravity
			if (Physics2D.gravity.y < 0) // Gravity is pulling down, jump up
				rigidbody2D.AddForce(Vector2.up * jumpStrength, ForceMode2D.Impulse);
			if (Physics2D.gravity.y > 0) // Gravity is pulling up, jump down
				rigidbody2D.AddForce(Vector2.down * jumpStrength, ForceMode2D.Impulse);
			if (Physics2D.gravity.x < 0) // Gravity is pulling left, jump right
				rigidbody2D.AddForce(Vector2.right * jumpStrength, ForceMode2D.Impulse);
			if (Physics2D.gravity.x > 0) // Gravity is pulling right, jump left
				rigidbody2D.AddForce(Vector2.left * jumpStrength, ForceMode2D.Impulse);
			canJump = !checkGround;
		}
	}

	private void OnCollisionEnter2D(Collision2D collisionData) {
		if(checkGround && collisionData.gameObject.CompareTag(groundTag)) {
			canJump = true;
		}
	}
}