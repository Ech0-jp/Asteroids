using UnityEngine;
using System.Collections;

public class PartialHeal : MonoBehaviour 
{
	private GameObject playerGameObject;
	public float timer = 15.0f;
	
	void Start()
	{
		playerGameObject = GameObject.FindGameObjectWithTag("Player");
		rigidbody.AddRelativeForce(15, 0, 15);
	}

	void Update()
	{
		timer -= Time.deltaTime;

		if (timer < 0.0f)
		{
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		PlayerProperties playerProperties = playerGameObject.GetComponent<PlayerProperties>();
		
		if (other.tag == "Player")
		{
			playerProperties.health += 1;
			Destroy(gameObject);
		}
	}
}
