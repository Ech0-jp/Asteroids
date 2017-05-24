using UnityEngine;
using System.Collections;

public class PlayerProperties : MonoBehaviour 
{
	public GameObject bullet;

	public float bulletSpeed						= 700.0f;

	public Transform bulletSocket;

	public float timer;
	public float shootInterval						= 0.4f;
	public float lastShotInterval;

	public bool canTakeDamage						= true;
	public float invulnerabilityTimer				= 3.0f;
	private float resetInvulnerabilitytimer;
	public int health								= 4;
	public float DestroyWaitTime					= 0.2f;
	public GameObject explosion;

	public int playerScore							= 0;
	public bool hasPaused;

	GameObject gui;

	// Use this for initialization
	void Start () 
	{
		gui = GameObject.FindGameObjectWithTag("GUI");
		resetInvulnerabilitytimer = invulnerabilityTimer;

		audio.volume = PlayerPrefs.GetFloat("SFXVolume");
	}
	
	// Update is called once per frame
	void Update () 
	{
		timer = Time.realtimeSinceStartup;

		if (health > 4)
			health = 4;

		if (hasPaused)
			audio.volume = PlayerPrefs.GetFloat("SFXVolume");

		if (!canTakeDamage)
		{
			invulnerabilityTimer -= Time.deltaTime;
			if (invulnerabilityTimer <= 0.0f)
			{
				canTakeDamage = true;
				invulnerabilityTimer = resetInvulnerabilitytimer;
			}
			if (Input.GetKeyDown("Space"))
			{
				canTakeDamage = true;
				invulnerabilityTimer = resetInvulnerabilitytimer;
			}
		}

		// PLAYER BULLET TIMER AND SPAWNER
		if (Input.GetKey("space"))
		{
			if (timer > lastShotInterval + shootInterval)
			{
				GameObject cloneBullet;
				Vector3 fireBullet = transform.forward * bulletSpeed;
			
				cloneBullet = (GameObject) Instantiate(bullet, bulletSocket.transform.position, transform.rotation);
				cloneBullet.rigidbody.AddForce(fireBullet);

				lastShotInterval = timer + shootInterval;
			}
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Enemy")
		{
			other.gameObject.SendMessageUpwards("Damage");
			Damage();
		}
	}

	// PLAYER DAMAGE CONTROLLER
	void Damage()
	{
		GameObject cloneExplosion;

		if (canTakeDamage)
			health -= 1;

		if (health <= 0)
		{
			EndGame();
			Destroy(gameObject, DestroyWaitTime);
			cloneExplosion = (GameObject) Instantiate(explosion, transform.position, transform.rotation);
		}
	}

	// PLAYER SCORE CONTROLLER
	void AddScore(int score)
	{
		playerScore += score;
	}

	void EndGame()
	{
		GameOver gameOver = gui.GetComponent<GameOver>();

		gameOver.score = playerScore;
		gameOver.gameEnded = true;
	}
}













