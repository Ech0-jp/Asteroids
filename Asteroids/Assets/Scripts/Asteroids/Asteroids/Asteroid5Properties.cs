using UnityEngine;
using System.Collections;

public class Asteroid5Properties : MonoBehaviour 
{
	public GameObject fullHeal;
	public GameObject partialHeal;
	private GameObject currentHeal;
	private int randomHeal;
	private bool spawnHeal;

	// Use this for initialization
	void Start () 
	{
		randomHeal = Random.Range(1, 101);

		if (50 > randomHeal || randomHeal > 55)
			spawnHeal = false;
		else 
			spawnHeal = true;
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

		Destroy(gameObject);
	}
}
