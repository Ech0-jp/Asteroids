using UnityEngine;
using System.Collections;

public class HyperSpace : MonoBehaviour 
{
	private float cameraPosY;
	private float randomRangeX;
	private float randomRangeZ;

	public float startTimer					= 20.0f;
	public float timerInterval				= 40.0f;
	private float resetTimerInterval;

	public bool canHyperSpace				= false;
	private bool startTimerInterval			= false;

	GameObject playerGameObject;
	PlayerProperties playerProperties;

	// Use this for initialization
	void Start () 
	{
		cameraPosY = Camera.main.transform.position.y;
		resetTimerInterval = timerInterval;

		playerGameObject = GameObject.FindGameObjectWithTag("Player");
		playerProperties = playerGameObject.GetComponent<PlayerProperties>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		startTimer -= Time.deltaTime;
		if (startTimer <= 0.0f)
			canHyperSpace = true;

		if (startTimerInterval)
		{
			timerInterval -= Time.deltaTime;
			if (timerInterval <= 0.0f)
			{
				canHyperSpace = true;
				startTimerInterval = false;
				timerInterval = resetTimerInterval;
			}
		}

		if (canHyperSpace)
		{
			if (Input.GetKeyDown(KeyCode.F))
			{
				randomizeLocation();
				canHyperSpace = false;
				startTimerInterval = true;
			}
		}
	}

	void randomizeLocation()
	{
		Vector3 pos 	= Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));

		randomRangeX 	= Random.Range (-cameraPosY, cameraPosY);
		randomRangeZ 	= Random.Range (-(cameraPosY / 2), (cameraPosY / 2));

		transform.position = new Vector3(pos.x + randomRangeX, 0, pos.z + randomRangeZ);

		playerProperties.canTakeDamage = false;
	}
}













