using UnityEngine;
using System.Collections;

public class VolumeScript : MonoBehaviour 
{
	public bool inOptions				= false;
	private float volume;

	// Use this for initialization
	void Start () 
	{
		volume = PlayerPrefs.GetFloat("MusicVolume");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (inOptions)
		{
			volume = PlayerPrefs.GetFloat("MusicVolume");
			audio.enabled = true;
			audio.volume = volume;
		}
		else
			audio.enabled = false;
	}
}
