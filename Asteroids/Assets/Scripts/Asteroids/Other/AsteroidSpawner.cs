using UnityEngine;
using System.Collections;

public class AsteroidSpawner : MonoBehaviour 
{
	// ASTEROID VARIABLES

	// ASTEROID GAMEOBJECT VARIABLES
	public Transform AsteroidSocket;
	
	public GameObject Asteroid1;
	public GameObject Asteroid2;
	public GameObject Asteroid3;
	public GameObject Asteroid4;
	public GameObject Asteroid5;
	private GameObject currentAsteroid;

	// ASTEROID SPAWN LOCATION, ROTATION AND PROPERTIES VARIABLES
	public float asteroidSpeed;

	private float cameraPosY;

	public int spawnAsteroid;
	private int spawnSide;
	private float spawnRangeY;
	private float spawnRangeX;
	private float asteroidRotation;

	// ASTEROID SPAWN TIMER VARIABLES
	public float time;
	public float updateInterval;
	public float startInterval			= 0.1f;
	public float lastSI;
	public float lastInterval;
	private int x;
	private int y;

	public int replaceAsteroid			= 0;

	//ENEMY AI VARIABLES
	public GameObject enemy;

	public bool enemyCanSpawn 			= true;
	public float enemySpawnTimer		= 15.0f;
	private float resetEnemySpawnTimer;

	// Use this for initialization
	void Start () 
	{
		cameraPosY = Camera.main.transform.position.y;
		x = 0;

		y = Random.Range(3, 10);

		updateInterval = Random.Range(3, 12);

		resetEnemySpawnTimer = enemySpawnTimer;
	}
	
	// Update is called once per frame
	void Update () 
	{
		// ASTEROID SPAWN TIMER
		time += Time.deltaTime;

		if (time > updateInterval + lastInterval)
		{
			SpawnAsteroid();
			lastInterval = time;

			if (time <= 120.0f)
				updateInterval = Random.Range(3, 12);
			else if (time <= 240.0f)
				updateInterval = Random.Range(2, 9);
			else if (time <= 360.0f)
				updateInterval = Random.Range(1, 6);
			else if (time > 360.0f)
				updateInterval = Random.Range(1, 3);
		}

		if (time > startInterval + lastSI)
		{
			if (x < y)
			{
				SpawnAsteroid();
				lastSI = time;
				x++;
			}
		}

		// ENEMY SPAWN TIMER
		if (enemyCanSpawn)
			enemySpawnTimer -= Time.deltaTime;
		
		if (enemySpawnTimer < 0.0f)
		{
			SpawnEnemy();
			if (time <= 120.0f)
				enemySpawnTimer = Random.Range(resetEnemySpawnTimer, resetEnemySpawnTimer * 4);
			else if (time <= 240.0f)
				enemySpawnTimer = Random.Range(resetEnemySpawnTimer, resetEnemySpawnTimer * 3);
			else if (time <= 360.0f)
				enemySpawnTimer = Random.Range(resetEnemySpawnTimer, resetEnemySpawnTimer * 2);
			else if (time > 360.0f)
				enemySpawnTimer = resetEnemySpawnTimer;

			enemyCanSpawn = false;
		}
	}

	// SPAWN ASTEROID SEQUENCE
	void SpawnAsteroid()
	{
		// RANDOMIZE ASTEROID PROPERTIES, LOCATION, ROTATION
		Vector3 left 	= Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0));
		Vector3 right 	= Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
		Vector3 above 	= Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
		Vector3 below 	= Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 1));

		spawnSide = Random.Range(1, 5);
		spawnAsteroid = Random.Range(1, 6);
		int randomRotation = Random.Range(1, 5);

		asteroidSpeed = Random.Range(60, 100);

		switch(randomRotation)
		{
		case 1:
			asteroidRotation = Random.Range(22, 67);
			break;
		case 2:
			asteroidRotation = Random.Range(112, 156);
			break;
		case 3:
			asteroidRotation = Random.Range(-67, -22);
			break;
		case 4:
			asteroidRotation = Random.Range(-156, -112);
			break;
		}


		switch(spawnAsteroid)
		{
		case 1:
			currentAsteroid = Asteroid1;
			break;
		case 2:
			currentAsteroid = Asteroid2;
			break;
		case 3:
			currentAsteroid = Asteroid3;
			break;
		case 4:
			currentAsteroid = Asteroid4;
			break;
		case 5:
			currentAsteroid = Asteroid5;
			break;
		}

		// SPAWN ASTEROID
		GameObject cloneAsteroid;
		cloneAsteroid = (GameObject) Instantiate(currentAsteroid, AsteroidSocket.transform.position, transform.rotation);

		switch(spawnSide)
		{
		case 1:
			cloneAsteroid.transform.position = new Vector3(left.x - cameraPosY, 0, above.z + spawnRangeY);
			cloneAsteroid.transform.rotation = Quaternion.Euler(0, asteroidRotation, 0);
			cloneAsteroid.rigidbody.AddRelativeForce(asteroidSpeed, 0, asteroidSpeed);
			break;
		case 2:
			cloneAsteroid.transform.position = new Vector3(right.x + cameraPosY, 0, above.z + spawnRangeY);
			cloneAsteroid.transform.rotation = Quaternion.Euler(0, asteroidRotation, 0);
			cloneAsteroid.rigidbody.AddRelativeForce(asteroidSpeed, 0, asteroidSpeed);
			break;
		case 3:
			cloneAsteroid.transform.position = new Vector3(left.x + spawnRangeX, 0, below.z + (cameraPosY / 2));
			cloneAsteroid.transform.rotation = Quaternion.Euler(0, asteroidRotation, 0);
			cloneAsteroid.rigidbody.AddRelativeForce(asteroidSpeed, 0, asteroidSpeed);
			break;
		case 4:
			cloneAsteroid.transform.position = new Vector3(left.x + spawnRangeX, 0, below.z - (cameraPosY / 2));
			cloneAsteroid.transform.rotation = Quaternion.Euler(0, asteroidRotation, 0);
			cloneAsteroid.rigidbody.AddRelativeForce(asteroidSpeed, 0, asteroidSpeed);
			break;
		}
	}

	void SpawnEnemy()
	{
		Vector3 left 	= Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0));
		Vector3 right 	= Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
		Vector3 above 	= Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
		Vector3 below 	= Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 1));
		
		spawnSide = Random.Range(1, 5);

		GameObject cloneEnemy;
		cloneEnemy = (GameObject) Instantiate(enemy, AsteroidSocket.transform.position, transform.rotation);

		switch(spawnSide)
		{
		case 1:
			cloneEnemy.transform.position = new Vector3(left.x - cameraPosY, 0, above.z + spawnRangeY);
			break;
		case 2:
			cloneEnemy.transform.position = new Vector3(right.x + cameraPosY, 0, above.z + spawnRangeY);
			break;
		case 3:
			cloneEnemy.transform.position = new Vector3(left.x + spawnRangeX, 0, below.z + (cameraPosY / 2));
			break;
		case 4:
			cloneEnemy.transform.position = new Vector3(left.x + spawnRangeX, 0, below.z - (cameraPosY / 2));
			break;
		}
	}
}


















