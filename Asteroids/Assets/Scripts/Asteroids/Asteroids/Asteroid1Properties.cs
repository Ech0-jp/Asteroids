using UnityEngine;
using System.Collections;

public class Asteroid1Properties : MonoBehaviour 
{
	private int rng;
	private int spawnNum;
	private int randomRotation;
	private float asteroidRotation;
	private float asteroidSpeed;

	public GameObject Asteroid2;
	public GameObject Asteroid3;
	public GameObject Asteroid4;
	public GameObject Asteroid5;
	private GameObject setAsteroid;

	public GameObject fullHeal;
	public GameObject partialHeal;
	private GameObject currentHeal;
	private int randomHeal;
	private bool spawnHeal;

	// Use this for initialization
	void Start () 
	{
		PickAsteroid();

		randomHeal = Random.Range(1, 101);

		if (50 > randomHeal || randomHeal > 55)
			spawnHeal = false;
		else 
			spawnHeal = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void PickAsteroid()
	{
		rng = Random.Range(1, 101);

		if (rng > 60)
		{
			setAsteroid = Asteroid2;
			spawnNum = 1;
		}
		else if (60 > rng && rng >= 30)
		{
			setAsteroid = Asteroid3;
			spawnNum = 2;
		}
		else if (30 > rng && rng >= 10)
		{
			setAsteroid = Asteroid4;
			spawnNum = 4;
		}
		else 
		{
			setAsteroid = Asteroid5;
			spawnNum = 6;
		}

	}

	void Heal()
	{
		if (spawnHeal)
		{
			randomHeal = Random.Range(1, 101);
			if (50 > randomHeal || randomHeal > 55)
				currentHeal = partialHeal;
			else 
				currentHeal = fullHeal;

			GameObject cloneHeal;
			cloneHeal = (GameObject) Instantiate (currentHeal, transform.position, transform.rotation);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			other.gameObject.SendMessage("Damage");
		}

		if (other.tag == "Enemy") 
		{
			other.gameObject.SendMessageUpwards("Damage");
		}
	}

	void Damage()
	{
		GameObject cloneAsteroid;
		int x;

		for(x = 0; x < spawnNum; x++)
		{
			asteroidSpeed = Random.Range(60, 100);

			randomRotation = Random.Range(1, 5);
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

			cloneAsteroid = (GameObject) Instantiate(setAsteroid, transform.position, transform.rotation);
			cloneAsteroid.transform.rotation = Quaternion.Euler(0, asteroidRotation, 0);
			cloneAsteroid.rigidbody.AddRelativeForce(asteroidSpeed, 0, asteroidSpeed);
		}

		Heal();

		Destroy(gameObject);
	}
}














