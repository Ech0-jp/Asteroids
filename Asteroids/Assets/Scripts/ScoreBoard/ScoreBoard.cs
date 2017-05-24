using UnityEngine;
using System.Collections;

public class ScoreBoard : MonoBehaviour 
{
	public GUISkin skin;
	public _GUIClasses.Location center = new _GUIClasses.Location();

	public int rank1;
	public int rank2;
	public int rank3;
	public int rank4;
	public int rank5;
	public int rank6;
	public int rank7;
	public int rank8;
	public int rank9;
	public int rank10;

	public string name1;
	public string name2;
	public string name3;
	public string name4;
	public string name5;
	public string name6;
	public string name7;
	public string name8;
	public string name9;
	public string name10;

	public int newScore;
	public string newName;

	public Vector2 newName_Label;
	public Vector2 newName_Textfield;
	public Vector2 newScore_Label;
	public Vector2 enter_Button;
	public Vector2 mainMenu_button;

	public Vector2 highscore_Label;
	public Vector2 rank1_Label;
	public Vector2 rank2_Label;
	public Vector2 rank3_Label;
	public Vector2 rank4_Label;
	public Vector2 rank5_Label;
	public Vector2 rank6_Label;
	public Vector2 rank7_Label;
	public Vector2 rank8_Label;
	public Vector2 rank9_Label;
	public Vector2 rank10_Label;

	void Start()
	{
		rank1 = PlayerPrefs.GetInt("score1");
		rank2 = PlayerPrefs.GetInt("score2");
		rank3 = PlayerPrefs.GetInt("score3");
		rank4 = PlayerPrefs.GetInt("score4");
		rank5 = PlayerPrefs.GetInt("score5");
		rank6 = PlayerPrefs.GetInt("score6");
		rank7 = PlayerPrefs.GetInt("score7");
		rank8 = PlayerPrefs.GetInt("score8");
		rank9 = PlayerPrefs.GetInt("score9");
		rank10 = PlayerPrefs.GetInt("score10");

		name1 = PlayerPrefs.GetString("name1");
		name2 = PlayerPrefs.GetString("name2");
		name3 = PlayerPrefs.GetString("name3");
		name4 = PlayerPrefs.GetString("name4");
		name5 = PlayerPrefs.GetString("name5");
		name6 = PlayerPrefs.GetString("name6");
		name7 = PlayerPrefs.GetString("name7");
		name8 = PlayerPrefs.GetString("name8");
		name9 = PlayerPrefs.GetString("name9");
		name10 = PlayerPrefs.GetString("name10");

		newScore = PlayerPrefs.GetInt("NewScore");

		Screen.showCursor 	= true;
	}

	void Update()
	{
		center.updateLocation();
	}

	void OnGUI()
	{
		GUI.skin = skin;

		if (newScore > rank10)
			highscore();
		else
			showscore();
	}

	void highscore()
	{
		GUI.Label(new Rect(center.offset.x + newScore_Label.x, center.offset.y + newScore_Label.y, 1000, 70), "Congradulations! New HighScore!");
		GUI.Label(new Rect(center.offset.x + newName_Label.x, center.offset.y + newName_Label.y, 1000, 70), "Please enter your name:");
		newName = GUI.TextField(new Rect(center.offset.x + newName_Textfield.x, center.offset.y + newName_Textfield.y, 200, 20), newName);

		if (GUI.Button(new Rect(center.offset.x + enter_Button.x, center.offset.y + enter_Button.y, 100, 40), "Enter"))
		{
			if (newScore > rank1)
			{
				rank2 = rank1;
				rank3 = rank2;
				rank4 = rank3;
				rank5 = rank4;
				rank6 = rank5;
				rank7 = rank6;
				rank8 = rank7;
				rank9 = rank8;
				rank10 = rank9;

				rank1 = newScore;
				name1 = newName;
			}
			else if (newScore > rank2)
			{
				rank3 = rank2;
				rank4 = rank3;
				rank5 = rank4;
				rank6 = rank5;
				rank7 = rank6;
				rank8 = rank7;
				rank9 = rank8;
				rank10 = rank9;

				rank2 = newScore;
				name2 = newName;
			}
			else if (newScore > rank3)
			{
				rank4 = rank3;
				rank5 = rank4;
				rank6 = rank5;
				rank7 = rank6;
				rank8 = rank7;
				rank9 = rank8;
				rank10 = rank9;
				
				rank3 = newScore;
				name3 = newName;
			}
			else if (newScore > rank4)
			{
				rank5 = rank4;
				rank6 = rank5;
				rank7 = rank6;
				rank8 = rank7;
				rank9 = rank8;
				rank10 = rank9;
				
				rank4 = newScore;
				name4 = newName;
			}
			else if (newScore > rank5)
			{
				rank6 = rank5;
				rank7 = rank6;
				rank8 = rank7;
				rank9 = rank8;
				rank10 = rank9;
				
				rank5 = newScore;
				name5 = newName;
			}
			else if (newScore > rank6)
			{
				rank7 = rank6;
				rank8 = rank7;
				rank9 = rank8;
				rank10 = rank9;
				
				rank6 = newScore;
				name6 = newName;
			}
			else if (newScore > rank7)
			{
				rank8 = rank7;
				rank9 = rank8;
				rank10 = rank9;
				
				rank7 = newScore;
				name7 = newName;
			}
			else if (newScore > rank8)
			{
				rank9 = rank8;
				rank10 = rank9;
				
				rank8 = newScore;
				name8 = newName;
			}
			else if (newScore > rank9)
			{
				rank10 = rank9;
				
				rank9 = newScore;
				name9 = newName;
			}
			else if (newScore > rank10)
			{				
				rank10 = newScore;
				name10 = newName;
			}

			PlayerPrefs.SetInt("score1", rank1);
			PlayerPrefs.SetInt("score2", rank2);
			PlayerPrefs.SetInt("score3", rank3);
			PlayerPrefs.SetInt("score4", rank4);
			PlayerPrefs.SetInt("score5", rank5);
			PlayerPrefs.SetInt("score6", rank6);
			PlayerPrefs.SetInt("score7", rank7);
			PlayerPrefs.SetInt("score8", rank8);
			PlayerPrefs.SetInt("score9", rank9);
			PlayerPrefs.SetInt("score10", rank10);

			PlayerPrefs.SetString("name1", name1);
			PlayerPrefs.SetString("name2", name2);
			PlayerPrefs.SetString("name3", name3);
			PlayerPrefs.SetString("name4", name4);
			PlayerPrefs.SetString("name5", name5);
			PlayerPrefs.SetString("name6", name6);
			PlayerPrefs.SetString("name7", name7);
			PlayerPrefs.SetString("name8", name8);
			PlayerPrefs.SetString("name9", name9);
			PlayerPrefs.SetString("name10", name10);

			PlayerPrefs.SetInt("NewScore", 0);
			newScore = 0;
		}
	}

	void showscore()
	{
		if (GUI.Button(new Rect(center.offset.x + mainMenu_button.x, center.offset.y + mainMenu_button.y , 140, 50), "Main Menu"))
		{
			Application.LoadLevel("MainMenu");
		}

		GUI.Label(new Rect(center.offset.x + highscore_Label.x, center.offset.y + highscore_Label.y, 1000, 70), "Highscores");
		GUI.Label(new Rect(center.offset.x + rank1_Label.x, center.offset.y + rank1_Label.y, 1000, 70), ("1: " + rank1 + " : " + name1));
		GUI.Label(new Rect(center.offset.x + rank2_Label.x, center.offset.y + rank2_Label.y, 1000, 70), ("2: " + rank2 + " : " + name2));
		GUI.Label(new Rect(center.offset.x + rank3_Label.x, center.offset.y + rank3_Label.y, 1000, 70), ("3: " + rank3 + " : " + name3));
		GUI.Label(new Rect(center.offset.x + rank4_Label.x, center.offset.y + rank4_Label.y, 1000, 70), ("4: " + rank4 + " : " + name4));
		GUI.Label(new Rect(center.offset.x + rank5_Label.x, center.offset.y + rank5_Label.y, 1000, 70), ("5: " + rank5 + " : " + name5));
		GUI.Label(new Rect(center.offset.x + rank6_Label.x, center.offset.y + rank6_Label.y, 1000, 70), ("6: " + rank6 + " : " + name6));
		GUI.Label(new Rect(center.offset.x + rank7_Label.x, center.offset.y + rank7_Label.y, 1000, 70), ("7: " + rank7 + " : " + name7));
		GUI.Label(new Rect(center.offset.x + rank8_Label.x, center.offset.y + rank8_Label.y, 1000, 70), ("8: " + rank8 + " : " + name8));
		GUI.Label(new Rect(center.offset.x + rank9_Label.x, center.offset.y + rank9_Label.y, 1000, 70), ("9: " + rank9 + " : " + name9));
		GUI.Label(new Rect(center.offset.x + rank10_Label.x, center.offset.y + rank10_Label.y, 1000, 70), ("10: " + rank10 + " : " + name10));
	}
}

















