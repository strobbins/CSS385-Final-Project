using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : Physics2DObject {

	[SerializeField] Animator animator;
	//[SerializeField] private GameObject player;

	public Enums.KeyGroups typeOfControl = Enums.KeyGroups.ArrowKeys;

	public float speed = 2f;
	public Enums.MovementType movementType = Enums.MovementType.AllDirections;

	public bool orientToDirection = false;
	// The direction that will face the player
	public Enums.Directions lookAxis = Enums.Directions.Up;

	private Vector2 movement, cachedDirection;
	private float moveHorizontal;
	private float moveVertical;
	private float maxVelocity = 25f;
	
	// Update is called once per frame
	void Update () {
		// Moving with the arrow keys
		if(typeOfControl == Enums.KeyGroups.ArrowKeys)
		{
			moveHorizontal = Input.GetAxis("Horizontal");
			moveVertical = Input.GetAxis("Vertical");
		}
		else
		{
			moveHorizontal = Input.GetAxis("Horizontal2");
			moveVertical = Input.GetAxis("Vertical2");
		}

		// Depending on orientation of gravity will affect which direction the character can move
		if (Physics2D.gravity.y == -9.81f || Physics2D.gravity.y == 9.81f) {
			moveVertical = 0f;
			animator.SetFloat ("Speed", Mathf.Abs(moveHorizontal));
		}
		if (Physics2D.gravity.x == -9.81f || Physics2D.gravity.x == 9.81f) {
			moveHorizontal = 0f;
			animator.SetFloat ("Speed", Mathf.Abs(moveVertical));
		}

		//zero-out the axes that are not needed, if the movement is constrained
		switch(movementType)
		{
		case Enums.MovementType.OnlyHorizontal:
			moveVertical = 0f;
			break;
		case Enums.MovementType.OnlyVertical:
			moveHorizontal = 0f;
			break;
		}

		movement = new Vector2(moveHorizontal, moveVertical);

		/*if(movement.sqrMagnitude >= 0.01f) // I THINK THIS IS ON THE RIGHT TRACK TO FIGURING THIS SHIT OUT *********************
		{
			transform.eulerAngles = new Vector2 (0, 180);
			//cachedDirection = movement;
		}
		if(movement.sqrMagnitude < 0.01f)
		{
			transform.eulerAngles = new Vector2 (0, 0);
			//cachedDirection = movement;
		}*/ // *********************************************************************************************************************
		//rotate the GameObject towards the direction of movement
		//the axis to look can be decided with the "axis" variable
		/*if(orientToDirection)
		{
			if(movement.sqrMagnitude >= 0.01f)
			{
				GameObject.transform.eulerAngles.x = 90;
				//cachedDirection = movement;
			}
			if(movement.sqrMagnitude < 0.01f)
			{
				GameObject.transform.eulerAngles.x = -90;
				//cachedDirection = movement;
			}
			//Utils.SetAxisTowards(lookAxis, transform, cachedDirection);
		}*/
	}

	// FixedUpdate is called every frame when the physics are calculated
	void FixedUpdate ()
	{
		if (rigidbody2D.velocity.sqrMagnitude < maxVelocity) {
			// Apply the force to the Rigidbody2d
			rigidbody2D.AddForce (movement * speed * 10f);
		}
	}
}
