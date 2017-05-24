using UnityEngine;
using System.Collections;

public class ScreenWrap : MonoBehaviour 
{
	public float cameraPosY;

	// Use this for initialization
	void Start () 
	{
		cameraPosY = Camera.main.transform.position.y;
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 pos 	= Camera.main.WorldToViewportPoint(transform.position);

		Vector3 left 	= Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0));
		Vector3 right 	= Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
		Vector3 above 	= Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
		Vector3 below 	= Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 1));

		if (pos.x > 1.1)
		{
			transform.position = new Vector3(left.x - cameraPosY, 0, transform.position.z);
		}
		if (pos.x < -0.1)
		{
			transform.position = new Vector3(right.x + cameraPosY, 0, transform.position.z);
		}
		if (pos.y > 1.1)
		{
			transform.position = new Vector3(transform.position.x, 0, below.z - (cameraPosY / 2));
		}
		if (pos.y < -0.1)
		{
			transform.position = new Vector3(transform.position.x, 0, above.z + (cameraPosY / 2));
		}
	}
}












