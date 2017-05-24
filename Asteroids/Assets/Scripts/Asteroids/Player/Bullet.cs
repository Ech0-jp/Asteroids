using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour 
{
	public float lifeSpan			= 3.0f;

	public GameObject explosion;
	private GameObject playerGameObject;

	// Use this for initialization
	void Start () 
	{
		playerGameObject = GameObject.FindGameObjectWithTag("Player");
		DestroyBullet();
		audio.volume = PlayerPrefs.GetFloat("SFXVolume");
	}

	void OnTriggerEnter(Collider other)
	{
		GameObject cloneExplosion;

		if (other.tag == "Asteroid")
		{
			playerGameObject.SendMessage("AddScore", 100);

			other.gameObject.SendMessage("Damage");

			cloneExplosion = (GameObject) Instantiate(explosion, transform.position, transform.rotation);
			Vector3 explosionPos = transform.position;

			Destroy(gameObject);
		}
		if (other.tag == "Enemy")
		{
			other.gameObject.SendMessageUpwards("Damage");

			cloneExplosion = (GameObject) Instantiate(explosion, transform.position, transform.rotation);
			Vector3 explosionPos = transform.position;
			
			Destroy(gameObject);
		}
	}

	void DestroyBullet()
	{
		Destroy(gameObject, lifeSpan);
	}
}