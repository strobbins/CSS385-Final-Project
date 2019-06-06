using UnityEngine;
using System.Collections;

[AddComponentMenu("Playground/Movement/Jump")]
[RequireComponent(typeof(Rigidbody2D))]
public class Jump : Physics2DObject
{	
	//[SerializeField] Animator animator;
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
			if (Physics2D.gravity.y == -9.81f) {// Gravity is pulling down, jump up
				rigidbody2D.AddForce (Vector2.up * jumpStrength, ForceMode2D.Impulse);
				FindObjectOfType<AudioManager>().Play("Player Jump"); // Plays the audio clip
			}
			if (Physics2D.gravity.y == 9.81f) {// Gravity is pulling up, jump down
				rigidbody2D.AddForce (Vector2.down * jumpStrength, ForceMode2D.Impulse);
				FindObjectOfType<AudioManager>().Play("Player Jump"); // Plays the audio clip
			}
			if (Physics2D.gravity.x == -9.81f) {// Gravity is pulling left, jump right
				rigidbody2D.AddForce (Vector2.right * jumpStrength, ForceMode2D.Impulse);
				FindObjectOfType<AudioManager>().Play("Player Jump"); // Plays the audio clip
			}
			if (Physics2D.gravity.x == 9.81f) {// Gravity is pulling right, jump left
				rigidbody2D.AddForce (Vector2.left * jumpStrength, ForceMode2D.Impulse);
				FindObjectOfType<AudioManager>().Play("Player Jump"); // Plays the audio clip
			}
			//animator.SetBool("IsJumping", true);
			canJump = !checkGround;
		}
	}

	private void OnCollisionEnter2D(Collision2D collisionData) {
		if(checkGround && collisionData.gameObject.CompareTag(groundTag)) {
			//animator.SetBool("IsJumping", false);
			canJump = true;
		}
	}
}