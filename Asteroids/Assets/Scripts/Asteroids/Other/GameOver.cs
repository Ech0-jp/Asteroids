using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour 
{
	public GUISkin skin;
	public Vector2 gameOver_Label;

	public int score;
	public float endGameTimer			= 15;
	public bool gameEnded				= false;

	public _GUIClasses.Location center = new _GUIClasses.Location();

	void FixedUpdate()
	{
		center.updateLocation();

		if (gameEnded)
		{
			endGameTimer -= Time.deltaTime;
			EndGame();
		}
	}

	void OnGUI()
	{
		GUI.skin = skin;
		GUI.color = Color.red;
		if (gameEnded)
			GUI.Label(new Rect(center.offset.x + gameOver_Label.x, center.offset.y + gameOver_Label.y, 1000, 70), "GAMEOVER");
	}

	void EndGame()
	{
		PlayerPrefs.SetInt("NewScore", score);

		if (endGameTimer <= 0.0f)
		{
			Application.LoadLevel("HighScore");
		}
	}
}
