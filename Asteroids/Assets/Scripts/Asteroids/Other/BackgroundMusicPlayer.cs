using UnityEngine;
using System.Collections;

public class BackgroundMusicPlayer : MonoBehaviour 
{
	public AudioClip[] songs;
	public AudioClip currentSong;
	public AudioSource playSong;
	public int totalSongs;
	public int x;

	GameObject mainCamera;

	GameObject gui;
	PauseMenu pauseMenu;
	public bool hasPaused				= false;
	private float musicVolume;
	private bool musicMute;

	// Use this for initialization
	void Start () 
	{
		mainCamera = GameObject.FindGameObjectWithTag("MainCamera");

		gui = GameObject.FindGameObjectWithTag("GUI");
		pauseMenu = gui.GetComponent<PauseMenu>();
		musicVolume = PlayerPrefs.GetFloat("MusicVolume");

		playSong = mainCamera.audio;
		x = 0;
		totalSongs = songs.Length;
		PlaySong();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (hasPaused)
		{
			musicVolume = PlayerPrefs.GetFloat("MusicVolume");
		}

		mainCamera.audio.volume = musicVolume;
		mainCamera.audio.mute = musicMute;

		if (playSong.audio.isPlaying == false)
		{
			if ((x + 1) >= totalSongs)
			{
				x = 0; 
				PlaySong();
			}
			else
			{
				x++;
				PlaySong();
			}
		}
	}

	void PlaySong()
	{
		currentSong = songs[x];
		playSong.clip = currentSong;
		playSong.Play();
	}
}
