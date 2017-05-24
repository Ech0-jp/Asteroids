using UnityEngine;
using System.Collections;

public class test : MonoBehaviour 
{
	public GUISkin skin;
	public _GUIClasses.Location center = new _GUIClasses.Location();
	
	public int[] scores;
	public string[] names;
	
	public int newScore;
	public string newName;
	
	public Vector2 newScore_Label;
	public Vector2 newName_Label;
	public Vector2 newName_TextField;
	public Vector2 enter_Button;
	
	public Vector2 highScore_Label;
	
	public Vector2[] ranks_Label;
	
	// Use this for initialization
	void Start () 
	{
		int x;
		for(x = 0; x < 10; x++)
		{
			scores[x] 	= PlayerPrefs.GetInt(("Rank" + (x + 1)));
			names[x] 	= PlayerPrefs.GetString(("Name" + (x + 1)));
		}
		scores[0] = PlayerPrefs.GetInt("Rank1");
		names[0] = PlayerPrefs.GetString("Name1");
		//newScore = PlayerPrefs.GetInt("NewScore");
	}
	
	// Update is called once per frame
	void Update () 
	{
		center.updateLocation();
	}
	
	void OnGUI()
	{
		GUI.skin = skin;
		skin.label.fontSize = 25;
		
		if (newScore > scores[9])
			NewScore();
		else
			LeaderBoards();
	}
	
	void NewScore()
	{
		GUI.Label (new Rect(center.offset.x + newScore_Label.x, center.offset.y + newScore_Label.y, 1000, 70), "Congradulations! New HighScore!");
		GUI.Label (new Rect(center.offset.x + newName_Label.x, center.offset.y + newName_Label.y, 1000, 70), "Please enter your name: ");
		newName = GUI.TextField(new Rect(center.offset.x + newName_TextField.x, center.offset.y + newName_TextField.y, 200, 20), newName, 25);
		
		if (GUI.Button(new Rect(center.offset.x + enter_Button.x, center.offset.y + enter_Button.y, 140, 50), "Enter"))
		{
			SetNewScores();
		}
	}
	
	void SetNewScores()
	{
		Debug.Log ("Setting New Scores");
		int x;
		for (x = 0; x < 10; x++)
		{
			if (newScore > scores[x])
			{
				int y;
				for (y = x; y < 9; y++)
				{
					scores[y + 1] = scores[y];
					names[y + 1] = names[y];
				}
				scores[x] 	= newScore;
				names[x] 	= newName;
				
				return;
			}
		}

		int i;
		for (i = 0; i < 10; i++)
		{
			Debug.Log ("Setting PlayerPrefs x: " + x);
			PlayerPrefs.SetInt(("Rank" + (x + 1)), scores[x]);
			PlayerPrefs.SetString(("Name" + (x + 1)), names[x]);
			
			Debug.Log ("PlayerPrefs Rank" + (x + 1) + " is now " + PlayerPrefs.GetInt("Rank" + (x + 1)));
			Debug.Log ("PlayerPrefs Name" + (x + 1) + " is now " + PlayerPrefs.GetString("Name" + (x + 1)));
		}
		
		PlayerPrefs.SetInt("Rank1", scores[0]);
		PlayerPrefs.SetString("Name1", names[0]);
		PlayerPrefs.SetInt("NewScore", 0);
		newScore = 0;
	}
	
	void LeaderBoards()
	{
		GUI.Label (new Rect(center.offset.x + highScore_Label.x, center.offset.y + highScore_Label.y, 200, 70), "HighScores");
		int x;
		for(x = 0; x < 10; x++)
		{
			GUI.Label(new Rect(center.offset.x + ranks_Label[x].x, center.offset.y + ranks_Label[x].y, 200, 70), ( (x+1)+ " : " + names[x] + " : " + scores[x] ));
		}
	}
}
