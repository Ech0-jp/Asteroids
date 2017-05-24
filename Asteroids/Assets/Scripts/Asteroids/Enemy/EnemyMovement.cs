using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour 
{
	public float aiSpeed							= 80.0f;

	public float aiMovementTimer					= 15.0f;
	private float resetAiMovementTimer;

	private int verticleMovement; // 0 = no movement // 1 = down // 2 = up
	private int horizontalMovement; // 0 = no mevement // 1 = left // 2 = right

	// Use this for initialization
	void Start () 
	{
		resetAiMovementTimer = aiMovementTimer;
		aiMovement();
	}
	
	// Update is called once per frame
	void Update () 
	{
		aiMovementTimer -= Time.deltaTime;

		if (aiMovementTimer <= 0.0f)
		{
			aiMovement();
			aiMovementTimer = resetAiMovementTimer;
		}
	}

	void aiMovement()
	{
		int verticleDirection = Random.Range(1, 100); // 1-33 down || 33 - 66 don't move || 66 - 99 up
		int horizontalDirection = Random.Range(1, 100); // 1-33 left || 33 - 66 don't move || 66 - 99 right

		// AI VERTICAL MOVEMENT

		// MOVE DOWN
		if (verticleDirection < 33)
		{
			if (verticleMovement != 1)
			{
				if (verticleMovement != 2)
					rigidbody.AddRelativeForce(0, 0, -aiSpeed);
				else 
					rigidbody.AddRelativeForce(0, 0, -aiSpeed * 2);
			}

			verticleMovement = 1;
		}
		// DONT MOVE
		else if (verticleDirection < 66)
		{
			switch (verticleMovement)
			{
			case 1:
				rigidbody.AddRelativeForce(0, 0, aiSpeed);
				break;
			case 2:
				rigidbody.AddRelativeForce(0, 0, -aiSpeed);
				break;
			}

			verticleMovement = 0;
		}
		// MOVE UP
		else if (verticleDirection < 99)
		{
			if (verticleMovement != 2)
			{
				if (verticleMovement != 1)
					rigidbody.AddRelativeForce(0, 0, aiSpeed);
				else
					rigidbody.AddRelativeForce(0, 0, aiSpeed * 2);
			}

			verticleMovement = 2;
		}

		// AI HORIZONTAL MOVEMENT

		// MOVE LEFT
		if (horizontalDirection < 33)
		{
			if (horizontalMovement != 1)
			{
				if (horizontalMovement != 2)
					rigidbody.AddRelativeForce(-aiSpeed, 0, 0);
				else 
					rigidbody.AddRelativeForce(-aiSpeed * 2, 0, 0);
			}

			horizontalMovement = 1;
		}
		// DONT MOVE
		else if (horizontalDirection < 66)
		{
			switch (horizontalMovement)
			{
			case 1:
				rigidbody.AddRelativeForce(aiSpeed, 0, 0);
				break;
			case 2:
				rigidbody.AddRelativeForce(-aiSpeed, 0, 0);
				break;
			}

			horizontalMovement = 0;
		}
		// MOVE RIGHT
		else if (horizontalDirection < 99)
		{
			if (horizontalMovement != 2)
			{
				if (horizontalMovement != 1)
					rigidbody.AddRelativeForce(aiSpeed, 0, 0);
				else 
					rigidbody.AddRelativeForce(aiSpeed * 2, 0, 0);
			}

			horizontalMovement = 2;
		}

		// IF ITS NOT MOVING IN BOTH HORIZONTAL AND VERTICAL RERUN
		if (verticleMovement == 0 && horizontalMovement == 0)
		{
			aiMovement();
		}
	}

	// ASTEROID EVASION
	void OnTriggerEnter(Collider other)
	{
		int evade = Random.Range(1, 101);

		if (other.tag == "Asteroid")
		{
			// IF "EVADE" IS BETWEEN 33 AND 66 (33% CHANCE) DO NOT EVADE
			if (40 > evade && evade > 50)
			{
				Vector3 asteroidPos = other.transform.position;
				Vector3 aiPosition	= transform.position;

				// ASTEROID IS LEFT
				if (asteroidPos.x < aiPosition.x)
				{
					if (horizontalMovement != 2)
					{
						if (horizontalMovement != 1)
							rigidbody.AddRelativeForce(aiSpeed, 0, 0);
						else 
							rigidbody.AddRelativeForce(aiSpeed * 2, 0, 0);
						horizontalMovement = 2;
					}
				}
				//ASTEROID IS RIGHT
				if (aiPosition.x < asteroidPos.x)
				{
					if (horizontalMovement != 1)
					{
						if (horizontalMovement != 2)
							rigidbody.AddRelativeForce(-aiSpeed, 0, 0);
						else 
							rigidbody.AddRelativeForce(-aiSpeed * 2, 0, 0);
						horizontalMovement = 1;
					}
				}
				//ASTEROID IS ABOVE
				if (asteroidPos.z < aiPosition.z)
				{
					if (verticleMovement != 2)
					{
						if (verticleMovement != 1)
							rigidbody.AddRelativeForce(0, 0, aiSpeed);
						else 
							rigidbody.AddRelativeForce(0, 0, aiSpeed * 2);
						verticleMovement = 2;
					}
				}
				//ASTEROID IS BELOW
				if (aiPosition.z < asteroidPos.z)
				{
					if (verticleMovement != 1)
					{
						if (verticleMovement != 2)
							rigidbody.AddRelativeForce(0, 0, -aiSpeed);
						else
							rigidbody.AddRelativeForce(0, 0, -aiSpeed * 2);
						verticleMovement = 1;
					}
				}
			}
		}
	}
}



















