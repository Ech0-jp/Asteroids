using UnityEngine;
using System.Collections;
[ExecuteInEditMode]

public class HealthGUI : MonoBehaviour 
{
	// PLAYER HEALTH GUI TEXTURES
	public Texture2D health_100;
	public Texture2D health_75;
	public Texture2D health_50;
	public Texture2D health_25;
	public Texture2D health_00;
	private Texture2D currentHealth;

	// GUI POSITION AND SIZE VARIABLES
	public Vector2 guiPosition;
	public int guiSize;

	// GET, SET PLAYER HEALTH
	public int healthGUI = 4;
	private GameObject playerGameObject;

	// GET, SET CENTER OF SCREEN
	public _GUIClasses.Location center = new _GUIClasses.Location();

	// Use this for initialization
	void Start () 
	{
		playerGameObject = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () 
	{
		center.updateLocation();

		PlayerProperties playerProperties = playerGameObject.GetComponent<PlayerProperties>();
		healthGUI = playerProperties.health;

		switch(healthGUI)
		{
		case 4:
			currentHealth = health_100;
			OnGUI();
			break;
		case 3:
			currentHealth = health_75;
			OnGUI();
			break;
		case 2:
			currentHealth = health_50;
			OnGUI();
			break;
		case 1:
			currentHealth = health_25;
			OnGUI();
			break;
		case 0 :
			currentHealth = health_00;
			OnGUI();
			break;
		}
	}

	// DISPLAYS PLAYERS HEALTH STATUS
	void OnGUI()
	{
		GUI.DrawTexture(new Rect(center.offset.x + guiPosition.x, center.offset.y + guiPosition.y, guiSize, guiSize), currentHealth);
	}
}













