using UnityEngine;
using System.Collections;

public class AsteroidScreenWrap : MonoBehaviour 
{
	public float cameraPosY;
	
	public float timer;
	public int wrapCount;
	
	public float timerReset 		= 5.0f;
	public int wrapDestroy			= 10;
	
	
	// Use this for initialization
	void Start () 
	{
		cameraPosY = Camera.main.transform.position.y;
	}
	
	// Update is called once per frame
	void Update () 
	{
		timer = Time.realtimeSinceStartup;

		Vector3 pos 	= Camera.main.WorldToViewportPoint(transform.position);
		
		Vector3 left 	= Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0));
		Vector3 right 	= Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
		Vector3 above 	= Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
		Vector3 below 	= Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 1));
		
		if (pos.x > 1.3)
		{
			transform.position = new Vector3(left.x - cameraPosY, 0, transform.position.z);
			wrapCount++;
		}
		if (pos.x < -0.3)
		{
			transform.position = new Vector3(right.x + cameraPosY, 0, transform.position.z);
			wrapCount++;
		}
		if (pos.y > 1.3)
		{
			transform.position = new Vector3(transform.position.x, 0, below.z - (cameraPosY / 2));
			wrapCount++;
		}
		if (pos.y < -0.3)
		{
			transform.position = new Vector3(transform.position.x, 0, above.z + (cameraPosY / 2));
			wrapCount++;
		}
		
		if (wrapCount > wrapDestroy)
		{
			Destroy(gameObject);
		}
		
		if (timer > timerReset)
		{
			wrapCount = 0;
			timer = 0;
		}
	}
}
