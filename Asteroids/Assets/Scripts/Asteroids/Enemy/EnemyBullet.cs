using UnityEngine;
using System.Collections;

public class EnemyBullet : MonoBehaviour 
{
	public float lifeSpan			= 3.0f;
	
	public GameObject explosion;

	// Use this for initialization
	void Start () 
	{
		DestroyBullet();
		audio.volume = PlayerPrefs.GetFloat("SFXVolume");
	}

	void OnTriggerEnter(Collider other)
	{
		GameObject cloneExplosion;		
		
		if (other.tag == "Asteroid")
		{
			other.gameObject.SendMessage("Damage");
			
			cloneExplosion = (GameObject) Instantiate(explosion, transform.position, transform.rotation);
			Vector3 explosionPos = transform.position;
			
			Destroy(gameObject);
		}
		if (other.tag == "Player")
		{
			other.gameObject.SendMessage("Damage");

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
