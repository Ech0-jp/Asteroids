using UnityEngine;
using System.Collections;
[ExecuteInEditMode]

public class PauseMenu : MonoBehaviour 
{
	public Color GUIColor;

	public GUISkin skin;
	public bool isPaused 						= false;

	public Vector2 resumeButton;
	public Vector2 mainMenuButton;
	public Vector2 optionsButton;

	// OPTIONS MENU
	public Vector2 options_BackButton;
	public Vector2 pause_Label;

	public Vector2 sfxLabel;
	public Vector2 sfxMuteLabel;
	public Vector2 sfxSlider;
	public Vector2 sfxMuteToggle;

	public Vector2 musicLabel;
	public Vector2 musicMuteLabel;
	public Vector2 musicSlider;
	public Vector2 musicMuteToggle;
	
	public float sfxVolume;
	public bool sfxMute							= false;
	public float musicVolume;
	public bool musicMute						= false;

	private bool pause_Menu 					= true;
	private bool pause_Options					= false;
	
	public _GUIClasses.Location center 			= new _GUIClasses.Location();
	public _GUIClasses.TextureGUI graphic 		= new _GUIClasses.TextureGUI();

	void OnStart()
	{
		musicVolume = PlayerPrefs.GetFloat("MusicVolume");
		sfxVolume = PlayerPrefs.GetFloat("SFXVolume");
	}

	// Update is called once per frame
	void Update () 
	{
		center.updateLocation();

		if (isPaused)
		{
			Time.timeScale 		= 0;
			Screen.showCursor 	= true;
		}
		else 
		{
			Time.timeScale 		= 1;
			Screen.showCursor 	= false;
		}
		
		if (Input.GetKeyDown(KeyCode.Escape))
			isPaused = true;
	}

	void OnGUI()
	{
		GUI.skin 	= skin;
		GUI.color 	= GUIColor;

		if (isPaused == true)
		{
			GUI.Label(new Rect(center.offset.x + pause_Label.x, center.offset.y + pause_Label.y, 200, 70), "PAUSED");

			if (pause_Menu)
				Pause_Menu();
			if (pause_Options)
			{
				Pause_Options();
			}
		}
	}

	void Pause_Menu()
	{
		if (graphic.texture) 
		{
			GUI.DrawTexture(new Rect(graphic.offset.x,graphic.offset.y, Screen.width,Screen.height), graphic.texture,ScaleMode.StretchToFill,true);
		}

		if (GUI.Button(new Rect(center.offset.x + resumeButton.x, center.offset.y + resumeButton.y, 140, 50), "Resume"))
		{
			isPaused = false;
		}
		if (GUI.Button (new Rect(center.offset.x + optionsButton.x, center.offset.y + optionsButton.y, 140, 50), "Options"))
		{
			isPaused = true;
			pause_Menu 	= false;
			pause_Options = true;
		}
		if (GUI.Button (new Rect(center.offset.x + mainMenuButton.x, center.offset.y + mainMenuButton.y, 140, 50), "Main Menu"))
		{
			Application.LoadLevel("MainMenu");
		}
	}

	void Pause_Options()
	{
		skin.label.fontSize = 20;

		GameObject musicSource = GameObject.FindGameObjectWithTag("MainCamera");
		BackgroundMusicPlayer backgroundMusicPlayer = musicSource.GetComponent<BackgroundMusicPlayer>();
		GameObject playerGameObject = GameObject.FindGameObjectWithTag("Player");
		PlayerProperties playerPropeties = playerGameObject.GetComponent<PlayerProperties>();

		playerPropeties.hasPaused = true;
		backgroundMusicPlayer.hasPaused = true;

		if (graphic.texture) 
		{
			GUI.DrawTexture(new Rect(graphic.offset.x,graphic.offset.y, Screen.width,Screen.height), graphic.texture,ScaleMode.StretchToFill,true);
		}

		if (GUI.Button(new Rect(center.offset.x + options_BackButton.x, center.offset.y + options_BackButton.y, 140, 50), "Back"))
		{
			pause_Menu = true;
			pause_Options = false;
		}

		GUI.Label(new Rect(center.offset.x + sfxLabel.x, center.offset.y + sfxLabel.y, 240, 100), "SFX Volume");
		sfxVolume = GUI.HorizontalSlider(new Rect(center.offset.x + sfxSlider.x, center.offset.y + sfxSlider.y, 140, 50), sfxVolume, 0.0f, 1.0f);
		PlayerPrefs.SetFloat("SFXVolume", sfxVolume);

		GUI.Label(new Rect(center.offset.x + sfxMuteLabel.x, center.offset.y + sfxMuteLabel.y, 140, 50), "Mute");
		sfxMute = GUI.Toggle(new Rect(center.offset.x + sfxMuteToggle.x, center.offset.y + sfxMuteToggle.y, 140, 50), sfxMute, "");
		if (sfxMute)
			PlayerPrefs.SetFloat("SFXVolume", 0.0f);

		GUI.Label (new Rect(center.offset.x + musicLabel.x, center.offset.y + musicLabel.y, 240, 100), "Music Volume");
		musicVolume = GUI.HorizontalSlider(new Rect(center.offset.x + musicSlider.x, center.offset.y + musicSlider.y, 140, 50), musicVolume, 0.0f, 1.0f);
		PlayerPrefs.SetFloat("MusicVolume", musicVolume);

		GUI.Label (new Rect(center.offset.x + musicMuteLabel.x, center.offset.y + musicMuteLabel.y, 140, 50), "Mute");
		musicMute = GUI.Toggle (new Rect(center.offset.x + musicMuteToggle.x, center.offset.y + musicMuteToggle.y, 140, 50), musicMute, "");
		if (musicMute)
			PlayerPrefs.SetFloat("MusicVolume", 0.0f);
	}

	void AlphaUp(float change) 
	{
		GUIColor.a += change;
	}
	
	void setStartColor(Color color) 
	{
		GUIColor = color;
	}
	
	
	void setDelay(float delay)
	{
		if (GUIColor.a > .5) 
		{
			GUIColor.a += delay;
		} 
		else 
		{
			GUIColor.a -= delay;
		}
	}
	
	void AlphaDown(float change) 
	{
		GUIColor.a -= change;
	}
}






















