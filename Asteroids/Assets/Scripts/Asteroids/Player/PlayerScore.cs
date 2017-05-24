using UnityEngine;
using System.Collections;

public class PlayerScore : MonoBehaviour 
{
	// PLAYER SCORE VARIABLES
	private GameObject playerGameObject;
	private int playerScore;
	private int previouseScore;

	// GUI PROPERTY VARIABLES
	public Vector2 guiPosition;
	public int guiSize;
	public GUISkin font;

	// GET, SET CENTER SCREEN LOCATION
	public _GUIClasses.Location center = new _GUIClasses.Location();

	// Use this for initialization
	void Start () 
	{
		playerGameObject = GameObject.FindGameObjectWithTag("Player");
		PlayerProperties playerProperties = playerGameObject.GetComponent<PlayerProperties>();
		previouseScore = playerProperties.playerScore;
	}
	
	// Update is called once per frame
	void Update () 
	{
		center.updateLocation();

		PlayerProperties playerProperties = playerGameObject.GetComponent<PlayerProperties>();
		playerScore = playerProperties.playerScore;

		if (playerScore > previouseScore)
		{
			previouseScore = playerScore;
			OnGUI();
		}
	}

	// DISPLAYS PLAYER SCORE
	void OnGUI()
	{
		GUI.skin = font;
		GUI.Label(new Rect(center.offset.x + guiPosition.x, center.offset.y + guiPosition.y, guiSize, guiSize), playerScore.ToString());
	}
}
