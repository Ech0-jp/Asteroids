using UnityEngine;
using System.Collections;

public class EnemyProperties : MonoBehaviour 
{
	public float shootInterval			= 3.0f;
	private float resetShootInterval;
	
	public GameObject bullet;
	public Transform bulletSocket;
	public float bulletSpeed			= 700.0f;

	private Vector3 relativePos;

	public int health					= 4;

	// SPARK EFFECTS UPON ENEMY DAMAGE
	public ParticleEmitter Damaged1;
	public ParticleEmitter Damaged2;
	public ParticleEmitter Damaged3;
	public GameObject explosion;

	private GameObject playerGameObject;
	private GameObject spawner;

	public GameObject FullHeal;
	public GameObject PartialHeal;
	private GameObject currentHeal;
	private int randomHeal;
	private bool canHeal;

	// Use this for initialization
	void Start () 
	{
		playerGameObject = GameObject.FindGameObjectWithTag("Player");
		spawner = GameObject.FindGameObjectWithTag("AsteroidSpawner");

		Damaged1.particleEmitter.emit = false;
		Damaged2.particleEmitter.emit = false;
		Damaged3.particleEmitter.emit = false;

		resetShootInterval = shootInterval;
	}
	
	// Update is called once per frame
	void Update () 
	{
		shootInterval -= Time.deltaTime;
		
		if (shootInterval < 0.0f)
		{
			FireBullet();
			shootInterval = resetShootInterval;
		}
		
		relativePos = playerGameObject.transform.position - transform.position;
	}

	void FireBullet()
	{
		GameObject cloneBullet;                               
		Vector3 fireBullet = transform.forward * bulletSpeed;
		Quaternion rotation = Quaternion.LookRotation(relativePos);
		
		cloneBullet = (GameObject) Instantiate(bullet, bulletSocket.position, rotation);
		cloneBullet.rigidbody.AddRelativeForce(fireBullet);
	}

	void Heal()
	{
		randomHeal = Random.Range(1, 101);

		if (randomHeal > 25)
			canHeal = false;
		else
			canHeal = true;

		if (canHeal)
		{
			if (randomHeal > 25)
				currentHeal = PartialHeal;
			else
				currentHeal = FullHeal;

			GameObject cloneHeal;
			cloneHeal = (GameObject) Instantiate(currentHeal, transform.position, transform.rotation);
		}
	}

	// ENEMY DAMAGE CONTROLLER
	void Damage()
	{
		health -= 1;

		if (health == 3)
		{
			Damaged1.particleEmitter.emit = true;
		}
		if (health == 2)
		{
			Damaged2.particleEmitter.emit = true;
		}
		if (health == 1)
		{
			Damaged3.particleEmitter.emit = true;
		}
		if (health <= 0)
		{
			AsteroidSpawner asteroidSpawner = spawner.GetComponent<AsteroidSpawner>();
			playerGameObject.SendMessage("AddScore", 500);
			asteroidSpawner.enemyCanSpawn = true;

			GameObject cloneExplosion;
			cloneExplosion = (GameObject) Instantiate(explosion, transform.position, transform.rotation);

			Heal();

			Destroy(gameObject);
		}
	}
}






















