using UnityEngine;
using System.Collections;
[ExecuteInEditMode]

public class MainMenu : MonoBehaviour 
{
	public GUISkin asteroidsGUISkin;
	public GUISkin skin;

	public Vector2 buttonStartLocation;
	public Vector2 buttonOptionsLocation;
	public Vector2 buttonScoreBoardLocation;
	public Vector2 buttonHelpLocation;
	public Vector2 buttonExitLocation;

	// OPTIONS MENU
	public Vector2 options_BackButton;
	
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

	//HELP MENU LOCATIONS
	public Color GUIColor;

	public Vector2 help_backButtonLocation;

	private bool mainMenu						= true;
	private bool helpMenu						= false;
	private bool optionsMenu					= false;

	public _GUIClasses.Location center 			= new _GUIClasses.Location();
	public _GUIClasses.TextureGUI graphic 		= new _GUIClasses.TextureGUI();

	void Start()
	{
		PlayerPrefs.SetInt("NewScore", 0);
		sfxVolume = PlayerPrefs.GetFloat("SFXVolume", 1.0f);
		musicVolume = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
		Screen.showCursor 	= true;
	}

	// Update is called once per frame
	void Update ()
	{
		center.updateLocation();
	}

	void OnGUI()
	{
		GUI.skin = asteroidsGUISkin;

		if (mainMenu)
			Main_Menu();
		else if (optionsMenu)
			OptionsMenu();
		else if (helpMenu)
			HelpMenu();
	}

	void Main_Menu()
	{		
		if (GUI.Button(new Rect(center.offset.x + buttonStartLocation.x, center.offset.y + buttonStartLocation.y, 140, 50), "START"))
		{
			Application.LoadLevel("area1");
		}

		if (GUI.Button(new Rect(center.offset.x + buttonOptionsLocation.x, center.offset.y + buttonOptionsLocation.y, 140, 50), "OPTIONS"))
		{
			mainMenu = false;
			optionsMenu = true;
		}

		if (GUI.Button(new Rect(center.offset.x + buttonScoreBoardLocation.x, center.offset.y + buttonScoreBoardLocation.y, 140, 50), "SCORES"))
		{
			Application.LoadLevel("HighScore");
		}

		if (GUI.Button(new Rect(center.offset.x + buttonHelpLocation.x, center.offset.y + buttonHelpLocation.y, 140, 50), "HELP"))
		{
			mainMenu = false;
			helpMenu = true;
		}
		
		if (GUI.Button(new Rect(center.offset.x + buttonExitLocation.x, center.offset.y + buttonExitLocation.y, 140, 50), "EXIT"))
		{
			Application.Quit();
		}
	}

	void HelpMenu()
	{
		if (graphic.texture) 
		{
			GUI.DrawTexture(new Rect(graphic.offset.x,graphic.offset.y, Screen.width,Screen.height), graphic.texture,ScaleMode.StretchToFill,true);
		}

		if (GUI.Button(new Rect(center.offset.x + help_backButtonLocation.x, center.offset.y + help_backButtonLocation.y, 140, 50), "BACK"))
		{
			mainMenu = true;
			helpMenu = false;
		}
	}

	void OptionsMenu()
	{
		GUI.skin = skin;
		skin.label.fontSize = 20;

		GameObject music = GameObject.FindGameObjectWithTag("Music");
		GameObject sfx = GameObject.FindGameObjectWithTag("SFX");
		SFXScript sfxScript = sfx.GetComponent<SFXScript>();
		VolumeScript volumeScript = music.GetComponent<VolumeScript>();
		sfxScript.inOptions = true;
		volumeScript.inOptions = true;

		if (GUI.Button(new Rect(center.offset.x + options_BackButton.x, center.offset.y + options_BackButton.y, 140, 50), "Back"))
		{
			mainMenu = true;
			optionsMenu = false;

			sfxScript.inOptions = false;
			volumeScript.inOptions = false;
		}
		
		GUI.Label(new Rect(center.offset.x + sfxLabel.x, center.offset.y + sfxLabel.y, 240, 100), "SFX Volume");
		sfxVolume = GUI.HorizontalSlider(new Rect(center.offset.x + sfxSlider.x, center.offset.y + sfxSlider.y, 140, 5), sfxVolume, 0.0f, 1.0f);
		PlayerPrefs.SetFloat("SFXVolume", sfxVolume);
		
		GUI.Label(new Rect(center.offset.x + sfxMuteLabel.x, center.offset.y + sfxMuteLabel.y, 140, 50), "Mute");
		sfxMute = GUI.Toggle(new Rect(center.offset.x + sfxMuteToggle.x, center.offset.y + sfxMuteToggle.y, 140, 50), sfxMute, "");
		if (sfxMute)
			PlayerPrefs.SetFloat("SFXVolume", 0.0f);
		
		GUI.Label (new Rect(center.offset.x + musicLabel.x, center.offset.y + musicLabel.y, 240, 100), "Music Volume");
		musicVolume = GUI.HorizontalSlider(new Rect(center.offset.x + musicSlider.x, center.offset.y + musicSlider.y, 140, 5), musicVolume, 0.0f, 1.0f);
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




















